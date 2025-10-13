using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    public partial class EstimacionCostosvsVentasForms : Form
    {
        // Controles esperados en el diseñador:
        // dtpPeriodo (DateTimePicker), cmbEmpresa (ComboBox), cmbCategoria (ComboBox)
        // btnFiltrar (Button), dgvResultados (ListView), btnGenerarReporte (Button)

        private sealed class Registro
        {
            public DateTime Fecha { get; init; }
            public string Empresa { get; init; } = "";
            public string Categoria { get; init; } = ""; // "Ultima Milla" | "Larga Distancia"
            public decimal Venta { get; init; }
            public decimal Costo { get; init; }
        }

        private void Empresalabel_Click(object sender, EventArgs e) { }

        private readonly List<Registro> _datos = new()
        {
            new(){Fecha=new DateTime(2025,10,01), Empresa="Transporte Andino S.A",     Categoria="Larga Distancia", Venta=120000, Costo= 90000},
            new(){Fecha=new DateTime(2025,10,10), Empresa="Transporte Andino S.A",     Categoria="Ultima Milla",    Venta= 80000, Costo= 56000},
            new(){Fecha=new DateTime(2025,10,05), Empresa="Distribuidora Córdoba SRL", Categoria="Larga Distancia", Venta= 60000, Costo= 42000},
            new(){Fecha=new DateTime(2025,10,15), Empresa="Logística del Litoral S.A", Categoria="Ultima Milla",    Venta=100000, Costo= 70000},
            new(){Fecha=new DateTime(2025,10,21), Empresa="Logística del Litoral S.A", Categoria="Larga Distancia", Venta= 40000, Costo= 26000},
        };

        private bool _mostrandoPopup;

        public EstimacionCostosvsVentasForms()
        {
            InitializeComponent();
            Load += EstimacionCostosvsVentasForms_Load;
            btnFiltrar.Click += btnFiltrar_Click;
        }

        private void EstimacionCostosvsVentasForms_Load(object sender, EventArgs e)
        {
            // Periodo
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MM/yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Empresa
            cmbEmpresa.Items.Clear();
            cmbEmpresa.Items.Add("(Todas)");
            foreach (var emp in _datos.Select(d => d.Empresa).Distinct().OrderBy(x => x))
                cmbEmpresa.Items.Add(emp);
            cmbEmpresa.SelectedIndex = 0;

            // Categoría
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new object[] { "(Todas)", "Ultima Milla", "Larga Distancia" });
            cmbCategoria.SelectedIndex = 0;

            // ListView como grilla
            ConfigurarLista();

            // Evitar que Generar dispare con Enter
            AcceptButton = btnFiltrar;                 // o null
            btnGenerarReporte.DialogResult = DialogResult.None;

            // Carga inicial
            btnFiltrar_Click(null, EventArgs.Empty);
        }

        private void ConfigurarLista()
        {
            dgvResultados.View = View.Details;
            dgvResultados.FullRowSelect = true;
            dgvResultados.GridLines = true;
            dgvResultados.Columns.Clear();
            dgvResultados.Columns.Add(new ColumnHeader { Text = "Empresa", Width = 280 });
            dgvResultados.Columns.Add(new ColumnHeader { Text = "Venta ($)", Width = 120, TextAlign = HorizontalAlignment.Right });
            dgvResultados.Columns.Add(new ColumnHeader { Text = "Costo ($)", Width = 120, TextAlign = HorizontalAlignment.Right });
            dgvResultados.Columns.Add(new ColumnHeader { Text = "Ganancia", Width = 120, TextAlign = HorizontalAlignment.Right });
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var periodo = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            var empresaSel = cmbEmpresa.Text;
            var categoriaSel = cmbCategoria.Text;

            var q = _datos.Where(d => d.Fecha.Year == periodo.Year && d.Fecha.Month == periodo.Month);
            if (empresaSel != "(Todas)") q = q.Where(d => d.Empresa == empresaSel);
            if (categoriaSel != "(Todas)") q = q.Where(d => d.Categoria == categoriaSel);

            var resumen = q
                .GroupBy(d => d.Empresa)
                .Select(g => new
                {
                    Empresa = g.Key,
                    Venta = g.Sum(x => x.Venta),
                    Costo = g.Sum(x => x.Costo),
                    Ganancia = g.Sum(x => x.Venta - x.Costo)
                })
                .OrderBy(r => r.Empresa)
                .ToList();

            dgvResultados.Items.Clear();
            foreach (var r in resumen)
            {
                var it = new ListViewItem(r.Empresa);
                it.SubItems.Add(r.Venta.ToString("N2"));
                it.SubItems.Add(r.Costo.ToString("N2"));
                it.SubItems.Add(r.Ganancia.ToString("N2"));
                dgvResultados.Items.Add(it);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (_mostrandoPopup) return;
            _mostrandoPopup = true;
            try
            {
                if (dgvResultados.Items.Count == 0)
                {
                    MessageBox.Show(this, "No hay datos para generar el reporte.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(this, "Reporte Generado Correctamente", "Reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                _mostrandoPopup = false;
            }
        }

        private void EstimacionCostosvsVentasForms_Load_1(object sender, EventArgs e)
        {

        }
    }
}
