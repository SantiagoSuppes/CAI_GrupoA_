namespace CAI_GrupoA_.CdRecepcionPaquetes
{
    partial class CdRecepcionPaquetesForm
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupBox1 = new GroupBox();
            txtCuit = new TextBox();
            label14 = new Label();
            txtCliente = new TextBox();
            button1 = new Button();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label10 = new Label();
            cmbCD = new ComboBox();
            label3 = new Label();
            cmbAgencia = new ComboBox();
            codigoPostal = new TextBox();
            txtCalleAltura = new TextBox();
            label9 = new Label();
            label11 = new Label();
            cmbProvincia = new ComboBox();
            label8 = new Label();
            telefono = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cmbModalidad = new ComboBox();
            dni = new TextBox();
            label5 = new Label();
            nombreApellido = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            btnAgregar = new Button();
            lvDetalle = new ListView();
            tipoCaja = new ColumnHeader();
            Cantidad = new ColumnHeader();
            nudCantidad = new NumericUpDown();
            label12 = new Label();
            cmbTipoCaja = new ComboBox();
            label13 = new Label();
            label2 = new Label();
            button3 = new Button();
            cdOrigen = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            txtLocalidad = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCuit);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtCliente);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(41, 63);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(621, 123);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente (Remitente)";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(24, 61);
            txtCuit.Margin = new Padding(3, 4, 3, 4);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(173, 27);
            txtCuit.TabIndex = 36;
            txtCuit.TextChanged += cuit_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(392, 37);
            label14.Name = "label14";
            label14.Size = new Size(55, 20);
            label14.TabIndex = 20;
            label14.Text = "Cliente";
            label14.Click += label14_Click;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(392, 61);
            txtCliente.Margin = new Padding(3, 4, 3, 4);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(173, 27);
            txtCliente.TabIndex = 19;
            // 
            // button1
            // 
            button1.Location = new Point(211, 61);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(147, 31);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 37);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 0;
            label1.Text = "CUIT";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(txtLocalidad);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(cmbCD);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(cmbAgencia);
            groupBox2.Controls.Add(codigoPostal);
            groupBox2.Controls.Add(txtCalleAltura);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(cmbProvincia);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(telefono);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cmbModalidad);
            groupBox2.Controls.Add(dni);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(nombreApellido);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(41, 215);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(621, 323);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Destinatario";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(413, 190);
            label10.Name = "label10";
            label10.Size = new Size(29, 20);
            label10.TabIndex = 35;
            label10.Text = "CD";
            // 
            // cmbCD
            // 
            cmbCD.FormattingEnabled = true;
            cmbCD.Location = new Point(413, 214);
            cmbCD.Margin = new Padding(3, 4, 3, 4);
            cmbCD.Name = "cmbCD";
            cmbCD.Size = new Size(173, 28);
            cmbCD.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 263);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 33;
            label3.Text = "Agencia";
            // 
            // cmbAgencia
            // 
            cmbAgencia.FormattingEnabled = true;
            cmbAgencia.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cmbAgencia.Location = new Point(413, 287);
            cmbAgencia.Margin = new Padding(3, 4, 3, 4);
            cmbAgencia.Name = "cmbAgencia";
            cmbAgencia.Size = new Size(173, 28);
            cmbAgencia.TabIndex = 32;
            // 
            // codigoPostal
            // 
            codigoPostal.Location = new Point(413, 147);
            codigoPostal.Margin = new Padding(3, 4, 3, 4);
            codigoPostal.Name = "codigoPostal";
            codigoPostal.Size = new Size(173, 27);
            codigoPostal.TabIndex = 31;
            // 
            // txtCalleAltura
            // 
            txtCalleAltura.Location = new Point(211, 215);
            txtCalleAltura.Margin = new Padding(3, 4, 3, 4);
            txtCalleAltura.Name = "txtCalleAltura";
            txtCalleAltura.Size = new Size(173, 27);
            txtCalleAltura.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(413, 39);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 26;
            label9.Text = "Teléfono";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(413, 119);
            label11.Name = "label11";
            label11.Size = new Size(101, 20);
            label11.TabIndex = 24;
            label11.Text = "Codigo Postal";
            label11.Click += label11_Click;
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Items.AddRange(new object[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Ciudad Autónoma de Buenos Aires (CABA)", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego, Antártida e Islas del Atlántico Sur", "Tucumán" });
            cmbProvincia.Location = new Point(24, 146);
            cmbProvincia.Margin = new Padding(3, 4, 3, 4);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(173, 28);
            cmbProvincia.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 122);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 14;
            label8.Text = "Provincia";
            // 
            // telefono
            // 
            telefono.Location = new Point(413, 68);
            telefono.Margin = new Padding(3, 4, 3, 4);
            telefono.Name = "telefono";
            telefono.Size = new Size(173, 27);
            telefono.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(211, 190);
            label7.Name = "label7";
            label7.Size = new Size(97, 20);
            label7.TabIndex = 12;
            label7.Text = "Calle y Altura";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 190);
            label6.Name = "label6";
            label6.Size = new Size(158, 20);
            label6.TabIndex = 11;
            label6.Text = "Modalidad de Entrega";
            // 
            // cmbModalidad
            // 
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cmbModalidad.Location = new Point(21, 214);
            cmbModalidad.Margin = new Padding(3, 4, 3, 4);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(173, 28);
            cmbModalidad.TabIndex = 10;
            cmbModalidad.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dni
            // 
            dni.Location = new Point(211, 68);
            dni.Margin = new Padding(3, 4, 3, 4);
            dni.Name = "dni";
            dni.Size = new Size(180, 27);
            dni.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(211, 37);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 8;
            label5.Text = "DNI";
            // 
            // nombreApellido
            // 
            nombreApellido.Location = new Point(21, 68);
            nombreApellido.Margin = new Padding(3, 4, 3, 4);
            nombreApellido.Name = "nombreApellido";
            nombreApellido.Size = new Size(173, 27);
            nombreApellido.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 37);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 4;
            label4.Text = "Nombre y Apellido";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAgregar);
            groupBox3.Controls.Add(lvDetalle);
            groupBox3.Controls.Add(nudCantidad);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(cmbTipoCaja);
            groupBox3.Controls.Add(label13);
            groupBox3.Location = new Point(41, 554);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(621, 239);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de la Encomienda";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(439, 57);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(147, 31);
            btnAgregar.TabIndex = 37;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += button2_Click;
            // 
            // lvDetalle
            // 
            lvDetalle.Columns.AddRange(new ColumnHeader[] { tipoCaja, Cantidad });
            lvDetalle.ContextMenuStrip = contextMenuStrip1;
            lvDetalle.Location = new Point(21, 101);
            lvDetalle.Margin = new Padding(3, 4, 3, 4);
            lvDetalle.Name = "lvDetalle";
            lvDetalle.Size = new Size(565, 116);
            lvDetalle.TabIndex = 42;
            lvDetalle.UseCompatibleStateImageBehavior = false;
            lvDetalle.View = View.Details;
            // 
            // tipoCaja
            // 
            tipoCaja.Text = "Tipo De Caja";
            tipoCaja.Width = 120;
            // 
            // Cantidad
            // 
            Cantidad.Text = "Cantidad";
            Cantidad.Width = 180;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(219, 60);
            nudCantidad.Margin = new Padding(3, 4, 3, 4);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(137, 27);
            nudCantidad.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(219, 32);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 36;
            label12.Text = "Cantidad";
            // 
            // cmbTipoCaja
            // 
            cmbTipoCaja.FormattingEnabled = true;
            cmbTipoCaja.Location = new Point(24, 63);
            cmbTipoCaja.Margin = new Padding(3, 4, 3, 4);
            cmbTipoCaja.Name = "cmbTipoCaja";
            cmbTipoCaja.Size = new Size(173, 28);
            cmbTipoCaja.TabIndex = 31;
            cmbTipoCaja.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(23, 35);
            label13.Name = "label13";
            label13.Size = new Size(93, 20);
            label13.TabIndex = 34;
            label13.Text = "Tipo de Caja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 17);
            label2.Name = "label2";
            label2.Size = new Size(276, 32);
            label2.TabIndex = 4;
            label2.Text = "Registrar Nuevo Envío ";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(41, 801);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(621, 31);
            button3.TabIndex = 42;
            button3.Text = "Generar nuevo envío";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // cdOrigen
            // 
            cdOrigen.FormattingEnabled = true;
            cdOrigen.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cdOrigen.Location = new Point(386, 24);
            cdOrigen.Margin = new Padding(3, 4, 3, 4);
            cdOrigen.Name = "cdOrigen";
            cdOrigen.Size = new Size(173, 28);
            cdOrigen.TabIndex = 36;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(305, 28);
            label15.Name = "label15";
            label15.Size = new Size(81, 20);
            label15.TabIndex = 37;
            label15.Text = "CD Origen:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(211, 116);
            label16.Name = "label16";
            label16.Size = new Size(74, 20);
            label16.TabIndex = 39;
            label16.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(211, 146);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(173, 27);
            txtLocalidad.TabIndex = 38;
            // 
            // cdRecepcionPaquetesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 848);
            Controls.Add(label15);
            Controls.Add(cdOrigen);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CdRecepcionPaquetesForm";
            Text = "CdRecepcionPaquetesForm";
            Load += CdRecepcionPaquetesForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button1;
        private Label label2;
        private TextBox nombreApellido;
        private Label label4;
        private TextBox dni;
        private Label label5;
        private Label label6;
        private ComboBox cmbModalidad;
        private Label label8;
        private TextBox telefono;
        private Label label7;
        private Label label11;
        private ComboBox cmbProvincia;
        private Label label9;
        private TextBox txtCalleAltura;
        private NumericUpDown nudCantidad;
        private Label label12;
        private ComboBox cmbTipoCaja;
        private Label label13;
        private Button button3;
        private ListView lvDetalle;
        private ColumnHeader tipoCaja;
        private ColumnHeader Cantidad;
        private TextBox codigoPostal;
        private Label label14;
        private TextBox txtCliente;
        private Label label10;
        private ComboBox cmbCD;
        private Label label3;
        private ComboBox cmbAgencia;
        private TextBox txtCuit;
        private Button btnAgregar;
        private ComboBox cdOrigen;
        private Label label15;
        private Label label16;
        private TextBox txtLocalidad;
    }
}