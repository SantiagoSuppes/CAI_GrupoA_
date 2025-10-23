namespace CAI_GrupoA_.CallCenter
{
    partial class CallCenterForm
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
            groupBox1 = new GroupBox();
            DirSeleccionadaTextBox = new TextBox();
            label15 = new Label();
            clienteListView = new ListView();
            RazonSocial = new ColumnHeader();
            dirección = new ColumnHeader();
            buscarClienteButton = new Button();
            cuitTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnRegistrarPedido = new Button();
            groupBox2 = new GroupBox();
            label14 = new Label();
            txtLocalidad = new TextBox();
            label10 = new Label();
            cmbCD = new ComboBox();
            label3 = new Label();
            cmbAgencia = new ComboBox();
            txtCodigoPostal = new TextBox();
            txtCalleYAltura = new TextBox();
            label9 = new Label();
            label11 = new Label();
            cmbProvincia = new ComboBox();
            label8 = new Label();
            txtTelefono = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cmbModalidad = new ComboBox();
            txtDNI = new TextBox();
            label5 = new Label();
            txtNombreYApellido = new TextBox();
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
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DirSeleccionadaTextBox);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(clienteListView);
            groupBox1.Controls.Add(buscarClienteButton);
            groupBox1.Controls.Add(cuitTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(75, 61);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(621, 239);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente (Remitente)";
            // 
            // DirSeleccionadaTextBox
            // 
            DirSeleccionadaTextBox.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DirSeleccionadaTextBox.Location = new Point(432, 127);
            DirSeleccionadaTextBox.Margin = new Padding(3, 4, 3, 4);
            DirSeleccionadaTextBox.Name = "DirSeleccionadaTextBox";
            DirSeleccionadaTextBox.ReadOnly = true;
            DirSeleccionadaTextBox.Size = new Size(183, 25);
            DirSeleccionadaTextBox.TabIndex = 43;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(441, 103);
            label15.Name = "label15";
            label15.Size = new Size(162, 20);
            label15.TabIndex = 42;
            label15.Text = "Dirección seleccionada";
            // 
            // clienteListView
            // 
            clienteListView.Columns.AddRange(new ColumnHeader[] { RazonSocial, dirección });
            clienteListView.FullRowSelect = true;
            clienteListView.Location = new Point(22, 92);
            clienteListView.Margin = new Padding(3, 4, 3, 4);
            clienteListView.Name = "clienteListView";
            clienteListView.Size = new Size(404, 139);
            clienteListView.TabIndex = 41;
            clienteListView.UseCompatibleStateImageBehavior = false;
            clienteListView.View = View.Details;
            clienteListView.SelectedIndexChanged += clienteListView_SelectedIndexChanged;
            // 
            // RazonSocial
            // 
            RazonSocial.Text = "Razón Social";
            RazonSocial.Width = 150;
            // 
            // dirección
            // 
            dirección.Text = "Dirección";
            dirección.Width = 350;
            // 
            // buscarClienteButton
            // 
            buscarClienteButton.Location = new Point(279, 53);
            buscarClienteButton.Margin = new Padding(3, 4, 3, 4);
            buscarClienteButton.Name = "buscarClienteButton";
            buscarClienteButton.Size = new Size(147, 31);
            buscarClienteButton.TabIndex = 3;
            buscarClienteButton.Text = "Buscar";
            buscarClienteButton.UseVisualStyleBackColor = true;
            buscarClienteButton.Click += buscarClienteButton_Click;
            // 
            // cuitTextBox
            // 
            cuitTextBox.Location = new Point(23, 53);
            cuitTextBox.Margin = new Padding(3, 4, 3, 4);
            cuitTextBox.Name = "cuitTextBox";
            cuitTextBox.PlaceholderText = "30-12345678-9";
            cuitTextBox.Size = new Size(249, 27);
            cuitTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 29);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 0;
            label2.Text = "CUIT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 19);
            label1.Name = "label1";
            label1.Size = new Size(411, 32);
            label1.TabIndex = 5;
            label1.Text = "📞 Registrar pedido en Call Center";
            // 
            // btnRegistrarPedido
            // 
            btnRegistrarPedido.Location = new Point(75, 876);
            btnRegistrarPedido.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarPedido.Name = "btnRegistrarPedido";
            btnRegistrarPedido.Size = new Size(621, 37);
            btnRegistrarPedido.TabIndex = 43;
            btnRegistrarPedido.Text = "Registrar pedido";
            btnRegistrarPedido.UseVisualStyleBackColor = true;
            btnRegistrarPedido.Click += btnRegistrarPedido_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtLocalidad);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(cmbCD);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(cmbAgencia);
            groupBox2.Controls.Add(txtCodigoPostal);
            groupBox2.Controls.Add(txtCalleYAltura);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(cmbProvincia);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cmbModalidad);
            groupBox2.Controls.Add(txtDNI);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtNombreYApellido);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(75, 311);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(621, 320);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del Destinatario";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(211, 125);
            label14.Name = "label14";
            label14.Size = new Size(74, 20);
            label14.TabIndex = 37;
            label14.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(211, 148);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(173, 27);
            txtLocalidad.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(413, 189);
            label10.Name = "label10";
            label10.Size = new Size(29, 20);
            label10.TabIndex = 35;
            label10.Text = "CD";
            // 
            // cmbCD
            // 
            cmbCD.FormattingEnabled = true;
            cmbCD.Location = new Point(413, 213);
            cmbCD.Margin = new Padding(3, 4, 3, 4);
            cmbCD.Name = "cmbCD";
            cmbCD.Size = new Size(173, 28);
            cmbCD.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 251);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 33;
            label3.Text = "Agencia";
            // 
            // cmbAgencia
            // 
            cmbAgencia.FormattingEnabled = true;
            cmbAgencia.Location = new Point(413, 275);
            cmbAgencia.Margin = new Padding(3, 4, 3, 4);
            cmbAgencia.Name = "cmbAgencia";
            cmbAgencia.Size = new Size(173, 28);
            cmbAgencia.TabIndex = 32;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(413, 149);
            txtCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(173, 27);
            txtCodigoPostal.TabIndex = 31;
            // 
            // txtCalleYAltura
            // 
            txtCalleYAltura.Location = new Point(211, 228);
            txtCalleYAltura.Margin = new Padding(3, 4, 3, 4);
            txtCalleYAltura.Name = "txtCalleYAltura";
            txtCalleYAltura.Size = new Size(173, 27);
            txtCalleYAltura.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(413, 40);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 26;
            label9.Text = "Teléfono";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(413, 125);
            label11.Name = "label11";
            label11.Size = new Size(101, 20);
            label11.TabIndex = 24;
            label11.Text = "Codigo Postal";
            // 
            // cmbProvincia
            // 
            cmbProvincia.FormattingEnabled = true;
            cmbProvincia.Items.AddRange(new object[] { "Buenos Aires", "Catamarca", "Chaco", "Chubut", "Ciudad Autónoma de Buenos Aires (CABA)", "Córdoba", "Corrientes", "Entre Ríos", "Formosa", "Jujuy", "La Pampa", "La Rioja", "Mendoza", "Misiones", "Neuquén", "Río Negro", "Salta", "San Juan", "San Luis", "Santa Cruz", "Santa Fe", "Santiago del Estero", "Tierra del Fuego, Antártida e Islas del Atlántico Sur", "Tucumán" });
            cmbProvincia.Location = new Point(21, 147);
            cmbProvincia.Margin = new Padding(3, 4, 3, 4);
            cmbProvincia.Name = "cmbProvincia";
            cmbProvincia.Size = new Size(173, 28);
            cmbProvincia.TabIndex = 20;
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(24, 117);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 14;
            label8.Text = "Provincia";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(413, 68);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(173, 27);
            txtTelefono.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(211, 200);
            label7.Name = "label7";
            label7.Size = new Size(97, 20);
            label7.TabIndex = 12;
            label7.Text = "Calle y Altura";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 200);
            label6.Name = "label6";
            label6.Size = new Size(158, 20);
            label6.TabIndex = 11;
            label6.Text = "Modalidad de Entrega";
            // 
            // cmbModalidad
            // 
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Items.AddRange(new object[] { "Domicilio", "Agencia", "CD" });
            cmbModalidad.Location = new Point(23, 227);
            cmbModalidad.Margin = new Padding(3, 4, 3, 4);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(173, 28);
            cmbModalidad.TabIndex = 10;
            cmbModalidad.SelectedIndexChanged += cmbModalidad_SelectedIndexChanged;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(211, 68);
            txtDNI.Margin = new Padding(3, 4, 3, 4);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(180, 27);
            txtDNI.TabIndex = 9;
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
            // txtNombreYApellido
            // 
            txtNombreYApellido.Location = new Point(21, 68);
            txtNombreYApellido.Margin = new Padding(3, 4, 3, 4);
            txtNombreYApellido.Name = "txtNombreYApellido";
            txtNombreYApellido.Size = new Size(173, 27);
            txtNombreYApellido.TabIndex = 5;
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
            groupBox3.Location = new Point(75, 629);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(621, 239);
            groupBox3.TabIndex = 45;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de la Encomienda";
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
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lvDetalle
            // 
            lvDetalle.Columns.AddRange(new ColumnHeader[] { tipoCaja, Cantidad });
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
            tipoCaja.Text = "Tamaño de Caja";
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
            label12.Location = new Point(219, 33);
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
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(23, 36);
            label13.Name = "label13";
            label13.Size = new Size(115, 20);
            label13.TabIndex = 34;
            label13.Text = "Tamaño de Caja";
            // 
            // CallCenterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(780, 966);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnRegistrarPedido);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "CallCenterForm";
            Text = "callCenterForm";
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
        private GroupBox groupBox1;
        private ListView clienteListView;
        private Button buscarClienteButton;
        private TextBox cuitTextBox;
        private Label label2;
        private Label label1;
        private Button btnRegistrarPedido;
        private ColumnHeader dirección;
        private TextBox DirSeleccionadaTextBox;
        private Label label15;
        private GroupBox groupBox2;
        private Label label10;
        private ComboBox cmbCD;
        private Label label3;
        private ComboBox cmbAgencia;
        private TextBox txtCodigoPostal;
        private TextBox txtCalleYAltura;
        private Label label9;
        private Label label11;
        private ComboBox cmbProvincia;
        private Label label8;
        private TextBox txtTelefono;
        private Label label7;
        private Label label6;
        private ComboBox cmbModalidad;
        private TextBox txtDNI;
        private Label label5;
        private TextBox txtNombreYApellido;
        private Label label4;
        private GroupBox groupBox3;
        private Button btnAgregar;
        private ListView lvDetalle;
        private ColumnHeader tipoCaja;
        private ColumnHeader Cantidad;
        private NumericUpDown nudCantidad;
        private Label label12;
        private ComboBox cmbTipoCaja;
        private Label label13;
        private Label label14;
        private TextBox txtLocalidad;
        private ColumnHeader RazonSocial;
    }
}