namespace CAI_GrupoA_.MenuPrincipal
{
    partial class MenuPrincipalForm
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
            lblMenu = new Label();
            lblUsuario = new Label();
            lblFecha = new Label();
            txtUsuario = new TextBox();
            btnCerrarSesion = new Button();
            dtpFecha = new DateTimePicker();
            groupBox1 = new GroupBox();
            btnRendicion = new Button();
            btnReportesCostos = new Button();
            btnFacturacion = new Button();
            btnCargaDescarga = new Button();
            btnEntregaCD = new Button();
            btnRecepcionAg = new Button();
            btnRecepcionCD = new Button();
            btnCallCenter = new Button();
            btnEstado = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenu.Location = new Point(36, 42);
            lblMenu.Margin = new Padding(4, 0, 4, 0);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(162, 30);
            lblMenu.TabIndex = 10;
            lblMenu.Text = "Menú Principal";
            lblMenu.Click += lblMenu_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(222, 53);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 11;
            lblUsuario.Text = "Usuario:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(449, 52);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(283, 48);
            txtUsuario.Margin = new Padding(4, 3, 4, 3);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(143, 23);
            txtUsuario.TabIndex = 13;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(637, 47);
            btnCerrarSesion.Margin = new Padding(4, 3, 4, 3);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(120, 27);
            btnCerrarSesion.TabIndex = 15;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(498, 49);
            dtpFecha.Margin = new Padding(4, 3, 4, 3);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(103, 23);
            dtpFecha.TabIndex = 14;
            dtpFecha.Value = new DateTime(2025, 10, 11, 18, 42, 33, 0);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRendicion);
            groupBox1.Controls.Add(btnReportesCostos);
            groupBox1.Controls.Add(btnFacturacion);
            groupBox1.Controls.Add(btnCargaDescarga);
            groupBox1.Controls.Add(btnEntregaCD);
            groupBox1.Controls.Add(btnRecepcionAg);
            groupBox1.Controls.Add(btnRecepcionCD);
            groupBox1.Controls.Add(btnCallCenter);
            groupBox1.Controls.Add(btnEstado);
            groupBox1.Location = new Point(36, 103);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(732, 222);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccione la que corresponda";
            // 
            // btnRendicion
            // 
            btnRendicion.Location = new Point(291, 95);
            btnRendicion.Margin = new Padding(4, 3, 4, 3);
            btnRendicion.Name = "btnRendicion";
            btnRendicion.Size = new Size(145, 48);
            btnRendicion.TabIndex = 14;
            btnRendicion.Text = "🚚 Entrega y recepción de pedidos";
            btnRendicion.UseVisualStyleBackColor = true;
            // 
            // btnReportesCostos
            // 
            btnReportesCostos.Location = new Point(466, 95);
            btnReportesCostos.Margin = new Padding(4, 3, 4, 3);
            btnReportesCostos.Name = "btnReportesCostos";
            btnReportesCostos.Size = new Size(145, 48);
            btnReportesCostos.TabIndex = 11;
            btnReportesCostos.Text = "📊 Reporte de Costos y Ventas";
            btnReportesCostos.UseVisualStyleBackColor = true;
            // 
            // btnFacturacion
            // 
            btnFacturacion.Location = new Point(466, 150);
            btnFacturacion.Margin = new Padding(4, 3, 4, 3);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(145, 48);
            btnFacturacion.TabIndex = 12;
            btnFacturacion.Text = "💰 Facturar a Clientes";
            btnFacturacion.UseVisualStyleBackColor = true;
            // 
            // btnCargaDescarga
            // 
            btnCargaDescarga.Location = new Point(291, 39);
            btnCargaDescarga.Margin = new Padding(4, 3, 4, 3);
            btnCargaDescarga.Name = "btnCargaDescarga";
            btnCargaDescarga.Size = new Size(145, 48);
            btnCargaDescarga.TabIndex = 13;
            btnCargaDescarga.Text = "🚛 Carga / Descarga de pedidos";
            btnCargaDescarga.UseVisualStyleBackColor = true;
            // 
            // btnEntregaCD
            // 
            btnEntregaCD.Location = new Point(466, 39);
            btnEntregaCD.Margin = new Padding(4, 3, 4, 3);
            btnEntregaCD.Name = "btnEntregaCD";
            btnEntregaCD.Size = new Size(145, 48);
            btnEntregaCD.TabIndex = 10;
            btnEntregaCD.Text = "🎯 Entrega de pedido";
            btnEntregaCD.UseVisualStyleBackColor = true;
            // 
            // btnRecepcionAg
            // 
            btnRecepcionAg.Location = new Point(107, 150);
            btnRecepcionAg.Margin = new Padding(4, 3, 4, 3);
            btnRecepcionAg.Name = "btnRecepcionAg";
            btnRecepcionAg.Size = new Size(145, 48);
            btnRecepcionAg.TabIndex = 18;
            btnRecepcionAg.Text = "🏢 Registrar pedido en agencia";
            btnRecepcionAg.UseVisualStyleBackColor = true;
            // 
            // btnRecepcionCD
            // 
            btnRecepcionCD.Location = new Point(107, 95);
            btnRecepcionCD.Margin = new Padding(4, 3, 4, 3);
            btnRecepcionCD.Name = "btnRecepcionCD";
            btnRecepcionCD.Size = new Size(145, 48);
            btnRecepcionCD.TabIndex = 17;
            btnRecepcionCD.Text = "🏭 Registrar pedido en CD";
            btnRecepcionCD.UseVisualStyleBackColor = true;
            // 
            // btnCallCenter
            // 
            btnCallCenter.Location = new Point(107, 39);
            btnCallCenter.Margin = new Padding(4, 3, 4, 3);
            btnCallCenter.Name = "btnCallCenter";
            btnCallCenter.Size = new Size(145, 48);
            btnCallCenter.TabIndex = 16;
            btnCallCenter.Text = "📞 Registrar pedido en Call Center";
            btnCallCenter.UseVisualStyleBackColor = true;
            // 
            // btnEstado
            // 
            btnEstado.Location = new Point(291, 150);
            btnEstado.Margin = new Padding(4, 3, 4, 3);
            btnEstado.Name = "btnEstado";
            btnEstado.Size = new Size(145, 48);
            btnEstado.TabIndex = 15;
            btnEstado.Text = "📦 Estado de pedidos";
            btnEstado.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 348);
            Controls.Add(lblFecha);
            Controls.Add(lblUsuario);
            Controls.Add(dtpFecha);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblMenu);
            Controls.Add(txtUsuario);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuPrincipalForm";
            Text = "MenuPrincipalForm";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private Button btnRendicion;
        private Button btnReportesCostos;
        private Button btnFacturacion;
        private Button btnCargaDescarga;
        private Button btnEntregaCD;
        private Button btnRecepcionAg;
        private Button btnRecepcionCD;
        private Button btnCallCenter;
        private Button btnEstado;
    }
}