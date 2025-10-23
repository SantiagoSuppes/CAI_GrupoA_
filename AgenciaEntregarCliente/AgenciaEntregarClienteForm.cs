using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    public partial class AgenciaEntregarClienteForm : Form
    {
        private readonly AgenciaEntregarClienteModelo modelo = new();

        public AgenciaEntregarClienteForm()
        {
            InitializeComponent();
            Load += AgenciaEntregarClienteForm_Load;
            btnBuscarEncomiendaDestinatario.Click += btnBuscarEncomiendaDestinatario_Click;
            btnConfirmarEntrega.Click += btnConfirmarEntrega_Click;
        }

        private void AgenciaEntregarClienteForm_Load(object sender, EventArgs e)
        {
            ConfigurarLista();
        }

        private void ConfigurarLista()
        {
            lvEncomiendas.View = View.Details;
            lvEncomiendas.FullRowSelect = true;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.GridLines = true;

            lvEncomiendas.Columns.Clear();
            lvEncomiendas.Columns.Add("# Guía", 120);
            lvEncomiendas.Columns.Add("Tamaño", 80);
            lvEncomiendas.Columns.Add("Remitente", 150);
            lvEncomiendas.Columns.Add("Destinatario", 150);
            lvEncomiendas.Columns.Add("Fecha Imposición", 120);
        }

        private void btnBuscarEncomiendaDestinatario_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtDniDestinatario.Text?.Trim(), out long dni) || dni <= 0)
            {
                MessageBox.Show("Ingrese un DNI válido (solo números).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Focus();
                return;
            }

            var guias = modelo.BuscarPorDni(dni);
            if (guias.Count == 0)
            {
                MessageBox.Show("No se encontraron guías para el DNI ingresado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lvEncomiendas.Items.Clear();
            foreach (var g in guias)
                lvEncomiendas.Items.Add(ItemDesdeGuia(g));
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            var seleccionadas = lvEncomiendas.Items.Cast<ListViewItem>()
                .Where(i => i.Checked)
                .Select(i => i.Tag as GuiaAgencia)
                .Where(g => g != null)
                .ToList();

            if (seleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una guía para confirmar la entrega.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modelo.ConfirmarEntrega(seleccionadas);

            foreach (var item in lvEncomiendas.Items.Cast<ListViewItem>().Where(i => i.Checked).ToList())
                lvEncomiendas.Items.Remove(item);

            MessageBox.Show("Entrega confirmada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ListViewItem ItemDesdeGuia(GuiaAgencia g)
        {
            var item = new ListViewItem(g.NumeroGuia);
            item.SubItems.Add(g.TamañoCaja.ToString());
            item.SubItems.Add(g.Remitente);
            item.SubItems.Add(g.Destinatario);
            item.SubItems.Add(g.FechaImposicion.ToShortDateString());
            item.Tag = g;
            return item;
        }
    }
}
