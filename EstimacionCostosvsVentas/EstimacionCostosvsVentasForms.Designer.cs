namespace EstimacioonCostosvsVentas.EstimacionCostosvsVentas
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.InactiveCaption, null);
            this.buttonSalir = new System.Windows.Forms.Button();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.porEmpresaView = new System.Windows.Forms.ListView();
            this.columnEmpresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVenta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCosto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columGanancias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FiltrosBox = new System.Windows.Forms.GroupBox();
            this.GenerarReporbutton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CategoriaGB = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Empresalabel = new System.Windows.Forms.Label();
            this.Periodolabel = new System.Windows.Forms.Label();
            this.FiltrosBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(696, 411);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 9;
            this.buttonSalir.Text = "Salir ";
            this.buttonSalir.UseVisualStyleBackColor = true;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(157, 411);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(75, 23);
            this.buttonImprimir.TabIndex = 8;
            this.buttonImprimir.Text = "Imprimir ";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(29, 411);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(103, 23);
            this.buttonVolver.TabIndex = 7;
            this.buttonVolver.Text = "Volver al menú";
            this.buttonVolver.UseVisualStyleBackColor = true;
            // 
            // porEmpresaView
            // 
            this.porEmpresaView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpresa,
            this.columnVenta,
            this.columnCosto,
            this.columGanancias});
            this.porEmpresaView.FullRowSelect = true;
            this.porEmpresaView.GridLines = true;
            this.porEmpresaView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.porEmpresaView.HideSelection = false;
            this.porEmpresaView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.porEmpresaView.Location = new System.Drawing.Point(29, 154);
            this.porEmpresaView.Name = "porEmpresaView";
            this.porEmpresaView.Scrollable = false;
            this.porEmpresaView.Size = new System.Drawing.Size(742, 238);
            this.porEmpresaView.TabIndex = 6;
            this.porEmpresaView.UseCompatibleStateImageBehavior = false;
            this.porEmpresaView.View = System.Windows.Forms.View.Details;
            // 
            // columnEmpresa
            // 
            this.columnEmpresa.Text = "Empresa";
            this.columnEmpresa.Width = 280;
            // 
            // columnVenta
            // 
            this.columnVenta.Text = "Venta ($)";
            this.columnVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnVenta.Width = 170;
            // 
            // columnCosto
            // 
            this.columnCosto.Text = "Costo($)";
            this.columnCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCosto.Width = 200;
            // 
            // columGanancias
            // 
            this.columGanancias.Text = "Ganancia";
            this.columGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columGanancias.Width = 90;
            // 
            // FiltrosBox
            // 
            this.FiltrosBox.Controls.Add(this.GenerarReporbutton);
            this.FiltrosBox.Controls.Add(this.comboBox1);
            this.FiltrosBox.Controls.Add(this.CategoriaGB);
            this.FiltrosBox.Controls.Add(this.dateTimePicker1);
            this.FiltrosBox.Controls.Add(this.label1);
            this.FiltrosBox.Controls.Add(this.Empresalabel);
            this.FiltrosBox.Controls.Add(this.Periodolabel);
            this.FiltrosBox.Location = new System.Drawing.Point(29, 17);
            this.FiltrosBox.Name = "FiltrosBox";
            this.FiltrosBox.Size = new System.Drawing.Size(742, 122);
            this.FiltrosBox.TabIndex = 5;
            this.FiltrosBox.TabStop = false;
            this.FiltrosBox.Text = "Filtros";
            // 
            // GenerarReporbutton
            // 
            this.GenerarReporbutton.Location = new System.Drawing.Point(623, 84);
            this.GenerarReporbutton.Name = "GenerarReporbutton";
            this.GenerarReporbutton.Size = new System.Drawing.Size(101, 23);
            this.GenerarReporbutton.TabIndex = 6;
            this.GenerarReporbutton.Text = "Generar reporte";
            this.GenerarReporbutton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(397, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // CategoriaGB
            // 
            this.CategoriaGB.FormattingEnabled = true;
            this.CategoriaGB.Location = new System.Drawing.Point(63, 81);
            this.CategoriaGB.Name = "CategoriaGB";
            this.CategoriaGB.Size = new System.Drawing.Size(121, 21);
            this.CategoriaGB.TabIndex = 4;
            this.CategoriaGB.Text = "            -Todas-";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(66, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categoria (Media/Larga):";
            // 
            // Empresalabel
            // 
            this.Empresalabel.AutoSize = true;
            this.Empresalabel.Location = new System.Drawing.Point(6, 84);
            this.Empresalabel.Name = "Empresalabel";
            this.Empresalabel.Size = new System.Drawing.Size(51, 13);
            this.Empresalabel.TabIndex = 1;
            this.Empresalabel.Text = "Empresa:";
            // 
            // Periodolabel
            // 
            this.Periodolabel.AutoSize = true;
            this.Periodolabel.Location = new System.Drawing.Point(6, 32);
            this.Periodolabel.Name = "Periodolabel";
            this.Periodolabel.Size = new System.Drawing.Size(97, 13);
            this.Periodolabel.TabIndex = 0;
            this.Periodolabel.Text = "Periodo (mes/año):";
            // 
            // EstimacionCostosvsVentasForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.porEmpresaView);
            this.Controls.Add(this.FiltrosBox);
            this.Name = "EstimacionCostosvsVentasForms";
            this.Text = "EstimacionCostosvsVentasForms";
            this.FiltrosBox.ResumeLayout(false);
            this.FiltrosBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.ListView porEmpresaView;
        private System.Windows.Forms.ColumnHeader columnEmpresa;
        private System.Windows.Forms.ColumnHeader columnVenta;
        private System.Windows.Forms.ColumnHeader columnCosto;
        private System.Windows.Forms.ColumnHeader columGanancias;
        private System.Windows.Forms.GroupBox FiltrosBox;
        private System.Windows.Forms.Button GenerarReporbutton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox CategoriaGB;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Empresalabel;
        private System.Windows.Forms.Label Periodolabel;
    }
}