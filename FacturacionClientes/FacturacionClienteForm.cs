using System;
using System.Windows.Forms;

namespace CAI_GrupoA_.FacturacionClientes
{
    public partial class FacturacionClienteForm : Form
    {
        private readonly FacturacionClienteModelo modelo = new();

        public FacturacionClienteForm() 
        {
            InitializeComponent();
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {
            string cuitIngresado = txtCUIT.Text.Trim();

            lstGuiasCliente.Items.Clear();
            txtRazonSocial.Clear();
            txtDomicilio.Clear();
            txtIVA.Clear();
            txtMontoTotal.Text = "$ 0,00";

            if (!modelo.ValidarCuit(cuitIngresado))
                return;

            var cliente = modelo.BuscarCliente(cuitIngresado);

            txtRazonSocial.Text = cliente.RazonSocial;
            txtDomicilio.Text = cliente.DomicilioFiscal;
            txtIVA.Text = cliente.CondicionIVA.ToString();

            foreach (var guia in modelo.GuiasCliente)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Fecha.ToShortDateString());
                item.SubItems.Add("$ 3500,00");
                lstGuiasCliente.Items.Add(item);
            }

            txtMontoTotal.Text = "$ " + modelo.CalcularTotal().ToString("N2");
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (lstGuiasCliente.Items.Count == 0)
            {
                MessageBox.Show("No hay guías cargadas para facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMontoTotal.Text == "$ 0,00")
            {
                MessageBox.Show("No hay monto a facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Desea generar la factura?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                //modelo.GenerarFactura();
                MessageBox.Show("Factura generada y enviada al cliente correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstGuiasCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}