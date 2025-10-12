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
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblDomicilioFiscal = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.btmBuscar = new System.Windows.Forms.Button();
            this.lstGuiasCliente = new System.Windows.Forms.ListView();
            this.colGuia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.AutoSize = true;
            this.lblFacturacion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturacion.Location = new System.Drawing.Point(227, 51);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Size = new System.Drawing.Size(200, 30);
            this.lblFacturacion.TabIndex = 0;
            this.lblFacturacion.Text = "Facturación Cliente";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Location = new System.Drawing.Point(64, 133);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(87, 13);
            this.lblCUIT.TabIndex = 1;
            this.lblCUIT.Text = "CUIT del Cliente:";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(365, 110);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 2;
            this.lblRazonSocial.Text = "Razón Social:";
            // 
            // lblDomicilioFiscal
            // 
            this.lblDomicilioFiscal.AutoSize = true;
            this.lblDomicilioFiscal.Location = new System.Drawing.Point(365, 133);
            this.lblDomicilioFiscal.Name = "lblDomicilioFiscal";
            this.lblDomicilioFiscal.Size = new System.Drawing.Size(82, 13);
            this.lblDomicilioFiscal.TabIndex = 3;
            this.lblDomicilioFiscal.Text = "Domicilio Fiscal:";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(365, 157);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(116, 13);
            this.lblIVA.TabIndex = 4;
            this.lblIVA.Text = "Condición frente a IVA:";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(153, 130);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(122, 20);
            this.txtCUIT.TabIndex = 5;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(453, 126);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.ReadOnly = true;
            this.txtDomicilio.Size = new System.Drawing.Size(148, 20);
            this.txtDomicilio.TabIndex = 6;
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(487, 150);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(114, 20);
            this.txtIVA.TabIndex = 7;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(444, 103);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(157, 20);
            this.txtRazonSocial.TabIndex = 8;
            // 
            // btmBuscar
            // 
            this.btmBuscar.Location = new System.Drawing.Point(281, 130);
            this.btmBuscar.Name = "btmBuscar";
            this.btmBuscar.Size = new System.Drawing.Size(75, 23);
            this.btmBuscar.TabIndex = 9;
            this.btmBuscar.Text = "Buscar";
            this.btmBuscar.UseVisualStyleBackColor = true;
            this.btmBuscar.Click += new System.EventHandler(this.btmBuscar_Click);
            // 
            // lstGuiasCliente
            // 
            this.lstGuiasCliente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGuia,
            this.colFecha,
            this.colImporte});
            this.lstGuiasCliente.FullRowSelect = true;
            this.lstGuiasCliente.GridLines = true;
            this.lstGuiasCliente.HideSelection = false;
            this.lstGuiasCliente.Location = new System.Drawing.Point(174, 213);
            this.lstGuiasCliente.Name = "lstGuiasCliente";
            this.lstGuiasCliente.Size = new System.Drawing.Size(304, 120);
            this.lstGuiasCliente.TabIndex = 10;
            this.lstGuiasCliente.UseCompatibleStateImageBehavior = false;
            this.lstGuiasCliente.View = System.Windows.Forms.View.Details;
            this.lstGuiasCliente.SelectedIndexChanged += new System.EventHandler(this.lstGuiasCliente_SelectedIndexChanged);
            // 
            // colGuia
            // 
            this.colGuia.Text = "Guía #";
            this.colGuia.Width = 100;
            // 
            // colFecha
            // 
            this.colFecha.Text = "Fecha";
            this.colFecha.Width = 100;
            // 
            // colImporte
            // 
            this.colImporte.Text = "Importe";
            this.colImporte.Width = 100;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Location = new System.Drawing.Point(214, 347);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(111, 13);
            this.lblMontoTotal.TabIndex = 11;
            this.lblMontoTotal.Text = "Monto total a facturar:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(331, 340);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoTotal.TabIndex = 12;
            this.txtMontoTotal.Text = "$ 0,00";
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Location = new System.Drawing.Point(170, 396);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(110, 23);
            this.btnGenerarFactura.TabIndex = 13;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Location = new System.Drawing.Point(364, 396);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(110, 23);
            this.btnVolverMenu.TabIndex = 14;
            this.btnVolverMenu.Text = "Volver al Menú";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(46, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda de cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(134, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 188);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles y monto total";
            // 
            // FacturacionClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.lstGuiasCliente);
            this.Controls.Add(this.btmBuscar);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblDomicilioFiscal);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblFacturacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FacturacionClienteForm";
            this.Text = "FacturacionClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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