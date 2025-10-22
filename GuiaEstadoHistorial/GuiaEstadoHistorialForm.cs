// Archivo: GuiaEstadoHistorial/GuiaEstadoHistorialForm.cs
using System;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.GuiaEstadoHistorial
{
    public partial class GuiaEstadoHistorialForm : Form
    {
        private readonly GuiaEstadoHistorialModelo _modelo = new GuiaEstadoHistorialModelo();

        public GuiaEstadoHistorialForm()
        {
            InitializeComponent();
        }

        // Load: configurar ListView
        private void guiaEstadoHistorialForm_Load(object sender, EventArgs e)
        {
            listLineaTiempo.View = View.Details;
            listLineaTiempo.FullRowSelect = true;
            listLineaTiempo.GridLines = true;
            if (listLineaTiempo.Columns.Count == 0)
            {
                listLineaTiempo.Columns.Add("Fecha Movimiento", 150);
                listLineaTiempo.Columns.Add("Tipo Tramo", 110);
                listLineaTiempo.Columns.Add("Estado", 140);
                listLineaTiempo.Columns.Add("Origen", 140);
                listLineaTiempo.Columns.Add("Destino", 140);
                listLineaTiempo.Columns.Add("Quién lo realizó", 140);
            }
        }

        // Click: buscar guía
        private void btnBuscarGuia_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();

            string nro = (numeroGuia.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(nro))
            {
                MessageBox.Show("Ingrese el número de guía.");
                numeroGuia.Focus();
                return;
            }

            var res = _modelo.BuscarPorNumero(nro);
            if (res == null)
            {
                MessageBox.Show("Guía no encontrada.");
                return;
            }

            txtCliente.Text = res.Cliente;
            txtEstadoActual.Text = res.EstadoActualTexto;
            txtFechaUltimoMov.Text = res.FechaUltimoMov.HasValue ? res.FechaUltimoMov.Value.ToString("yyyy-MM-dd HH:mm") : "";
            txtTipoCaja.Text = res.TipoCajaTexto;
            txtModalidad.Text = res.ModalidadTexto;
            txtDestino.Text = res.DestinoFinalTexto;

            CargarLineaTiempo(res.Movimientos);
        }

        // Helpers
        private void CargarLineaTiempo(System.Collections.Generic.List<MovimientoGuiaEnt> movs)
        {
            if (movs == null || movs.Count == 0) return;

            for (int i = 0; i < movs.Count; i++)
            {
                var m = movs[i];
                var it = new ListViewItem(m.Fecha.ToString("yyyy-MM-dd HH:mm"));
                it.SubItems.Add(m.TipoTramo.ToString());
                it.SubItems.Add(m.Estado.ToString());
                it.SubItems.Add(m.Origen != null ? m.Origen.Localidad : "");
                it.SubItems.Add(m.Destino != null ? m.Destino.Localidad : "");
                it.SubItems.Add(CalcularQuien(m));
                listLineaTiempo.Items.Add(it);
            }
        }

        private string CalcularQuien(MovimientoGuiaEnt m)
        {
            // Regla simple para demo
            if (m.TipoTramo == TipoTramoEnum.UltimaMilla) return "Fletero";
            if (m.TipoTramo == TipoTramoEnum.LargaDistancia) return "Transportista";
            return "Sistema";
        }

        private void LimpiarDetalle()
        {
            txtCliente.Clear();
            txtEstadoActual.Clear();
            txtFechaUltimoMov.Clear();
            txtTipoCaja.Clear();
            txtModalidad.Clear();
            txtDestino.Clear();
            listLineaTiempo.Items.Clear();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}
