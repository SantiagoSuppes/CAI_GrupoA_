using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.CallCenter
{
    public partial class CallCenterForm : Form
    {
        private readonly Dictionary<string, List<string>> clientesPrueba = new Dictionary<string, List<string>>();
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

        private readonly Dictionary<string, string> _codigoPorCD = new()
        {
            ["CD Norte"] = "CD01",
            ["CD Sur"] = "CD02",
            ["CD Córdoba 1"] = "CD03",
            ["CD Rosario"] = "CD04"
        };
        private readonly Dictionary<string, int> _secuenciaPorCD = new();

        public CallCenterForm()
        {
            InitializeComponent();
            CargarClientes();
            InitDestino();
            InicializarTipoCaja();
        }

        private static void Msg(string m) => MessageBox.Show(m, "Validación");

        private void CargarClientes()
        {
            clientesPrueba["30123456789"] = new List<string>
            {
                "Av. Corrientes 1234, CABA",
                "Calle Falsa 123, Lanús",
                "Ruta 3 Km 45, Estación Central"
            };

            clientesPrueba["27876543210"] = new List<string>
            {
                "Av. San Martín 200, Córdoba",
                "Parque Industrial 45, Córdoba"
            };

            clientesPrueba["33111222334"] = new List<string>
            {
                "Calle 9 de Julio 555, Rosario"
            };
        }

        private bool ValidarCuit(out string cuitInput)
        {
            cuitInput = cuitTextBox.Text.Trim();
            clienteListView.Items.Clear();

            if (string.IsNullOrEmpty(cuitInput))
            {
                MessageBox.Show("Por favor ingrese un CUIT.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(cuitInput, @"^\d{2}-?\d{8}-?\d{1}$"))
            {
                MessageBox.Show("El formato del CUIT no es válido. Ejemplo válido: 30-12345678-9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void BuscarClienteButton_Click(object sender, EventArgs e)
        {
            if (ValidarCuit(out string cuitInput))
            {
                string cuitDigits = Regex.Replace(cuitInput, @"\D", "");
                List<string> direcciones = ObtenerDireccionesPorCUIT(cuitDigits);

                clienteListView.Items.Clear();

                if (direcciones.Count == 0)
                {
                    MessageBox.Show("No se encontraron direcciones para este CUIT.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    clienteListView.BeginUpdate();
                    foreach (var dir in direcciones)
                    {
                        clienteListView.Items.Add(dir);
                    }
                    clienteListView.EndUpdate();
                }
            }
        }

        private List<string> ObtenerDireccionesPorCUIT(string cuitSinGuiones)
        {
            if (clientesPrueba.TryGetValue(cuitSinGuiones, out var direcciones))
            {
                return [.. direcciones];
            }
            return new List<string>();
        }

        private void clienteListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirSeleccionadaTextBox.Text = clienteListView.SelectedItems.Count > 0
                ? clienteListView.SelectedItems[0].Text
                : string.Empty;
        }

        // ======== Modalidad y destino ========
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

        private void AplicarReglasModalidad()
        {
            string modalidad = cmbModalidad.Text;
            bool esDom = modalidad == "Domicilio";
            bool esAge = modalidad == "Agencia";
            bool esCD = modalidad == "CD";

            txtCalleYAltura.Enabled = esDom;
            cmbAgencia.Enabled = esAge;
            cmbCD.Enabled = esCD;

            if (!esDom) txtCalleYAltura.Clear();
            if (!esAge) { cmbAgencia.Items.Clear(); cmbAgencia.SelectedIndex = -1; cmbAgencia.Text = ""; }
            if (!esCD) { cmbCD.Items.Clear(); cmbCD.SelectedIndex = -1; cmbCD.Text = ""; }

            CargarDependientes();
        }

        private void CargarDependientes()
        {
            string prov = cmbProvincia.Text;
            if (string.IsNullOrWhiteSpace(prov)) { cmbAgencia.Items.Clear(); cmbCD.Items.Clear(); return; }

            cmbAgencia.Items.Clear();
            if (_agenciasPorProv.TryGetValue(prov, out var ags)) cmbAgencia.Items.AddRange([.. ags]);

            cmbCD.Items.Clear();
            if (_cdsPorProv.TryGetValue(prov, out var cds)) cmbCD.Items.AddRange([.. cds]);
        }

        // ======== Validación de destinatario ========
        private bool ValidarDestinatario()
        {
            if (string.IsNullOrWhiteSpace(txtNombreYApellido.Text) || txtNombreYApellido.Text.Trim().Length < 2)
            {
                Msg("Nombre y Apellido requerido.");
                txtNombreYApellido.Focus();
                return false;
            }

            string dni = new string(txtDNI.Text.Where(char.IsDigit).ToArray());
            if (dni.Length < 7 || dni.Length > 8)
            {
                Msg("DNI inválido. Use 7–8 dígitos.");
                txtDNI.Focus();
                return false;
            }

            string telefono = txtTelefono.Text.Trim();
            if (telefono.Length < 6 || telefono.Length > 15 || !telefono.All(char.IsDigit))
            {
                Msg("Teléfono inválido. Solo números 6–15 dígitos.");
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbProvincia.Text))
            {
                Msg("Seleccioná la provincia.");
                cmbProvincia.DroppedDown = true;
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLocalidad.Text) || txtLocalidad.Text.Trim().Length < 2)
            {
                Msg("Ingrese Localidad de destino.");
                txtLocalidad.Focus();
                return false;
            }

            if (!ReqCodigoPostal(txtCodigoPostal))
            {
                Msg("Código Postal inválido. Use 4 dígitos.");
                txtCodigoPostal.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbModalidad.Text))
            {
                Msg("Seleccioná la modalidad de entrega.");
                cmbModalidad.DroppedDown = true;
                return false;
            }

            switch (cmbModalidad.Text)
            {
                case "Domicilio":
                    if (string.IsNullOrWhiteSpace(txtCalleYAltura.Text))
                    {
                        Msg("Ingresá calle y altura.");
                        txtCalleYAltura.Focus();
                        return false;
                    }
                    break;
                case "Agencia":
                    if (cmbAgencia.SelectedIndex < 0)
                    {
                        Msg("Seleccioná una agencia válida.");
                        cmbAgencia.DroppedDown = true;
                        return false;
                    }
                    break;
                case "CD":
                    if (cmbCD.SelectedIndex < 0)
                    {
                        Msg("Seleccioná un CD válido.");
                        cmbCD.DroppedDown = true;
                        return false;
                    }
                    break;
            }
            return true;
        }

        private static bool ReqCodigoPostal(TextBox tb)
        {
            var s = (tb?.Text ?? "").Trim().ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(s)) return false;
            bool digits4 = s.All(char.IsDigit) && s.Length == 4;
            bool cpa8 = s.Length == 8 && s.All(char.IsLetterOrDigit);
            return digits4 || cpa8;
        }

        // ======== Agregar detalle ========
        private void InicializarTipoCaja()
        {
            cmbTipoCaja.Items.Clear();
            cmbTipoCaja.Items.AddRange([.. _tiposCaja]);
            cmbTipoCaja.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipoCaja.SelectedIndex < 0)
            {
                Msg("Seleccioná el tipo de caja.");
                cmbTipoCaja.DroppedDown = true;
                return;
            }

            if (!int.TryParse(nudCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                Msg("Ingresá una cantidad válida (mayor a cero).");
                nudCantidad.Focus();
                return;
            }

            string tipoCaja = cmbTipoCaja.SelectedItem.ToString();
            var existente = lvDetalle.Items.Cast<ListViewItem>()
                .FirstOrDefault(i => string.Equals(i.SubItems[0].Text, tipoCaja, StringComparison.OrdinalIgnoreCase));

            if (existente != null)
            {
                int actual = int.Parse(existente.SubItems[1].Text);
                existente.SubItems[1].Text = (actual + cantidad).ToString();
            }
            else
            {
                var item = new ListViewItem(tipoCaja);
                item.SubItems.Add(cantidad.ToString());
                lvDetalle.Items.Add(item);
            }

            cmbTipoCaja.SelectedIndex = -1;
            cmbTipoCaja.Text = "";
            nudCantidad.Text = "1";
        }

        private string GenerarNumeroGuia(string cdNombre)
        {
            var prefijo = _codigoPorCD.TryGetValue(cdNombre, out var cod) ? cod : "CD00";
            int next = _secuenciaPorCD.TryGetValue(prefijo, out var cur) ? cur + 1 : 1;
            _secuenciaPorCD[prefijo] = next;
            return $"{prefijo}-{next:0000}";
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DirSeleccionadaTextBox.Text))
            {
                Msg("Buscá un cliente y seleccioná una dirección.");
                return;
            }
            else if (!ValidarDestinatario()) return;
            else if (lvDetalle.Items.Count == 0)
            {
                Msg("Agregá al menos un tipo de caja al detalle.");
            }
            else
            {
                var nroGuia = GenerarNumeroGuia(cmbCD.Text);
                Msg($"Pedido registrado correctamente.\nN° de guía: {nroGuia}");
                LimpiarControles(this);
            }
        }

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
    }
}
