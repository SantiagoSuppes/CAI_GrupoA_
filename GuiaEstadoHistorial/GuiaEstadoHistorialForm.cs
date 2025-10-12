using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.GuiaEstadoHistorial
{
    public partial class GuiaEstadoHistorialForm : Form
    {
        // Modelos
        private sealed class Movimiento
        {
            public DateTime FechaMovimiento { get; init; }
            public string TipoTramo { get; init; } = "";
            public string Estado { get; init; } = "";
            public string Origen { get; init; } = "";
            public string Destino { get; init; } = "";
            public string Quien { get; init; } = "";
        }
        private sealed class Guia
        {
            public string Numero { get; init; } = "";
            public string Cliente { get; init; } = "";
            public string EstadoActual { get; init; } = "";
            public DateTime FechaUltimoMov { get; init; }
            public string TipoCaja { get; init; } = "";
            public string Modalidad { get; init; } = "";
            public string DestinoFinal { get; init; } = "";
            public List<Movimiento> LineaTiempo { get; init; } = new();
        }

        // Datos mock
        private readonly List<Guia> _guias = new()
        {
            new Guia {
                Numero = "AGC01-0001",
                Cliente = "Transporte TUTASA S.A.",
                EstadoActual = "En tránsito",
                FechaUltimoMov = DateTime.Today.AddDays(-1).AddHours(15),
                TipoCaja = "M",
                Modalidad = "Agencia",
                DestinoFinal = "Córdoba",
                LineaTiempo = new List<Movimiento>{
                    new(){FechaMovimiento=DateTime.Today.AddDays(-2).AddHours(22),TipoTramo="Última Milla",    Estado="En Curso",   Origen="CD Cordoba", Destino="Agencia Cordoba", Quien="Fletero"},
                    new(){FechaMovimiento=DateTime.Today.AddDays(-4).AddHours(9), TipoTramo="Larga Distancia",       Estado="Finalizado", Origen="CD Santa Fe",     Destino="CD Cordoba", Quien="Flecha Bus"}
                }
            },
            new Guia {
                Numero = "AGC05-0005",
                Cliente = "Logística Andina SRL",
                EstadoActual = "Entregada",
                FechaUltimoMov = DateTime.Today.AddDays(-3).AddHours(11),
                TipoCaja = "S",
                Modalidad = "Domicilio",
                DestinoFinal = "Rosario",
                LineaTiempo = new List<Movimiento>{
                    new(){FechaMovimiento=DateTime.Today.AddDays(-5).AddHours(20), TipoTramo="Larga Distancia", Estado="Finalizado",    Origen="CD Buenos Aires", Destino="CD Santa Fe",   Quien="Pullman"},
                    new(){FechaMovimiento=DateTime.Today.AddDays(-4).AddHours(9),  TipoTramo="Larga Distancia", Estado="Finalizado",  Origen="CD Santa Fe",     Destino="CD Córdoba",    Quien="Flecha Bus"},
                    new(){FechaMovimiento=DateTime.Today.AddDays(-2).AddHours(22), TipoTramo="Última Milla",    Estado="Finalizado",    Origen="CD Córdoba",      Destino="Agencia Córdoba",Quien="Fletero"},
                    new(){FechaMovimiento=DateTime.Today.AddHours(-3),             TipoTramo="Última Milla",    Estado="En Curso",  Origen="Agencia Córdoba",  Destino="Domicilio",      Quien="Fletero"},
                }
            }
        };

        public GuiaEstadoHistorialForm() { InitializeComponent(); }

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
                listLineaTiempo.Columns.Add("Estado", 110);
                listLineaTiempo.Columns.Add("Origen", 140);
                listLineaTiempo.Columns.Add("Destino", 140);
                listLineaTiempo.Columns.Add("Quién lo realizó", 140);
            }
        }

        // Click: buscar guía
        private void btnBuscarGuia_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();

            var nro = (numeroGuia.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(nro))
            {
                MessageBox.Show("Ingrese el número de guía."); numeroGuia.Focus(); return;
            }

            var g = _guias.FirstOrDefault(x => x.Numero.Equals(nro, StringComparison.OrdinalIgnoreCase));
            if (g == null) { MessageBox.Show("Guía no encontrada."); return; }

            txtCliente.Text = g.Cliente;
            txtEstadoActual.Text = g.EstadoActual;
            var ultimoMov = g.LineaTiempo?.OrderBy(m => m.FechaMovimiento).LastOrDefault();
            txtFechaUltimoMov.Text = ultimoMov != null
                ? ultimoMov.FechaMovimiento.ToString("yyyy-MM-dd HH:mm")
                : string.Empty;

            // opcional: sincronizar estado actual con el último movimiento
            if (ultimoMov != null) txtEstadoActual.Text = ultimoMov.Estado;
            txtTipoCaja.Text = g.TipoCaja;
            txtModalidad.Text = g.Modalidad;
            txtDestino.Text = g.DestinoFinal;

            CargarLineaTiempo(g.LineaTiempo);
        }

        // Helpers
        private void CargarLineaTiempo(IEnumerable<Movimiento> movs)
        {
            foreach (var m in movs.OrderBy(x => x.FechaMovimiento))
            {
                var it = new ListViewItem(m.FechaMovimiento.ToString("yyyy-MM-dd HH:mm"));
                it.SubItems.Add(m.TipoTramo);
                it.SubItems.Add(m.Estado);
                it.SubItems.Add(m.Origen);
                it.SubItems.Add(m.Destino);
                it.SubItems.Add(m.Quien);
                listLineaTiempo.Items.Add(it);
            }
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
