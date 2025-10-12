namespace CAI_GrupoA_.GuiaEstadoHistorial
{
    partial class GuiaEstadoHistorialForm
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
            label1 = new Label();
            label2 = new Label();
            numeroGuia = new TextBox();
            btnBuscarGuia = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            listLineaTiempo = new ListView();
            fechaMovimiento = new ColumnHeader();
            tipoTramo = new ColumnHeader();
            estado = new ColumnHeader();
            Origen = new ColumnHeader();
            Destino = new ColumnHeader();
            quienRealiza = new ColumnHeader();
            label6 = new Label();
            label9 = new Label();
            txtCliente = new TextBox();
            txtEstadoActual = new TextBox();
            txtFechaUltimoMov = new TextBox();
            txtDestino = new TextBox();
            txtModalidad = new TextBox();
            txtTipoCaja = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 14);
            label1.Name = "label1";
            label1.Size = new Size(177, 21);
            label1.TabIndex = 0;
            label1.Text = "Seguimiento de Guías";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 51);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Número de Guía";
            // 
            // numeroGuia
            // 
            numeroGuia.Location = new Point(33, 68);
            numeroGuia.Margin = new Padding(3, 2, 3, 2);
            numeroGuia.Name = "numeroGuia";
            numeroGuia.Size = new Size(191, 23);
            numeroGuia.TabIndex = 2;
            // 
            // btnBuscarGuia
            // 
            btnBuscarGuia.Location = new Point(238, 68);
            btnBuscarGuia.Margin = new Padding(3, 2, 3, 2);
            btnBuscarGuia.Name = "btnBuscarGuia";
            btnBuscarGuia.Size = new Size(82, 22);
            btnBuscarGuia.TabIndex = 3;
            btnBuscarGuia.Text = "Buscar Guía";
            btnBuscarGuia.UseVisualStyleBackColor = true;
            btnBuscarGuia.Click += btnBuscarGuia_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(187, 104);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 5;
            label3.Text = "Estado Actual";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 104);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 7;
            label4.Text = "Cliente";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(346, 157);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 9;
            label5.Text = "Destino";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(188, 158);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 13;
            label7.Text = "Modalidad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 158);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 11;
            label8.Text = "Tipo de Caja";
            // 
            // listLineaTiempo
            // 
            listLineaTiempo.Columns.AddRange(new ColumnHeader[] { fechaMovimiento, tipoTramo, estado, Origen, Destino, quienRealiza });
            listLineaTiempo.Location = new Point(33, 254);
            listLineaTiempo.Name = "listLineaTiempo";
            listLineaTiempo.Size = new Size(533, 111);
            listLineaTiempo.TabIndex = 42;
            listLineaTiempo.UseCompatibleStateImageBehavior = false;
            listLineaTiempo.View = View.Details;
            listLineaTiempo.SelectedIndexChanged += listView3_SelectedIndexChanged;
            // 
            // fechaMovimiento
            // 
            fechaMovimiento.Text = "Fecha Movimiento";
            fechaMovimiento.Width = 140;
            // 
            // tipoTramo
            // 
            tipoTramo.Text = "Tipo Tramo";
            tipoTramo.Width = 95;
            // 
            // estado
            // 
            estado.Text = "Estado";
            estado.Width = 70;
            // 
            // Origen
            // 
            Origen.Text = "Origen";
            Origen.Width = 70;
            // 
            // Destino
            // 
            Destino.Text = "Destino";
            Destino.Width = 70;
            // 
            // quienRealiza
            // 
            quienRealiza.Text = "Quién lo realiza";
            quienRealiza.Width = 120;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 217);
            label6.Name = "label6";
            label6.Size = new Size(133, 21);
            label6.TabIndex = 43;
            label6.Text = "Línea de tiempo";
            label6.Click += label6_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(346, 104);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 44;
            label9.Text = "Fecha Último Mov.";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(33, 126);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(140, 23);
            txtCliente.TabIndex = 46;
            // 
            // txtEstadoActual
            // 
            txtEstadoActual.Location = new Point(187, 126);
            txtEstadoActual.Name = "txtEstadoActual";
            txtEstadoActual.ReadOnly = true;
            txtEstadoActual.Size = new Size(140, 23);
            txtEstadoActual.TabIndex = 47;
            // 
            // txtFechaUltimoMov
            // 
            txtFechaUltimoMov.Location = new Point(346, 126);
            txtFechaUltimoMov.Name = "txtFechaUltimoMov";
            txtFechaUltimoMov.ReadOnly = true;
            txtFechaUltimoMov.Size = new Size(140, 23);
            txtFechaUltimoMov.TabIndex = 48;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(347, 182);
            txtDestino.Name = "txtDestino";
            txtDestino.ReadOnly = true;
            txtDestino.Size = new Size(140, 23);
            txtDestino.TabIndex = 51;
            // 
            // txtModalidad
            // 
            txtModalidad.Location = new Point(188, 182);
            txtModalidad.Name = "txtModalidad";
            txtModalidad.ReadOnly = true;
            txtModalidad.Size = new Size(140, 23);
            txtModalidad.TabIndex = 50;
            // 
            // txtTipoCaja
            // 
            txtTipoCaja.Location = new Point(34, 182);
            txtTipoCaja.Name = "txtTipoCaja";
            txtTipoCaja.ReadOnly = true;
            txtTipoCaja.Size = new Size(140, 23);
            txtTipoCaja.TabIndex = 49;
            // 
            // GuiaEstadoHistorialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 396);
            Controls.Add(txtDestino);
            Controls.Add(txtModalidad);
            Controls.Add(txtTipoCaja);
            Controls.Add(txtFechaUltimoMov);
            Controls.Add(txtEstadoActual);
            Controls.Add(txtCliente);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(listLineaTiempo);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnBuscarGuia);
            Controls.Add(numeroGuia);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "guiaEstadoHistorialForm";
            Text = "guiaEstadoHistorialForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox numeroGuia;
        private Button btnBuscarGuia;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private ListView listLineaTiempo;
        private ColumnHeader tipoTramo;
        private ColumnHeader estado;
        private Label label6;
        private ColumnHeader Origen;
        private ColumnHeader Destino;
        private ColumnHeader fechaMovimiento;
        private ColumnHeader quienRealiza;
        private Label label9;
        private TextBox txtCliente;
        private TextBox txtEstadoActual;
        private TextBox txtFechaUltimoMov;
        private TextBox txtDestino;
        private TextBox txtModalidad;
        private TextBox txtTipoCaja;
    }
}