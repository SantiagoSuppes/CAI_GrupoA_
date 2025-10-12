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
        // Datos de prueba: CUIT como key (solo dígitos), lista de direcciones como value
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

            // Validación de formato (acepta con o sin guiones)
            if (!Regex.IsMatch(cuitInput, @"^\d{2}-?\d{8}-?\d{1}$"))
            {
                MessageBox.Show("El formato del CUIT no es válido. Ejemplo válido: 30-12345678-9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void BuscarClienteButton_Click(object sender, EventArgs e)
        {
            if(ValidarCuit(out string cuitInput))
            {
                // Normalizamos a solo dígitos para buscar en el diccionario de prueba
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
                    clienteListView.Items.Clear();

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
            if (clienteListView.SelectedItems.Count > 0)
            {
                DirSeleccionadaTextBox.Text = clienteListView.SelectedItems[0].Text;
            }
            else
            {
                DirSeleccionadaTextBox.Text = string.Empty;
            }
        }


        // ========= Agregar detalle =========

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
            // Obtiene la modalidad seleccionada
            var modalidad = cmbModalidad.SelectedItem?.ToString();

            // Deshabilita todos por defecto
            txtCalleYAltura.Enabled = false;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;

            // Habilita según modalidad
            if (modalidad == "Domicilio")
            {
                txtCalleYAltura.Enabled = true;
            }
            else if (modalidad == "Agencia")
            {
                cmbAgencia.Enabled = true;
            }
            else if (modalidad == "CD")
            {
                cmbCD.Enabled = true;
            }
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

        private bool ValidarDestinatario()
        {
            // Ejemplo de controles: txtNombre, txtDni, txtTelefono, cmbModalidad, cmbProvincia, cmbAgencia, cmbCD, txtDireccion
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

            if (string.IsNullOrWhiteSpace(txtCodigoPostal.Text) || txtCodigoPostal.Text.Trim().Length < 4 || txtCodigoPostal.Text.Trim().Length > 8)
            {
                Msg("Ingrese Codigo Postal válido.");
                txtLocalidad.Focus();
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

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provincia = cmbProvincia.SelectedItem?.ToString();

            // Limpiar los combos antes de cargar
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();

            // Cargar agencias según provincia
            if (!string.IsNullOrWhiteSpace(provincia) && _agenciasPorProv.TryGetValue(provincia, out var agencias))
            {
                cmbAgencia.Items.AddRange([.. agencias]);
            }

            // Cargar CDs según provincia
            if (!string.IsNullOrWhiteSpace(provincia) && _cdsPorProv.TryGetValue(provincia, out var cds))
            {
                cmbCD.Items.AddRange([.. cds]);
            }

            // Opcional: deseleccionar
            cmbAgencia.SelectedIndex = -1;
            cmbCD.SelectedIndex = -1;
        }

        private void InicializarTipoCaja()
        {
            cmbTipoCaja.Items.Clear();
            cmbTipoCaja.Items.AddRange([.. _tiposCaja]);
            cmbTipoCaja.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación de tipo de caja
            if (cmbTipoCaja.SelectedIndex < 0)
            {
                Msg("Seleccioná el tipo de caja.");
                cmbTipoCaja.DroppedDown = true;
                return;
            }

            // Validación de cantidad
            int cantidad;
            if (!int.TryParse(nudCantidad.Text, out cantidad) || cantidad <= 0)
            {
                Msg("Ingresá una cantidad válida (mayor a cero).");
                nudCantidad.Focus();
                return;
            }

            // Agregar a la ListView
            string tipoCaja = cmbTipoCaja.SelectedItem.ToString();

            // Si ya existe el tipo de caja, suma la cantidad
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

            // Limpiar controles
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
            if(string.IsNullOrEmpty(DirSeleccionadaTextBox.Text))
            {
                Msg("Buscá un cliente y selecciona una dirección.");
                return;
            }
            else if (!ValidarDestinatario()) { return; }
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
