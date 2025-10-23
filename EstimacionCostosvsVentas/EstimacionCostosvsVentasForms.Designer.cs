using System.Drawing;
using System.Windows.Forms;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    partial class EstimacionCostosvsVentasForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvResultados = new ListView();
            columnEmpresa = new ColumnHeader();
            columnVenta = new ColumnHeader();
            columnCosto = new ColumnHeader();
            columnGanancia = new ColumnHeader();
            FiltrosBox = new GroupBox();
            btnFiltrar = new Button();
            cmbCategoria = new ComboBox();
            cmbEmpresa = new ComboBox();
            dtpPeriodo = new DateTimePicker();
            labelCategoria = new Label();
            labelEmpresa = new Label();
            labelPeriodo = new Label();
            btnGenerarReporte = new Button();
            labelTitulo = new Label();
            FiltrosBox.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResultados
            // 
            dgvResultados.Columns.AddRange(new ColumnHeader[] { columnEmpresa, columnVenta, columnCosto, columnGanancia });
            dgvResultados.FullRowSelect = true;
            dgvResultados.GridLines = true;
            dgvResultados.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            dgvResultados.Location = new Point(34, 165);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(746, 257);
            dgvResultados.TabIndex = 6;
            dgvResultados.UseCompatibleStateImageBehavior = false;
            dgvResultados.View = View.Details;
            // 
            // columnEmpresa
            // 
            columnEmpresa.Text = "Empresa";
            columnEmpresa.Width = 280;
            // 
            // columnVenta
            // 
            columnVenta.Text = "Venta ($)";
            columnVenta.TextAlign = HorizontalAlignment.Right;
            columnVenta.Width = 120;
            // 
            // columnCosto
            // 
            columnCosto.Text = "Costo ($)";
            columnCosto.TextAlign = HorizontalAlignment.Right;
            columnCosto.Width = 120;
            // 
            // columnGanancia
            // 
            columnGanancia.Text = "Ganancia";
            columnGanancia.TextAlign = HorizontalAlignment.Right;
            columnGanancia.Width = 120;
            // 
            // FiltrosBox
            // 
            FiltrosBox.Controls.Add(btnFiltrar);
            FiltrosBox.Controls.Add(cmbCategoria);
            FiltrosBox.Controls.Add(cmbEmpresa);
            FiltrosBox.Controls.Add(dtpPeriodo);
            FiltrosBox.Controls.Add(labelCategoria);
            FiltrosBox.Controls.Add(labelEmpresa);
            FiltrosBox.Controls.Add(labelPeriodo);
            FiltrosBox.Location = new Point(34, 60);
            FiltrosBox.Name = "FiltrosBox";
            FiltrosBox.Size = new Size(746, 84);
            FiltrosBox.TabIndex = 5;
            FiltrosBox.TabStop = false;
            FiltrosBox.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(595, 28);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(125, 27);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "(Todas)", "Última Milla", "Larga Distancia" });
            cmbCategoria.Location = new Point(445, 30);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(127, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(230, 30);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(126, 23);
            cmbEmpresa.TabIndex = 4;
            // 
            // dtpPeriodo
            // 
            dtpPeriodo.CustomFormat = "MM/yyyy";
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.Location = new Point(77, 31);
            dtpPeriodo.Name = "dtpPeriodo";
            dtpPeriodo.Size = new Size(76, 23);
            dtpPeriodo.TabIndex = 3;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(375, 34);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(64, 15);
            labelCategoria.TabIndex = 2;
            labelCategoria.Text = "Categoría:";
            // 
            // labelEmpresa
            // 
            labelEmpresa.AutoSize = true;
            labelEmpresa.Location = new Point(172, 34);
            labelEmpresa.Name = "labelEmpresa";
            labelEmpresa.Size = new Size(55, 15);
            labelEmpresa.TabIndex = 1;
            labelEmpresa.Text = "Empresa:";
            // 
            // labelPeriodo
            // 
            labelPeriodo.AutoSize = true;
            labelPeriodo.Location = new Point(18, 34);
            labelPeriodo.Name = "labelPeriodo";
            labelPeriodo.Size = new Size(51, 15);
            labelPeriodo.TabIndex = 0;
            labelPeriodo.Text = "Periodo:";
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(655, 435);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(125, 27);
            btnGenerarReporte.TabIndex = 7;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(34, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(313, 30);
            labelTitulo.TabIndex = 8;
            labelTitulo.Text = "📊 Reporte de Costos y Ventas";
            // 
            // EstimacionCostosvsVentasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(816, 486);
            Controls.Add(labelTitulo);
            Controls.Add(btnGenerarReporte);
            Controls.Add(dgvResultados);
            Controls.Add(FiltrosBox);
            Name = "EstimacionCostosvsVentasForm";
            Text = "Estimación de Costos vs Ventas";
            FiltrosBox.ResumeLayout(false);
            FiltrosBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView dgvResultados;
        private ColumnHeader columnEmpresa;
        private ColumnHeader columnVenta;
        private ColumnHeader columnCosto;
        private ColumnHeader columnGanancia;
        private GroupBox FiltrosBox;
        private Button btnFiltrar;
        private ComboBox cmbCategoria;
        private ComboBox cmbEmpresa;
        private DateTimePicker dtpPeriodo;
        private Label labelCategoria;
        private Label labelEmpresa;
        private Label labelPeriodo;
        private Button btnGenerarReporte;
        private Label labelTitulo;
    }
}
