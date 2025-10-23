using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAI_GrupoA_.AgenciaEntregarCliente;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    public partial class AgenciaEntregarClienteForm : Form
    {
        private readonly AgenciaEntregarClienteModelo modelo = new();

        public AgenciaEntregarClienteForm()
        {
            InitializeComponent();
        }

        private void AgenciaEntregarClienteForm_Load(object sender, EventArgs e)
        {
            
            lvEncomiendas.View = View.Details;
            lvEncomiendas.FullRowSelect = true;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.Columns.Clear();
            lvEncomiendas.Columns.Add("# Guía", 120);
            lvEncomiendas.Columns.Add("Tamaño", 80);
            lvEncomiendas.Columns.Add("Remitente", 150);
            lvEncomiendas.Columns.Add("Destinatario", 150);
            lvEncomiendas.Columns.Add("Fecha Imposición", 120);
        }

        private void btnBuscarEncomiendaDestinatario_Click_1(object sender, EventArgs e)
        {
            if (!long.TryParse(txtDniDestinatario.Text?.Trim(), out long dni) || dni <= 0)
            {
                MessageBox.Show("Ingrese un DNI válido (solo números).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Focus();
                return;
            }

            if (!modelo.BuscarEncomiendas(dni))
                return;

           
            lvEncomiendas.Items.Clear();
            foreach (var guia in modelo.Guias)
            {
                lvEncomiendas.Items.Add(ItemFromGuia(guia));
            }
        }

        private void btnConfirmarEntrega_Click_1(object sender, EventArgs e)
        {
            var itemsSeleccionados = lvEncomiendas.Items
                .Cast<ListViewItem>()
                .Where(i => i.Checked)
                .ToList();

            if (itemsSeleccionados.Count == 0)
            {
                MessageBox.Show(
                    "No puede confirmar una entrega sin haber seleccionado ninguna guía",
                    "Operación inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var guiasSeleccionadas = itemsSeleccionados
                .Select(i => i.Tag as Guia)
                .Where(g => g != null)
                .ToList();

            if (!modelo.Entregar(guiasSeleccionadas))
                return;

            foreach (var item in itemsSeleccionados)
                lvEncomiendas.Items.Remove(item);

            MessageBox.Show(
                "Se ha completado la entrega al cliente seleccionado",
                "Entrega confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private ListViewItem ItemFromGuia(Guia g)
        {
            var item = new ListViewItem(g.NumeroGuia ?? "(sin nro)");
            item.SubItems.Add(g.TamañoCaja.ToString());
            item.SubItems.Add(g.Remitente ?? "(s/d)");
            item.SubItems.Add(g.Destinatario ?? "(s/d)");
            item.SubItems.Add(g.FechaImposicion.ToShortDateString());
            item.Tag = g;
            return item;
        }

        private void lvEncomiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
