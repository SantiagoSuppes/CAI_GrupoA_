using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public partial class ImposicionEnAgenciaForm : Form
    {
        public ImposicionEnAgenciaModelo modelo = new();

        private readonly Dictionary<ProvinciaEnum, (List<string> Agencias, List<string> CDs)> zonasPorProvincia = new()
        {
            { ProvinciaEnum.CiudadAutonomaDeBuenosAires, (new List<string>{ "Agencia Retiro", "Agencia Palermo" }, new List<string>{ "CD Central" }) },
            { ProvinciaEnum.BuenosAires, (new List<string>{ "Agencia Morón", "Agencia Ituzaingó" }, new List<string>{ "CD Oeste" }) },
            { ProvinciaEnum.Cordoba, (new List<string>{ "Agencia Córdoba Centro", "Agencia Nueva Córdoba" }, new List<string>{ "CD Córdoba" }) },
            { ProvinciaEnum.Mendoza, (new List<string>{ "Agencia Mendoza Norte" }, new List<string>{ "CD Cuyo" }) },
            { ProvinciaEnum.SantaFe, (new List<string>{ "Agencia Rosario", "Agencia Santa Fe" }, new List<string>{ "CD Litoral" }) },
        };

        private List<(TamañoCajaEnum Tamanio, int Cantidad)> cajasTemporales = new();

        public ImposicionEnAgenciaForm()
        {
            InitializeComponent();
        }

        private void ImposicionEnAgencia_Load(object sender, EventArgs e)
        {
            lstGuiasGeneradas.View = View.Details;
            lstGuiasGeneradas.FullRowSelect = true;
            lstGuiasGeneradas.Columns.Clear();
            lstGuiasGeneradas.Columns.Add("N° Guía", 120);
            lstGuiasGeneradas.Columns.Add("Cantidad", 100);
            lstGuiasGeneradas.Columns.Add("Tamaño", 120);

            cmbTipoCaja.Items.AddRange(Enum.GetNames(typeof(TamañoCajaEnum)));
            cmbTipoCaja.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProvincia.Items.AddRange(Enum.GetNames(typeof(ProvinciaEnum)));
            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbModalidadEntrega.Items.AddRange(Enum.GetNames(typeof(TipoPuntoEnum)));
            cmbModalidadEntrega.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAgencia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCD.DropDownStyle = ComboBoxStyle.DropDownList;

            numCantidad.Minimum = 1;
            numCantidad.Value = 1;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;
            txtDomicilio.Enabled = false;

            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            txtTelefonoDest.KeyPress += txtTelefonoDest_KeyPress;
        }

        private void txtTelefonoDest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnBuscarRemitente_Click(object sender, EventArgs e)
        {
            string cuit = txtCUIT.Text.Trim().Replace("-", "").Trim();

            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
            {
                MessageBox.Show("Formato de CUIT inválido (11 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modelo.TryGetCliente(cuit, out var cli))
            {
                txtRazonSocial.Text = cli.RazonSocial;
                MessageBox.Show($"Cliente encontrado:\n\n{cli.RazonSocial}", "Cliente existente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtRazonSocial.Clear();
                MessageBox.Show($"El cliente con CUIT {cuit} no existe en el sistema.",
                    "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();

            if (Enum.TryParse<ProvinciaEnum>(cmbProvincia.Text, out var provincia) &&
                zonasPorProvincia.TryGetValue(provincia, out var datos))
            {
                cmbAgencia.Items.AddRange(datos.Agencias.ToArray());
                cmbCD.Items.AddRange(datos.CDs.ToArray());
            }
        }

        private void cmbModalidadEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDomicilio.Enabled = false;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;

            if (Enum.TryParse<TipoPuntoEnum>(cmbModalidadEntrega.Text, out var tipo))
            {
                if (tipo == TipoPuntoEnum.Agencia) cmbAgencia.Enabled = true;
                else if (tipo == TipoPuntoEnum.CD) cmbCD.Enabled = true;
                else if (tipo == TipoPuntoEnum.Domicilio) txtDomicilio.Enabled = true;
            }
        }

        private void btnAgregarCaja_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTipoCaja.Text))
            {
                MessageBox.Show("Debe seleccionar un tamaño de caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tamaño = (TamañoCajaEnum)Enum.Parse(typeof(TamañoCajaEnum), cmbTipoCaja.Text);
            int cantidad = (int)numCantidad.Value;

            cajasTemporales.Add((tamaño, cantidad));

            var item = new ListViewItem("(Pendiente)");
            item.SubItems.Add(cantidad.ToString());
            item.SubItems.Add(tamaño.ToString());
            lstGuiasGeneradas.Items.Add(item);

            cmbTipoCaja.SelectedIndex = -1;
        }

        private void btnGenerarGuia_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cajasTemporales.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos una caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Enum.TryParse<TipoPuntoEnum>(cmbModalidadEntrega.Text, out var tipoEntrega))
                {
                    MessageBox.Show("Debe seleccionar una modalidad de entrega válida.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Enum.TryParse<ProvinciaEnum>(cmbProvincia.Text, out var provincia))
                {
                    MessageBox.Show("Debe seleccionar una provincia válida.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var origen = new DireccionEnt
                {
                    Provincia = ProvinciaEnum.BuenosAires,
                    Localidad = "Imposición Agencia",
                    CodigoPostal = 1000,
                    TipoPunto = TipoPuntoEnum.Agencia,
                    CalleYAltura = "Sede Central 123"
                };

                var destino = new DireccionEnt
                {
                    Provincia = provincia,
                    Localidad = txtLocalidad.Text,
                    CodigoPostal = int.TryParse(txtCP.Text, out var cp) ? cp : 0,
                    TipoPunto = tipoEntrega,
                    CalleYAltura = txtDomicilio.Text
                };

                var primeraCaja = cajasTemporales.First();
                var g = modelo.CrearGuia(
                    txtCUIT.Text,
                    origen,
                    destino,
                    primeraCaja.Tamanio,
                    EstadoActualEnum.EnAgencia_ListaParaRetirar
                );

                lstGuiasGeneradas.Items.Clear();
                foreach (var c in cajasTemporales)
                {
                    var item = new ListViewItem(g.NumeroGuia);
                    item.SubItems.Add(c.Cantidad.ToString());
                    item.SubItems.Add(c.Tamanio.ToString());
                    lstGuiasGeneradas.Items.Insert(0, item);
                }

                MessageBox.Show($"Guía generada correctamente.\n\nN° {g.NumeroGuia}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cajasTemporales.Clear();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar guía:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombreDestinatario.Clear();
            txtDNIDest.Clear();
            txtTelefonoDest.Clear();
            txtDomicilio.Clear();
            txtCP.Clear();
            txtLocalidad.Clear();
            cmbProvincia.SelectedIndex = -1;
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();
            cmbTipoCaja.SelectedIndex = -1;
            cmbModalidadEntrega.SelectedIndex = -1;
            numCantidad.Value = 1;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;
            txtDomicilio.Enabled = false;
        }
    }
}
