namespace CAI_GrupoA_.FacturacionClientes
{
    partial class FacturacionClienteForm
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
            lblFacturacion = new Label();
            lblCUIT = new Label();
            lblRazonSocial = new Label();
            lblDomicilioFiscal = new Label();
            lblIVA = new Label();
            txtCUIT = new TextBox();
            txtDomicilio = new TextBox();
            txtIVA = new TextBox();
            txtRazonSocial = new TextBox();
            btmBuscar = new Button();
            lstGuiasCliente = new ListView();
            colGuia = new ColumnHeader();
            colFecha = new ColumnHeader();
            colImporte = new ColumnHeader();
            lblMontoTotal = new Label();
            txtMontoTotal = new TextBox();
            btnGenerarFactura = new Button();
            btnVolverMenu = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            SuspendLayout();
            // 
            // lblFacturacion
            // 
            lblFacturacion.AutoSize = true;
            lblFacturacion.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFacturacion.Location = new Point(265, 59);
            lblFacturacion.Margin = new Padding(4, 0, 4, 0);
            lblFacturacion.Name = "lblFacturacion";
            lblFacturacion.Size = new Size(200, 30);
            lblFacturacion.TabIndex = 0;
            lblFacturacion.Text = "Facturación Cliente";
            // 
            // lblCUIT
            // 
            lblCUIT.AutoSize = true;
            lblCUIT.Location = new Point(75, 153);
            lblCUIT.Margin = new Padding(4, 0, 4, 0);
            lblCUIT.Name = "lblCUIT";
            lblCUIT.Size = new Size(95, 15);
            lblCUIT.TabIndex = 1;
            lblCUIT.Text = "CUIT del Cliente:";
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Location = new Point(426, 127);
            lblRazonSocial.Margin = new Padding(4, 0, 4, 0);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(76, 15);
            lblRazonSocial.TabIndex = 2;
            lblRazonSocial.Text = "Razón Social:";
            // 
            // lblDomicilioFiscal
            // 
            lblDomicilioFiscal.AutoSize = true;
            lblDomicilioFiscal.Location = new Point(426, 153);
            lblDomicilioFiscal.Margin = new Padding(4, 0, 4, 0);
            lblDomicilioFiscal.Name = "lblDomicilioFiscal";
            lblDomicilioFiscal.Size = new Size(93, 15);
            lblDomicilioFiscal.TabIndex = 3;
            lblDomicilioFiscal.Text = "Domicilio Fiscal:";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(426, 181);
            lblIVA.Margin = new Padding(4, 0, 4, 0);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(128, 15);
            lblIVA.TabIndex = 4;
            lblIVA.Text = "Condición frente a IVA:";
            // 
            // txtCUIT
            // 
            txtCUIT.Location = new Point(178, 150);
            txtCUIT.Margin = new Padding(4, 3, 4, 3);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(142, 23);
            txtCUIT.TabIndex = 5;
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(528, 145);
            txtDomicilio.Margin = new Padding(4, 3, 4, 3);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.ReadOnly = true;
            txtDomicilio.Size = new Size(172, 23);
            txtDomicilio.TabIndex = 6;
            // 
            // txtIVA
            // 
            txtIVA.Location = new Point(568, 173);
            txtIVA.Margin = new Padding(4, 3, 4, 3);
            txtIVA.Name = "txtIVA";
            txtIVA.ReadOnly = true;
            txtIVA.Size = new Size(132, 23);
            txtIVA.TabIndex = 7;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(518, 119);
            txtRazonSocial.Margin = new Padding(4, 3, 4, 3);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.ReadOnly = true;
            txtRazonSocial.Size = new Size(182, 23);
            txtRazonSocial.TabIndex = 8;
            // 
            // btmBuscar
            // 
            btmBuscar.Location = new Point(328, 150);
            btmBuscar.Margin = new Padding(4, 3, 4, 3);
            btmBuscar.Name = "btmBuscar";
            btmBuscar.Size = new Size(88, 27);
            btmBuscar.TabIndex = 9;
            btmBuscar.Text = "Buscar";
            btmBuscar.UseVisualStyleBackColor = true;
            btmBuscar.Click += btmBuscar_Click;
            // 
            // lstGuiasCliente
            // 
            lstGuiasCliente.Columns.AddRange(new ColumnHeader[] { colGuia, colFecha, colImporte });
            lstGuiasCliente.FullRowSelect = true;
            lstGuiasCliente.GridLines = true;
            lstGuiasCliente.Location = new Point(203, 246);
            lstGuiasCliente.Margin = new Padding(4, 3, 4, 3);
            lstGuiasCliente.Name = "lstGuiasCliente";
            lstGuiasCliente.Size = new Size(354, 138);
            lstGuiasCliente.TabIndex = 10;
            lstGuiasCliente.UseCompatibleStateImageBehavior = false;
            lstGuiasCliente.View = View.Details;
            lstGuiasCliente.SelectedIndexChanged += lstGuiasCliente_SelectedIndexChanged;
            // 
            // colGuia
            // 
            colGuia.Text = "Guía #";
            colGuia.Width = 100;
            // 
            // colFecha
            // 
            colFecha.Text = "Fecha";
            colFecha.Width = 100;
            // 
            // colImporte
            // 
            colImporte.Text = "Importe";
            colImporte.Width = 100;
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Location = new Point(250, 400);
            lblMontoTotal.Margin = new Padding(4, 0, 4, 0);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(126, 15);
            lblMontoTotal.TabIndex = 11;
            lblMontoTotal.Text = "Monto total a facturar:";
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Location = new Point(386, 392);
            txtMontoTotal.Margin = new Padding(4, 3, 4, 3);
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.ReadOnly = true;
            txtMontoTotal.Size = new Size(116, 23);
            txtMontoTotal.TabIndex = 12;
            txtMontoTotal.Text = "$ 0,00";
            // 
            // btnGenerarFactura
            // 
            btnGenerarFactura.Location = new Point(198, 457);
            btnGenerarFactura.Margin = new Padding(4, 3, 4, 3);
            btnGenerarFactura.Name = "btnGenerarFactura";
            btnGenerarFactura.Size = new Size(128, 27);
            btnGenerarFactura.TabIndex = 13;
            btnGenerarFactura.Text = "Generar Factura";
            btnGenerarFactura.UseVisualStyleBackColor = true;
            btnGenerarFactura.Click += btnGenerarFactura_Click;
            // 
            // btnVolverMenu
            // 
            btnVolverMenu.Location = new Point(425, 457);
            btnVolverMenu.Margin = new Padding(4, 3, 4, 3);
            btnVolverMenu.Name = "btnVolverMenu";
            btnVolverMenu.Size = new Size(128, 27);
            btnVolverMenu.TabIndex = 14;
            btnVolverMenu.Text = "Volver al Menú";
            btnVolverMenu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(54, 97);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(671, 115);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda de cliente";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(156, 219);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(449, 217);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalles y monto total";
            // 
            // FacturacionClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(792, 519);
            Controls.Add(btnVolverMenu);
            Controls.Add(btnGenerarFactura);
            Controls.Add(txtMontoTotal);
            Controls.Add(lblMontoTotal);
            Controls.Add(lstGuiasCliente);
            Controls.Add(btmBuscar);
            Controls.Add(txtRazonSocial);
            Controls.Add(txtIVA);
            Controls.Add(txtDomicilio);
            Controls.Add(txtCUIT);
            Controls.Add(lblIVA);
            Controls.Add(lblDomicilioFiscal);
            Controls.Add(lblRazonSocial);
            Controls.Add(lblCUIT);
            Controls.Add(lblFacturacion);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FacturacionClienteForm";
            Text = "FacturacionClienteForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFacturacion;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblDomicilioFiscal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button btmBuscar;
        private System.Windows.Forms.ListView lstGuiasCliente;
        private System.Windows.Forms.ColumnHeader colGuia;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.ColumnHeader colImporte;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}