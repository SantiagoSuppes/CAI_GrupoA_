// Archivo: CdRecepcionPaquetes/CdRecepcionPaquetesForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.CdRecepcionPaquetes
{
    public partial class CdRecepcionPaquetesForm : Form
    {
        private readonly CdRecepcionPaquetesModelo _svc = new CdRecepcionPaquetesModelo();

        public CdRecepcionPaquetesForm()
        {
            InitializeComponent();
        }

        private void CdRecepcionPaquetesForm_Load(object sender, EventArgs e)
        {
            InitListView();
            InitCajas();
            InitDestino();
            txtCuit.KeyPress += txtCuit_KeyPress;

            cmbModalidad.SelectedIndexChanged += CmbModalidad_SelectedIndexChanged;
            cmbProvincia.SelectedIndexChanged += CmbProvincia_SelectedIndexChanged;
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
            cmbTipoCaja.Items.AddRange(_svc.GetTiposCaja());
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 1000;
            nudCantidad.Value = 1;
        }

        private void InitDestino()
        {
            cmbModalidad.Items.Clear();
            cmbModalidad.Items.AddRange(_svc.GetModalidades());

            cmbProvincia.Items.Clear();
            cmbProvincia.Items.AddRange(_svc.GetProvincias());

            AplicarReglasModalidad();
            CargarDependientes();
        }

        // Buscar cliente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();

            string cuit = CdRecepcionPaquetesModelo.NormalizarCuit(txtCuit.Text);
            if (!CdRecepcionPaquetesModelo.EsCuitBasico(cuit))
            {
                Msg("CUIT inválido. Debe tener 11 dígitos.");
                txtCuit.Focus();
                return;
            }

            var cli = _svc.BuscarClientePorCuit(cuit);
            if (cli == null)
            {
                Msg("No se encontró ningún cliente con ese CUIT.");
                txtCuit.Clear();
                return;
            }

            txtCliente.Text = cli.RazonSocial;
        }

        // Agregar ítem al detalle
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = (cmbTipoCaja.Text ?? "").Trim();
            int qty = (int)nudCantidad.Value;

            if (string.IsNullOrWhiteSpace(tipo))
            {
                Msg("Seleccioná el tipo de caja.");
                cmbTipoCaja.Focus();
                return;
            }
            if (qty <= 0)
            {
                Msg("La cantidad debe ser mayor a cero.");
                nudCantidad.Focus();
                return;
            }

            // buscar si ya existe fila con ese tipo
            ListViewItem existente = null;
            foreach (ListViewItem it in lvDetalle.Items)
            {
                if (string.Equals(it.SubItems[0].Text, tipo, StringComparison.OrdinalIgnoreCase))
                {
                    existente = it;
                    break;
                }
            }

            if (existente != null)
            {
                int actual = 0;
                int.TryParse(existente.SubItems[1].Text, out actual);
                existente.SubItems[1].Text = (actual + qty).ToString();
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

        // Confirmar registro
        private void button3_Click(object sender, EventArgs e)
        {
            var dto = new CdRecepcionPaquetesModelo.RegistroEnvioDto
            {
                Cuit = txtCuit.Text,
                NombreApellido = nombreApellido.Text,
                Dni = dni.Text,
                Telefono = telefono.Text,
                CodigoPostal = codigoPostal.Text,
                Modalidad = cmbModalidad.Text,
                Provincia = cmbProvincia.Text,
                Localidad = txtLocalidad.Text,
                CalleYAltura = txtCalleAltura.Text,
                Agencia = cmbAgencia.Text,
                CD = cmbCD.Text
            };

            List<CdRecepcionPaquetesModelo.DetalleCaja> detalle = ParseDetalle();
            List<string> errores = _svc.Validar(dto, detalle);
            if (errores.Count > 0)
            {
                Msg(string.Join("\n", errores));
                return;
            }

            var guia = _svc.CrearGuia(dto, detalle);
            Msg("Envío registrado correctamente.\nN° de guía: " + guia.NumeroGuia);

            LimpiarControles(this);
            nudCantidad.Value = 1;
            txtCuit.Focus();
            InitCajas();
            InitDestino();
        }

        private List<CdRecepcionPaquetesModelo.DetalleCaja> ParseDetalle()
        {
            var list = new List<CdRecepcionPaquetesModelo.DetalleCaja>();
            foreach (ListViewItem it in lvDetalle.Items)
            {
                TamañoCajaEnum tam;
                int q;
                if (Enum.TryParse<TamañoCajaEnum>(it.SubItems[0].Text.Trim(), true, out tam)
                    && int.TryParse(it.SubItems[1].Text, out q)
                    && q > 0)
                {
                    var d = new CdRecepcionPaquetesModelo.DetalleCaja();
                    d.Tam = tam;
                    d.Qty = q;
                    list.Add(d);
                }
            }
            return list;
        }

        // Dependencias UI
        private void CmbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarReglasModalidad();
        }

        private void CmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDependientes();
        }

        private void AplicarReglasModalidad()
        {
            string modalidad = cmbModalidad.Text;

            bool esDom = modalidad == TipoPuntoEnum.Domicilio.ToString();
            bool esAge = modalidad == TipoPuntoEnum.Agencia.ToString();
            bool esCD = modalidad == TipoPuntoEnum.CD.ToString();

            txtCalleAltura.Enabled = esDom;
            cmbAgencia.Enabled = esAge;
            cmbCD.Enabled = esCD;

            if (!esDom) txtCalleAltura.Clear();
            if (!esAge)
            {
                cmbAgencia.Items.Clear();
                cmbAgencia.SelectedIndex = -1;
                cmbAgencia.Text = "";
            }
            if (!esCD)
            {
                cmbCD.Items.Clear();
                cmbCD.SelectedIndex = -1;
                cmbCD.Text = "";
            }

            CargarDependientes();
        }

        private void CargarDependientes()
        {
            string prov = cmbProvincia.Text;

            cmbAgencia.Items.Clear();
            string[] ags = _svc.GetAgencias(prov);
            if (ags.Length > 0) cmbAgencia.Items.AddRange(ags);

            cmbCD.Items.Clear();
            string[] cds = _svc.GetCDs(prov);
            if (cds.Length > 0) cmbCD.Items.AddRange(cds);
        }

        // Utilitarios UI
        private static void LimpiarControles(Control root)
        {
            foreach (Control c in root.Controls)
            {
                if (c is TextBox) ((TextBox)c).Clear();
                else if (c is ComboBox)
                {
                    var cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                }
                else if (c is NumericUpDown)
                {
                    var nud = (NumericUpDown)c;
                    nud.Value = nud.Minimum;
                }
                else if (c is CheckBox) ((CheckBox)c).Checked = false;
                else if (c is RadioButton) ((RadioButton)c).Checked = false;
                else if (c is ListView) ((ListView)c).Items.Clear();
                else if (c is DataGridView) ((DataGridView)c).Rows.Clear();
                else if (c is DateTimePicker) ((DateTimePicker)c).Value = DateTime.Today;

                if (c.HasChildren) LimpiarControles(c);
            }
        }

        private static void Msg(string m)
        {
            MessageBox.Show(m, "Validación");
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }

        // Stubs Designer
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

        private void button1_Click(object sender, EventArgs e) { btnBuscar_Click(sender, e); }
        private void button2_Click(object sender, EventArgs e) { btnAgregar_Click(sender, e); }
    }
}
