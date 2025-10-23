namespace CAI_GrupoA_.MenuPrincipal
{
    partial class MenuPrincipalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            lblMenu = new Label();
            lblUsuario = new Label();
            lblFecha = new Label();
            txtUsuario = new TextBox();
            btnCerrarSesion = new Button();
            dtpFecha = new DateTimePicker();
            groupBox1 = new GroupBox();
            btnEntregaAgencia = new Button();
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
            lblMenu.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMenu.Location = new Point(36, 42);
            lblMenu.Text = "Menú Principal";
            lblMenu.Click += lblMenu_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(222, 53);
            lblUsuario.Text = "Usuario:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(449, 52);
            lblFecha.Text = "Fecha:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(283, 48);
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(143, 23);
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(637, 47);
            btnCerrarSesion.Size = new Size(120, 27);
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(498, 49);
            dtpFecha.Size = new Size(103, 23);
            // 
            // groupBox1
            // 
            groupBox1.Controls.AddRange(new Control[]
            {
                btnEntregaAgencia, btnRendicion, btnReportesCostos, btnFacturacion,
                btnCargaDescarga, btnEntregaCD, btnRecepcionAg, btnRecepcionCD,
                btnCallCenter, btnEstado
            });
            groupBox1.Location = new Point(36, 103);
            groupBox1.Size = new Size(732, 287);
            groupBox1.Text = "Seleccione la opción que corresponda";
            // 
            // Botones
            // 
            btnCallCenter.Text = "📞 Registrar pedido en Call Center";
            btnCallCenter.Size = new Size(145, 48);
            btnCallCenter.Location = new Point(107, 39);

            btnRecepcionCD.Text = "🏭 Registrar pedido en CD";
            btnRecepcionCD.Size = new Size(145, 48);
            btnRecepcionCD.Location = new Point(107, 95);

            btnRecepcionAg.Text = "🏢 Registrar pedido en agencia";
            btnRecepcionAg.Size = new Size(145, 48);
            btnRecepcionAg.Location = new Point(107, 150);

            btnCargaDescarga.Text = "🚛 Carga / Descarga de pedidos larga distancia";
            btnCargaDescarga.Size = new Size(145, 48);
            btnCargaDescarga.Location = new Point(107, 204);

            btnRendicion.Text = "🚚 Entrega y recepción de pedidos última milla";
            btnRendicion.Size = new Size(145, 48);
            btnRendicion.Location = new Point(291, 39);

            btnEntregaCD.Text = "🎯 Entrega de pedido en CD";
            btnEntregaCD.Size = new Size(145, 48);
            btnEntregaCD.Location = new Point(291, 95);

            btnEntregaAgencia.Text = "🎯 Entrega de pedido en Agencia";
            btnEntregaAgencia.Size = new Size(145, 48);
            btnEntregaAgencia.Location = new Point(291, 149);

            btnEstado.Text = "📦 Estado de pedidos";
            btnEstado.Size = new Size(145, 48);
            btnEstado.Location = new Point(291, 204);

            btnReportesCostos.Text = "📊 Reporte de Costos y Ventas";
            btnReportesCostos.Size = new Size(145, 48);
            btnReportesCostos.Location = new Point(462, 95);

            btnFacturacion.Text = "💰 Facturar a Clientes";
            btnFacturacion.Size = new Size(145, 48);
            btnFacturacion.Location = new Point(462, 150);

            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 410);
            Controls.AddRange(new Control[] { lblFecha, lblUsuario, dtpFecha, btnCerrarSesion, lblMenu, txtUsuario, groupBox1 });
            Text = "Menú Principal";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMenu;
        private Label lblUsuario;
        private Label lblFecha;
        private TextBox txtUsuario;
        private Button btnCerrarSesion;
        private GroupBox groupBox1;
        private DateTimePicker dtpFecha;
        private Button btnRendicion;
        private Button btnReportesCostos;
        private Button btnFacturacion;
        private Button btnCargaDescarga;
        private Button btnEntregaCD;
        private Button btnRecepcionAg;
        private Button btnRecepcionCD;
        private Button btnCallCenter;
        private Button btnEstado;
        private Button btnEntregaAgencia;
    }
}
