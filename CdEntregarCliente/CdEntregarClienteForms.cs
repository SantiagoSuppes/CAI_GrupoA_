using System;
using System.Linq;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;           // Entidades tipadas (GuiaEnt, DireccionEnt, enums)
using CAI_GrupoA_.CdEntregarCliente;   // Tu modelo

namespace CAI_GrupoA_.CdEntregarCliente
{
    public partial class CdEntregarClienteForms : Form
    {
        private readonly CdEntregarClienteModelo _modelo = new();

        public CdEntregarClienteForms()
        {
            InitializeComponent();
        }

        private void CdEntregarClienteForms_Load(object sender, EventArgs e)
        {
            // ListView de guías
            lvEncomiendas.View = View.Details;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.FullRowSelect = true;
            lvEncomiendas.GridLines = true;

            lvEncomiendas.Columns.Clear();
            lvEncomiendas.Columns.Add("# Guía", 110);
            lvEncomiendas.Columns.Add("Tamaño", 80);
            lvEncomiendas.Columns.Add("Destino (Tipo)", 120);
            lvEncomiendas.Columns.Add("Localidad / CP", 160);
            lvEncomiendas.Columns.Add("Fecha Imposición", 120);
        }

        private void btnBuscarEncomiendaDestinatario_Click(object sender, EventArgs e)
        {
            var raw = (txtDniDestinatario.Text ?? "").Trim();

            // Validación básica local (numérico > 0). El modelo valida largo (8–10) y muestra mensaje si no cumple.
            if (!long.TryParse(raw, out var dni) || dni <= 0)
            {
                MessageBox.Show("Ingrese un DNI válido (solo números).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDniDestinatario.Focus();
                return;
            }

            // Consulta al modelo (puede mostrar su propio mensaje si el rango no es válido)
            if (!_modelo.BuscarEncomiendas(dni))
                return;

            // Poblar la lista con las guías devueltas por el modelo
            lvEncomiendas.Items.Clear();
            foreach (var g in _modelo.Guias)
            {
                lvEncomiendas.Items.Add(ItemFromGuia(g));
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
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

            if (!_modelo.Entregar(guiasSeleccionadas))
                return;

            // Quitar SOLO los seleccionados, tal como pediste
            foreach (var it in itemsSeleccionados)
                lvEncomiendas.Items.Remove(it);

            MessageBox.Show(
                "Se ha completado la entrega al cliente seleccionado",
                "Entrega confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        //hola
        // -------- Helper de mapeo a ListView --------
        private ListViewItem ItemFromGuia(GuiaEnt g)
        {
            string tipoDestino = g.Destino?.TipoPunto.ToString() ?? "(s/d)";
            string loc = g.Destino?.Localidad ?? "(s/d)";
            string cp = (g.Destino?.CodigoPostal > 0) ? g.Destino.CodigoPostal.ToString() : "(s/d)";
            string locCp = $"{loc} / CP {cp}";
            string fecha = g.FechaImposicion.ToShortDateString();

            var item = new ListViewItem(g.NumeroGuia ?? "(sin nro)");
            item.SubItems.Add(g.TamañoCaja.ToString());
            item.SubItems.Add(tipoDestino);
            item.SubItems.Add(locCp);
            item.SubItems.Add(fecha);
            item.Tag = g; // mantiene la entidad para confirmar entrega

            return item;
        }
    }
}
