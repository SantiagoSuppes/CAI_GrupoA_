namespace CAI_GrupoA_.cdRecepcionPaquetes
{
    partial class cdRecepcionPaquetesForm
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
            groupBox1.Location = new Point(36, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(543, 92);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente (Remitente)";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(21, 46);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(152, 23);
            txtCuit.TabIndex = 36;
            txtCuit.TextChanged += cuit_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(343, 28);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 20;
            label14.Text = "Cliente";
            label14.Click += label14_Click;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(343, 46);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(152, 23);
            txtCliente.TabIndex = 19;
            // 
            // button1
            // 
            button1.Location = new Point(185, 46);
            button1.Name = "button1";
            button1.Size = new Size(129, 23);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 28);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "CUIT";
            // 
            // groupBox2
            // 
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
            groupBox2.Location = new Point(36, 161);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(543, 225);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Destinatario";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(361, 149);
            label10.Name = "label10";
            label10.Size = new Size(23, 15);
            label10.TabIndex = 35;
            label10.Text = "CD";
            // 
            // cmbCD
            // 
            cmbCD.FormattingEnabled = true;
            cmbCD.Location = new Point(361, 171);
            cmbCD.Name = "cmbCD";
            cmbCD.Size = new Size(152, 23);
            cmbCD.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 149);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 33;
            label3.Text = "Agencia";
            // 
            // cmbAgencia
            // 
            cmbAgencia.FormattingEnabled = true;
            cmbAgencia.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cmbAgencia.Location = new Point(185, 171);
            cmbAgencia.Name = "cmbAgencia";
            cmbAgencia.Size = new Size(152, 23);
            cmbAgencia.TabIndex = 32;
            // 
            // codigoPostal
            // 
            codigoPostal.Location = new Point(361, 110);
            codigoPostal.Name = "codigoPostal";
            codigoPostal.Size = new Size(152, 23);
            codigoPostal.TabIndex = 31;
            // 
            // txtCalleAltura
            // 
            txtCalleAltura.Location = new Point(18, 172);
            txtCalleAltura.Name = "txtCalleAltura";
            txtCalleAltura.Size = new Size(152, 23);
            txtCalleAltura.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(361, 29);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 26;
            label9.Text = "Teléfono";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(361, 89);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 24;
            label11.Text = "Codigo Postal";
            label11.Click += label11_Click;
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Items.AddRange(new object[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Ciudad Autónoma de Buenos Aires (CABA)", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego, Antártida e Islas del Atlántico Sur", "Tucumán" });
            cmbProvincia.Location = new Point(185, 110);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(152, 23);
            cmbProvincia.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(185, 88);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 14;
            label8.Text = "Provincia";
            // 
            // telefono
            // 
            telefono.Location = new Point(361, 51);
            telefono.Name = "telefono";
            telefono.Size = new Size(152, 23);
            telefono.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 150);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 12;
            label7.Text = "Calle y Altura";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 88);
            label6.Name = "label6";
            label6.Size = new Size(123, 15);
            label6.TabIndex = 11;
            label6.Text = "Modalidad de Entrega";
            // 
            // cmbModalidad
            // 
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cmbModalidad.Location = new Point(18, 110);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(152, 23);
            cmbModalidad.TabIndex = 10;
            cmbModalidad.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dni
            // 
            dni.Location = new Point(185, 51);
            dni.Name = "dni";
            dni.Size = new Size(158, 23);
            dni.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(185, 28);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 8;
            label5.Text = "DNI";
            // 
            // nombreApellido
            // 
            nombreApellido.Location = new Point(18, 51);
            nombreApellido.Name = "nombreApellido";
            nombreApellido.Size = new Size(152, 23);
            nombreApellido.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 28);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
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
            groupBox3.Location = new Point(36, 404);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(543, 179);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de la Encomienda";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(384, 43);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(129, 23);
            btnAgregar.TabIndex = 37;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += button2_Click;
            // 
            // lvDetalle
            // 
            lvDetalle.Columns.AddRange(new ColumnHeader[] { tipoCaja, Cantidad });
            lvDetalle.ContextMenuStrip = contextMenuStrip1;
            lvDetalle.Location = new Point(18, 76);
            lvDetalle.Name = "lvDetalle";
            lvDetalle.Size = new Size(495, 88);
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
            nudCantidad.Location = new Point(192, 45);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(192, 24);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 36;
            label12.Text = "Cantidad";
            // 
            // cmbTipoCaja
            // 
            cmbTipoCaja.FormattingEnabled = true;
            cmbTipoCaja.Location = new Point(21, 47);
            cmbTipoCaja.Name = "cmbTipoCaja";
            cmbTipoCaja.Size = new Size(152, 23);
            cmbTipoCaja.TabIndex = 31;
            cmbTipoCaja.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(20, 26);
            label13.Name = "label13";
            label13.Size = new Size(73, 15);
            label13.TabIndex = 34;
            label13.Text = "Tipo de Caja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 13);
            label2.Name = "label2";
            label2.Size = new Size(215, 25);
            label2.TabIndex = 4;
            label2.Text = "Registrar Nuevo Envío ";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(36, 601);
            button3.Name = "button3";
            button3.Size = new Size(543, 23);
            button3.TabIndex = 42;
            button3.Text = "Generar nuevo envío";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // cdOrigen
            // 
            cdOrigen.FormattingEnabled = true;
            cdOrigen.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cdOrigen.Location = new Point(338, 18);
            cdOrigen.Name = "cdOrigen";
            cdOrigen.Size = new Size(152, 23);
            cdOrigen.TabIndex = 36;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(267, 21);
            label15.Name = "label15";
            label15.Size = new Size(65, 15);
            label15.TabIndex = 37;
            label15.Text = "CD Origen:";
            // 
            // cdRecepcionPaquetesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 636);
            Controls.Add(label15);
            Controls.Add(cdOrigen);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "cdRecepcionPaquetesForm";
            Text = "cdRecepcionPaquetesForm";
            Load += cdRecepcionPaquetesForm_Load;
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
    }
}