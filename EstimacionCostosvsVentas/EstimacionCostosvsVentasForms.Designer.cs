namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    partial class EstimacionCostosvsVentasForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem4 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem5 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem6 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem7 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem8 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem9 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem10 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem11 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            ListViewItem listViewItem12 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.InactiveCaption, null);
            dgvResultados = new ListView();
            columnEmpresa = new ColumnHeader();
            columnVenta = new ColumnHeader();
            columnCosto = new ColumnHeader();
            columGanancias = new ColumnHeader();
            FiltrosBox = new GroupBox();
            btnFiltrar = new Button();
            cmbCategoria = new ComboBox();
            cmbEmpresa = new ComboBox();
            dtpPeriodo = new DateTimePicker();
            label1 = new Label();
            empresa = new Label();
            Periodolabel = new Label();
            btnGenerarReporte = new Button();
            FiltrosBox.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResultados
            // 
            dgvResultados.Columns.AddRange(new ColumnHeader[] { columnEmpresa, columnVenta, columnCosto, columGanancias });
            dgvResultados.FullRowSelect = true;
            dgvResultados.GridLines = true;
            dgvResultados.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            dgvResultados.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10, listViewItem11, listViewItem12 });
            dgvResultados.Location = new Point(34, 125);
            dgvResultados.Margin = new Padding(4, 3, 4, 3);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Scrollable = false;
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
            columnVenta.TextAlign = HorizontalAlignment.Center;
            columnVenta.Width = 170;
            // 
            // columnCosto
            // 
            columnCosto.Text = "Costo($)";
            columnCosto.TextAlign = HorizontalAlignment.Center;
            columnCosto.Width = 200;
            // 
            // columGanancias
            // 
            columGanancias.Text = "Ganancia";
            columGanancias.TextAlign = HorizontalAlignment.Center;
            columGanancias.Width = 90;
            // 
            // FiltrosBox
            // 
            FiltrosBox.Controls.Add(btnFiltrar);
            FiltrosBox.Controls.Add(cmbCategoria);
            FiltrosBox.Controls.Add(cmbEmpresa);
            FiltrosBox.Controls.Add(dtpPeriodo);
            FiltrosBox.Controls.Add(label1);
            FiltrosBox.Controls.Add(empresa);
            FiltrosBox.Controls.Add(Periodolabel);
            FiltrosBox.Location = new Point(34, 20);
            FiltrosBox.Margin = new Padding(4, 3, 4, 3);
            FiltrosBox.Name = "FiltrosBox";
            FiltrosBox.Padding = new Padding(4, 3, 4, 3);
            FiltrosBox.Size = new Size(746, 84);
            FiltrosBox.TabIndex = 5;
            FiltrosBox.TabStop = false;
            FiltrosBox.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(595, 28);
            btnFiltrar.Margin = new Padding(4, 3, 4, 3);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(125, 27);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Larga distancia", "Ultima milla" });
            cmbCategoria.Location = new Point(445, 30);
            cmbCategoria.Margin = new Padding(4, 3, 4, 3);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(127, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(230, 30);
            cmbEmpresa.Margin = new Padding(4, 3, 4, 3);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(126, 23);
            cmbEmpresa.TabIndex = 4;
            // 
            // dtpPeriodo
            // 
            dtpPeriodo.CustomFormat = "MM/yyyy";
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.Location = new Point(77, 31);
            dtpPeriodo.Margin = new Padding(4, 3, 4, 3);
            dtpPeriodo.Name = "dtpPeriodo";
            dtpPeriodo.Size = new Size(76, 23);
            dtpPeriodo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(375, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 2;
            label1.Text = "Categoria:";
            // 
            // empresa
            // 
            empresa.AutoSize = true;
            empresa.Location = new Point(172, 34);
            empresa.Margin = new Padding(4, 0, 4, 0);
            empresa.Name = "empresa";
            empresa.Size = new Size(55, 15);
            empresa.TabIndex = 1;
            empresa.Text = "Empresa:";
            empresa.Click += Empresalabel_Click;
            // 
            // Periodolabel
            // 
            Periodolabel.AutoSize = true;
            Periodolabel.Location = new Point(18, 34);
            Periodolabel.Margin = new Padding(4, 0, 4, 0);
            Periodolabel.Name = "Periodolabel";
            Periodolabel.Size = new Size(51, 15);
            Periodolabel.TabIndex = 0;
            Periodolabel.Text = "Periodo:";
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(629, 402);
            btnGenerarReporte.Margin = new Padding(4, 3, 4, 3);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(125, 27);
            btnGenerarReporte.TabIndex = 7;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // EstimacionCostosvsVentasForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(816, 453);
            Controls.Add(btnGenerarReporte);
            Controls.Add(dgvResultados);
            Controls.Add(FiltrosBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EstimacionCostosvsVentasForms";
            Text = "EstimacionCostosvsVentasForms";
            FiltrosBox.ResumeLayout(false);
            FiltrosBox.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView dgvResultados;
        private System.Windows.Forms.ColumnHeader columnEmpresa;
        private System.Windows.Forms.ColumnHeader columnVenta;
        private System.Windows.Forms.ColumnHeader columnCosto;
        private System.Windows.Forms.ColumnHeader columGanancias;
        private System.Windows.Forms.GroupBox FiltrosBox;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label empresa;
        private System.Windows.Forms.Label Periodolabel;
        private Button btnGenerarReporte;
    }
}