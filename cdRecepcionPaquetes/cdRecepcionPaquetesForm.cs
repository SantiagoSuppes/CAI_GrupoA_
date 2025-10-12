using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.CdRecepcionPaquetes
{
    public partial class CdRecepcionPaquetesForm : Form
    {
        // ========= Modelos y datos =========
        private sealed class Cliente
        {
            public string Cuit { get; init; } = string.Empty;
            public string RazonSocial { get; init; } = string.Empty;
        }

        private readonly List<Cliente> _clientes = new()
        {
            new Cliente { Cuit = "20123456780", RazonSocial = "Transporte TUTASA S.A." },
            new Cliente { Cuit = "27234567892", RazonSocial = "Logística Andina SRL" },
            new Cliente { Cuit = "20345678900", RazonSocial = "Distribuidora Central S.A." },
            new Cliente { Cuit = "23321098761", RazonSocial = "Envíos Express SRL" },
            new Cliente { Cuit = "30765432108", RazonSocial = "Comercial del Plata S.A." }
        };

        private static readonly string[] _tiposCaja = { "S", "M", "L", "XXL" };
        private static readonly string[] _modalidades = { "Domicilio", "Agencia", "CD" };

        private readonly Dictionary<string, List<string>> _agenciasPorProv = new()
        {
            ["Buenos Aires"] = new() { "Agencia Quilmes", "Agencia La Plata" },
            ["Córdoba"] = new() { "Agencia Centro", "Agencia Nueva Córdoba" },
            ["Santa Fe"] = new() { "Agencia Rosario" }
        };
        private readonly Dictionary<string, List<string>> _cdsPorProv = new()
        {
            ["Buenos Aires"] = new() { "CD Norte", "CD Sur" },
            ["Córdoba"] = new() { "CD Córdoba 1" },
            ["Santa Fe"] = new() { "CD Rosario" }
        };

        // ===== Numeración por CD origen =====
        private readonly Dictionary<string, string> _codigoPorCD = new()
        {
            ["CD Norte"] = "CD01",
            ["CD Sur"] = "CD02",
            ["CD Córdoba 1"] = "CD03",
            ["CD Rosario"] = "CD04"
        };
        private readonly Dictionary<string, int> _secuenciaPorCD = new(); // prefijo -> último número

        // ========= Load =========
        public CdRecepcionPaquetesForm() => InitializeComponent();

        private void CdRecepcionPaquetesForm_Load(object sender, EventArgs e)
        {
            InitListView();
            InitCajas();
            InitDestino();
        }

        private void InitListView()
        {
            lvDetalle.View = View.Details;
            lvDetalle.FullRowSelect = true;
            if (lvDetalle.Columns.Count == 0)
            {
                lvDetalle.Columns.Add("Tipo de Caja", 200);
                lvDetalle.Columns.Add("Cantidad", 80, HorizontalAlignment.Right);
            }
        }

        private void InitCajas()
        {
            cmbTipoCaja.Items.Clear();
            cmbTipoCaja.Items.AddRange(_tiposCaja);
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 1000;
            nudCantidad.Value = 1;
        }

        private void InitDestino()
        {
            cmbModalidad.Items.Clear();
            cmbModalidad.Items.AddRange(_modalidades);

            var provincias = _agenciasPorProv.Keys.Union(_cdsPorProv.Keys).Distinct().OrderBy(x => x).ToArray();
            cmbProvincia.Items.Clear();
            cmbProvincia.Items.AddRange(provincias);

            cmbModalidad.SelectedIndexChanged += (_, __) => AplicarReglasModalidad();
            cmbProvincia.SelectedIndexChanged += (_, __) => CargarDependientes();

            AplicarReglasModalidad();
        }

        // ========= Buscar cliente =========
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();

            string cuit = DigitsOnly(txtCuit.Text);
            if (!EsCuitBasico(cuit))
            { Msg("CUIT inválido. Debe tener 11 dígitos."); txtCuit.Focus(); return; }

            var cli = _clientes.FirstOrDefault(x => x.Cuit == cuit);
            if (cli is null)
            { Msg("No se encontró ningún cliente con ese CUIT."); txtCuit.Clear(); return; }

            txtCliente.Text = cli.RazonSocial;
        }

        // ========= Agregar detalle =========
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = (cmbTipoCaja.Text ?? "").Trim();
            int qty = (int)nudCantidad.Value;

            if (string.IsNullOrWhiteSpace(tipo)) { Msg("Seleccioná el tipo de caja."); cmbTipoCaja.Focus(); return; }
            if (qty <= 0) { Msg("La cantidad debe ser mayor a cero."); nudCantidad.Focus(); return; }

            var it = lvDetalle.Items.Cast<ListViewItem>()
                     .FirstOrDefault(i => string.Equals(i.SubItems[0].Text, tipo, StringComparison.OrdinalIgnoreCase));

            if (it != null)
            {
                int actual = int.Parse(it.SubItems[1].Text);
                it.SubItems[1].Text = (actual + qty).ToString();
            }
            else
            {
                var nuevo = new ListViewItem(tipo);
                nuevo.SubItems.Add(qty.ToString());
                lvDetalle.Items.Add(nuevo);
            }

            cmbTipoCaja.SelectedIndex = -1;
            cmbTipoCaja.Text = "";
            nudCantidad.Value = 1;
        }

        // ========= Modalidad / Provincia =========
        private void AplicarReglasModalidad()
        {
            string modalidad = cmbModalidad.Text;

            bool esDom = modalidad == "Domicilio";
            bool esAge = modalidad == "Agencia";
            bool esCD = modalidad == "CD";

            txtCalleAltura.Enabled = esDom;
            cmbAgencia.Enabled = esAge;
            cmbCD.Enabled = esCD;

            if (!esDom) txtCalleAltura.Clear();
            if (!esAge) { cmbAgencia.Items.Clear(); cmbAgencia.SelectedIndex = -1; cmbAgencia.Text = ""; }
            if (!esCD) { cmbCD.Items.Clear(); cmbCD.SelectedIndex = -1; cmbCD.Text = ""; }

            CargarDependientes();
        }

        private void CargarDependientes()
        {
            string prov = cmbProvincia.Text;
            if (string.IsNullOrWhiteSpace(prov)) { cmbAgencia.Items.Clear(); cmbCD.Items.Clear(); return; }

            cmbAgencia.Items.Clear();
            if (_agenciasPorProv.TryGetValue(prov, out var ags)) cmbAgencia.Items.AddRange(ags.ToArray());

            cmbCD.Items.Clear();
            if (_cdsPorProv.TryGetValue(prov, out var cds)) cmbCD.Items.AddRange(cds.ToArray());
        }

        // ========= Confirmar / Enviar =========
        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidarTodo()) return;

            var cdNombre = ObtenerCDOrigenPreferido();     // << determina el CD Origen
            var nroGuia = GenerarNumeroGuia(cdNombre);    // << genera CDxx-####

            Msg($"Envío registrado correctamente.\nN° de guía: {nroGuia}");

            LimpiarControles(this);
            nudCantidad.Value = 1;
            txtCuit.Focus();
            InitCajas();
            InitDestino();
        }

        // ========= Numeración =========
        private string GenerarNumeroGuia(string cdNombre)
        {
            // cdNombre -> prefijo tipo "CD01"
            var prefijo = _codigoPorCD.TryGetValue(cdNombre, out var cod) ? cod : "CD00";
            int next = _secuenciaPorCD.TryGetValue(prefijo, out var cur) ? cur + 1 : 1;
            _secuenciaPorCD[prefijo] = next;
            return $"{prefijo}-{next:0000}";
        }

        // Prioriza el CD seleccionado si modalidad = CD; si no, mapea por provincia
        private string ObtenerCDOrigenPreferido()
        {
            if (cmbModalidad.Text == "CD" && cmbCD.SelectedIndex >= 0)
                return cmbCD.Text;

            // fallback por provincia
            return cmbProvincia.Text switch
            {
                "Córdoba" => "CD Córdoba 1",
                "Santa Fe" => "CD Rosario",
                "Buenos Aires" => "CD Norte",
                _ => "CD Norte"
            };
        }

        private bool ValidarTodo()
        {
            if (string.IsNullOrWhiteSpace(txtCuit.Text)) { Msg("Ingrese CUIT."); txtCuit.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtCliente.Text)) { Msg("Busque un cliente válido."); return false; }

            if (!ReqTexto(nombreApellido, 2)) { Msg("Nombre y Apellido requerido."); nombreApellido.Focus(); return false; }
            if (!ReqDni(dni)) { Msg("DNI inválido. Use 7–8 dígitos."); dni.Focus(); return false; }
            if (!ReqTelefono(telefono)) { Msg("Teléfono inválido. Solo números 6–15 dígitos."); telefono.Focus(); return false; }
            if (!ReqCodigoPostal(codigoPostal)) { Msg("Código Postal inválido."); codigoPostal.Focus(); return false; }

            if (!ValidarDestinatario()) return false;

            if (lvDetalle.Items.Count == 0) { Msg("Agregue al menos un tipo de caja."); return false; }
            foreach (ListViewItem it in lvDetalle.Items)
                if (!int.TryParse(it.SubItems[1].Text, out int q) || q <= 0)
                { Msg($"Cantidad inválida en '{it.SubItems[0].Text}'."); return false; }

            return true;
        }

        private bool ValidarDestinatario()
        {
            if (string.IsNullOrWhiteSpace(cmbModalidad.Text)) { Msg("Seleccioná la modalidad de entrega."); return false; }
            if (string.IsNullOrWhiteSpace(cmbProvincia.Text)) { Msg("Seleccioná la provincia."); return false; }
            if (string.IsNullOrWhiteSpace(txtLocalidad.Text)) { Msg("Ingresá la localidad de destino."); return false; }

            switch (cmbModalidad.Text)
            {
                case "Domicilio":
                    if (string.IsNullOrWhiteSpace(txtCalleAltura.Text)) { Msg("Ingresá calle y altura."); return false; }
                    break;
                case "Agencia":
                    if (cmbAgencia.SelectedIndex < 0) { Msg("Seleccioná una agencia válida."); return false; }
                    break;
                case "CD":
                    if (cmbCD.SelectedIndex < 0) { Msg("Seleccioná un CD válido."); return false; }
                    break;
            }
            return true;
        }

        // ========= Utilitarios =========
        private static void LimpiarControles(Control root)
        {
            foreach (Control c in root.Controls)
            {
                switch (c)
                {
                    case TextBox tb: tb.Clear(); break;
                    case ComboBox cb: cb.SelectedIndex = -1; cb.Text = ""; break;
                    case NumericUpDown nud: nud.Value = nud.Minimum; break;
                    case CheckBox chk: chk.Checked = false; break;
                    case RadioButton rb: rb.Checked = false; break;
                    case ListView lv: lv.Items.Clear(); break;
                    case DataGridView dg: dg.Rows.Clear(); break;
                    case DateTimePicker dt: dt.Value = DateTime.Today; break;
                }
                if (c.HasChildren) LimpiarControles(c);
            }
        }

        private static string DigitsOnly(string s) => new string((s ?? "").Where(char.IsDigit).ToArray());
        private static bool EsCuitBasico(string cuit) => !string.IsNullOrWhiteSpace(cuit) && cuit.Length == 11;

        private static bool ReqTexto(TextBox tb, int minLen = 1)
            => tb != null && !string.IsNullOrWhiteSpace(tb.Text) && tb.Text.Trim().Length >= minLen;

        private static bool ReqDni(TextBox tb)
            => DigitsOnly(tb?.Text).Length is >= 7 and <= 8;

        private static bool ReqTelefono(TextBox tb)
        {
            var s = (tb?.Text ?? "").Trim();
            return s.Length is >= 6 and <= 15 && s.All(char.IsDigit);
        }

        private static bool ReqCodigoPostal(TextBox tb)
        {
            var s = (tb?.Text ?? "").Trim().ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(s)) return false;
            bool digits4 = s.All(char.IsDigit) && s.Length == 4;
            bool cpa8 = s.Length == 8 && s.All(char.IsLetterOrDigit);
            return digits4 || cpa8;
        }

        private static void Msg(string m) => MessageBox.Show(m, "Validación");

        // ========= Stubs Designer =========
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cuit_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) => btnBuscar_Click(sender, e);
        private void button2_Click(object sender, EventArgs e) => btnAgregar_Click(sender, e);
    }
}
