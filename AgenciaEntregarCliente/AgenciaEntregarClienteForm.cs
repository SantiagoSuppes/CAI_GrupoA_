using System;
using System.Collections.Generic;
using System.Data;
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
        }

        private void AgenciaEntregarClienteForm_Load(object sender, EventArgs e)
        {
            // Configuración esperada del ListView
            lvEncomiendas.View = View.Details;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.FullRowSelect = true;
        }

        private void btnBuscarEncomiendaDestinatario_Click_1(object sender, EventArgs e)
        {
            if (!long.TryParse(txtDniDestinatario.Text, out long dni) || dni <= 0)
            {
                MessageBox.Show("El DNI no puede ser negativo o cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Focus();
                return;
            }

            if (!modelo.BuscarEncomiendas(dni))
            {
                return;
            }

            lvEncomiendas.Items.Clear();
            foreach(var guia in modelo.Guias)
            {
                var item = new ListViewItem(guia.NroGuia);
                item.SubItems.Add(guia.Talle);
                item.SubItems.Add(guia.DniDestinatario.ToString());
                item.SubItems.Add(guia.Cuit);
                item.SubItems.Add(guia.Fecha.ToShortDateString());
                item.Tag = guia;
                lvEncomiendas.Items.Add(item);
            }
        }


        private void btnConfirmarEntrega_Click_1(object sender, EventArgs e)
        {
            var itemsSeleccionados = lvEncomiendas.Items
               .Cast<ListViewItem>()
               .Where(it => it.Checked)
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

            var guiasSeleccionadas = itemsSeleccionados.Select(t => t.Tag).Cast<GuiaEnt>().ToList();
            if (!modelo.Entregar(guiasSeleccionadas))
            {
                return;
            }

            foreach (var item in itemsSeleccionados)
            {
                lvEncomiendas.Items.Remove(item);
            }
            

            MessageBox.Show(
                "Se ha completado la entrega al cliente seleccionado",
                "Entrega confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );            
        }
    }
}
