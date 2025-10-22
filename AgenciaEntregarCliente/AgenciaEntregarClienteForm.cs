using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;                 // <-- Usa tus entidades reales
using CAI_GrupoA_.AgenciaEntregarCliente;    // <-- Usa tu modelo

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
            // Configuración del ListView
            lvEncomiendas.View = View.Details;
            lvEncomiendas.FullRowSelect = true;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.Columns.Clear();
            lvEncomiendas.Columns.Add("# Guía", 120);
            lvEncomiendas.Columns.Add("Tamaño", 80);
            lvEncomiendas.Columns.Add("Destino (Tipo)", 120);
            lvEncomiendas.Columns.Add("Localidad / CP", 150);
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

            // El modelo valida rango (8 a 10 dígitos) y ya muestra el mensaje si es inválido
            if (!modelo.BuscarEncomiendas(dni))
                return;

            // Poblar la grilla
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
                .Select(i => i.Tag as GuiaEnt)
                .Where(g => g != null)
                .ToList();

            if (!modelo.Entregar(guiasSeleccionadas))
                return;

            // Quitar SOLO los seleccionados
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

        // ---------------------------
        // Helper de mapeo a ListView
        // ---------------------------
        private ListViewItem ItemFromGuia(GuiaEnt g)
        {
            string tipoDestino = g.Destino?.TipoPunto.ToString() ?? "(s/d)";
            string locCp = $"{g.Destino?.Localidad ?? "(s/d)"} / CP {((g.Destino?.CodigoPostal > 0) ? g.Destino.CodigoPostal.ToString() : "(s/d)")}";
            string fecha = g.FechaImposicion.ToShortDateString();

            var item = new ListViewItem(g.NumeroGuia ?? "(sin nro)");
            item.SubItems.Add(g.TamañoCaja.ToString());
            item.SubItems.Add(tipoDestino);
            item.SubItems.Add(locCp);
            item.SubItems.Add(fecha);
            item.Tag = g; // Para recuperar la entidad al confirmar
            return item;
        }
    }
}
