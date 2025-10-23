using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    public partial class EstimacionCostosvsVentasForm : Form
    {
        private readonly EstimacionCostosvsVentasModelo modelo = new();
        private bool _mostrandoPopup;

        public EstimacionCostosvsVentasForm()
        {
            InitializeComponent();
            Load += EstimacionCostosvsVentasForm_Load;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnGenerarReporte.Click += BtnGenerarReporte_Click;
        }

        private void EstimacionCostosvsVentasForm_Load(object sender, EventArgs e)
        {
            // Configurar periodo
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MM/yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Empresa
            cmbEmpresa.Items.Clear();
            cmbEmpresa.Items.AddRange(modelo.ObtenerEmpresas().ToArray());
            cmbEmpresa.SelectedIndex = 0;

            // Categoría
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(modelo.ObtenerCategorias().ToArray());
            cmbCategoria.SelectedIndex = 0;

            // Cargar lista inicial
            BtnFiltrar_Click(null, EventArgs.Empty);
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            var periodo = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            var empresa = cmbEmpresa.Text;
            var categoria = cmbCategoria.Text;

            var resumen = modelo.Filtrar(periodo, empresa, categoria);

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

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
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

                MessageBox.Show(this, "Reporte generado correctamente.", "Reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                _mostrandoPopup = false;
            }
        }
    }
}
