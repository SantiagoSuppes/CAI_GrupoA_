namespace CAI_GrupoA_.ImposicionEnAgencia
{
    partial class ImposicionEnAgenciaForm
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
            lstGuiasGeneradas = new ListView();
            btnGenerarGuia = new Button();
            groupBox3 = new GroupBox();
            btnAgregarCaja = new Button();
            label7 = new Label();
            numCantidad = new NumericUpDown();
            cmbTipoCaja = new ComboBox();
            label9 = new Label();
            cmbModalidadEntrega = new ComboBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            btnBuscarRemitente = new Button();
            txtRazonSocial = new TextBox();
            txtCUIT = new TextBox();
            label1 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            txtLocalidad = new TextBox();
            label15 = new Label();
            cmbCD = new ComboBox();
            label5 = new Label();
            cmbAgencia = new ComboBox();
            label4 = new Label();
            cmbProvincia = new ComboBox();
            txtDNIDest = new TextBox();
            txtDomicilio = new TextBox();
            label10 = new Label();
            label2 = new Label();
            txtTelefonoDest = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtNombreDestinatario = new TextBox();
            txtCP = new TextBox();
            label14 = new Label();
            label13 = new Label();
            groupBox4 = new GroupBox();
            label6 = new Label();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // lstGuiasGeneradas
            // 
            lstGuiasGeneradas.Location = new Point(13, 22);
            lstGuiasGeneradas.Name = "lstGuiasGeneradas";
            lstGuiasGeneradas.Size = new Size(520, 67);
            lstGuiasGeneradas.TabIndex = 33;
            lstGuiasGeneradas.UseCompatibleStateImageBehavior = false;
            // 
            // btnGenerarGuia
            // 
            btnGenerarGuia.Location = new Point(666, 583);
            btnGenerarGuia.Name = "btnGenerarGuia";
            btnGenerarGuia.Size = new Size(102, 23);
            btnGenerarGuia.TabIndex = 31;
            btnGenerarGuia.Text = "Generar Guía";
            btnGenerarGuia.UseVisualStyleBackColor = true;
            btnGenerarGuia.Click += btnGenerarGuia_Click_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAgregarCaja);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(numCantidad);
            groupBox3.Controls.Add(cmbTipoCaja);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(22, 374);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(746, 74);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de Envío";
            // 
            // btnAgregarCaja
            // 
            btnAgregarCaja.Location = new Point(637, 29);
            btnAgregarCaja.Name = "btnAgregarCaja";
            btnAgregarCaja.Size = new Size(102, 23);
            btnAgregarCaja.TabIndex = 36;
            btnAgregarCaja.Text = "Añadir";
            btnAgregarCaja.UseVisualStyleBackColor = true;
            btnAgregarCaja.Click += btnAgregarCaja_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(413, 13);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(413, 31);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(120, 23);
            numCantidad.TabIndex = 8;
            // 
            // cmbTipoCaja
            // 
            cmbTipoCaja.FormattingEnabled = true;
            cmbTipoCaja.Location = new Point(197, 31);
            cmbTipoCaja.Name = "cmbTipoCaja";
            cmbTipoCaja.Size = new Size(127, 23);
            cmbTipoCaja.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(197, 13);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 5;
            label9.Text = "Tamaño";
            // 
            // cmbModalidadEntrega
            // 
            cmbModalidadEntrega.FormattingEnabled = true;
            cmbModalidadEntrega.Location = new Point(13, 148);
            cmbModalidadEntrega.Name = "cmbModalidadEntrega";
            cmbModalidadEntrega.Size = new Size(230, 23);
            cmbModalidadEntrega.TabIndex = 31;
            cmbModalidadEntrega.SelectedIndexChanged += cmbModalidadEntrega_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 130);
            label8.Name = "label8";
            label8.Size = new Size(123, 15);
            label8.TabIndex = 32;
            label8.Text = "Modalidad de Entrega";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarRemitente);
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(txtCUIT);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(21, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(747, 83);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Remitente";
            // 
            // btnBuscarRemitente
            // 
            btnBuscarRemitente.Location = new Point(219, 43);
            btnBuscarRemitente.Name = "btnBuscarRemitente";
            btnBuscarRemitente.Size = new Size(97, 23);
            btnBuscarRemitente.TabIndex = 17;
            btnBuscarRemitente.Text = "Buscar";
            btnBuscarRemitente.UseVisualStyleBackColor = true;
            btnBuscarRemitente.Click += btnBuscarRemitente_Click;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Enabled = false;
            txtRazonSocial.Location = new Point(467, 44);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.ReadOnly = true;
            txtRazonSocial.Size = new Size(204, 23);
            txtRazonSocial.TabIndex = 1;
            // 
            // txtCUIT
            // 
            txtCUIT.Location = new Point(15, 43);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(198, 23);
            txtCUIT.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(467, 25);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 16;
            label1.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 25);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 5;
            label3.Text = "CUIT";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtLocalidad);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(cmbCD);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbAgencia);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cmbModalidadEntrega);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cmbProvincia);
            groupBox2.Controls.Add(txtDNIDest);
            groupBox2.Controls.Add(txtDomicilio);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtTelefonoDest);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(txtNombreDestinatario);
            groupBox2.Controls.Add(txtCP);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Location = new Point(21, 146);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(746, 222);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Destinatario";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(263, 95);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(230, 23);
            txtLocalidad.TabIndex = 37;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(263, 77);
            label15.Name = "label15";
            label15.Size = new Size(58, 15);
            label15.TabIndex = 38;
            label15.Text = "Localidad";
            // 
            // cmbCD
            // 
            cmbCD.FormattingEnabled = true;
            cmbCD.Location = new Point(510, 148);
            cmbCD.Name = "cmbCD";
            cmbCD.Size = new Size(230, 23);
            cmbCD.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(510, 130);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 36;
            label5.Text = "CD";
            // 
            // cmbAgencia
            // 
            cmbAgencia.FormattingEnabled = true;
            cmbAgencia.Location = new Point(510, 193);
            cmbAgencia.Name = "cmbAgencia";
            cmbAgencia.Size = new Size(230, 23);
            cmbAgencia.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 175);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 34;
            label4.Text = "Agencia";
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Location = new Point(13, 95);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(230, 23);
            cmbProvincia.TabIndex = 13;
            // 
            // txtDNIDest
            // 
            txtDNIDest.Location = new Point(263, 37);
            txtDNIDest.Name = "txtDNIDest";
            txtDNIDest.Size = new Size(230, 23);
            txtDNIDest.TabIndex = 8;
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(263, 148);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(230, 23);
            txtDomicilio.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(510, 77);
            label10.Name = "label10";
            label10.Size = new Size(81, 15);
            label10.TabIndex = 18;
            label10.Text = "Código Postal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(508, 19);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 25;
            label2.Text = "Teléfono";
            // 
            // txtTelefonoDest
            // 
            txtTelefonoDest.Location = new Point(508, 37);
            txtTelefonoDest.Name = "txtTelefonoDest";
            txtTelefonoDest.Size = new Size(232, 23);
            txtTelefonoDest.TabIndex = 10;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 77);
            label11.Name = "label11";
            label11.Size = new Size(56, 15);
            label11.TabIndex = 20;
            label11.Text = "Provincia";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(263, 130);
            label12.Name = "label12";
            label12.Size = new Size(77, 15);
            label12.TabIndex = 19;
            label12.Text = "Calle y Altura";
            // 
            // txtNombreDestinatario
            // 
            txtNombreDestinatario.Location = new Point(13, 37);
            txtNombreDestinatario.Name = "txtNombreDestinatario";
            txtNombreDestinatario.Size = new Size(230, 23);
            txtNombreDestinatario.TabIndex = 12;
            // 
            // txtCP
            // 
            txtCP.Location = new Point(510, 95);
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(230, 23);
            txtCP.TabIndex = 4;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(13, 19);
            label14.Name = "label14";
            label14.Size = new Size(107, 15);
            label14.TabIndex = 23;
            label14.Text = "Nombre y Apellido";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(263, 19);
            label13.Name = "label13";
            label13.Size = new Size(27, 15);
            label13.TabIndex = 26;
            label13.Text = "DNI";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lstGuiasGeneradas);
            groupBox4.Location = new Point(127, 466);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(551, 100);
            groupBox4.TabIndex = 34;
            groupBox4.TabStop = false;
            groupBox4.Text = "Guías Generadas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.Location = new Point(21, 9);
            label6.Name = "label6";
            label6.Size = new Size(305, 30);
            label6.TabIndex = 35;
            label6.Text = "Registrar Pedido en Agencia";
            // 
            // ImposicionEnAgenciaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(785, 611);
            Controls.Add(label6);
            Controls.Add(btnGenerarGuia);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox4);
            Name = "ImposicionEnAgenciaForm";
            Text = "ImposicionEnAgencia";
            Load += ImposicionEnAgencia_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lstGuiasGeneradas;
        private Button btnGenerarGuia;
        private GroupBox groupBox3;
        private Label label7;
        private NumericUpDown numCantidad;
        private ComboBox cmbTipoCaja;
        private Label label9;
        private ComboBox cmbModalidadEntrega;
        private Label label8;
        private GroupBox groupBox1;
        private Button btnBuscarRemitente;
        private TextBox txtRazonSocial;
        private TextBox txtCUIT;
        private Label label1;
        private Label label3;
        private GroupBox groupBox2;
        private ComboBox cmbCD;
        private Label label5;
        private ComboBox cmbAgencia;
        private Label label4;
        private ComboBox cmbProvincia;
        private TextBox txtDNIDest;
        private TextBox txtDomicilio;
        private Label label10;
        private Label label2;
        private TextBox txtTelefonoDest;
        private Label label11;
        private Label label12;
        private TextBox txtNombreDestinatario;
        private TextBox txtCP;
        private Label label14;
        private Label label13;
        private GroupBox groupBox4;
        private Label label6;
        private Button btnAgregarCaja;
        private TextBox txtLocalidad;
        private Label label15;
    }
}