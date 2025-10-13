namespace CAI_GrupoA_.CdRendicionFletero
{
    partial class CdRendicionFleteroForms
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
            groupBox1 = new GroupBox();
            btnBuscarViajesAsignados = new Button();
            label2 = new Label();
            txtDniFletero = new TextBox();
            groupBox2 = new GroupBox();
            lvDetalle = new ListView();
            nguia = new ColumnHeader();
            tipoCaja = new ColumnHeader();
            estado = new ColumnHeader();
            domicilio = new ColumnHeader();
            label3 = new Label();
            groupBox3 = new GroupBox();
            lvDistribucionesRealizadas = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            label4 = new Label();
            groupBox4 = new GroupBox();
            lvDistNuevos = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            lvRetirosNuevos = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            label6 = new Label();
            label5 = new Label();
            btnConfirmar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(103, 21);
            label1.Name = "label1";
            label1.Size = new Size(485, 30);
            label1.TabIndex = 0;
            label1.Text = "🚚 Entrega y recepción de pedidos última milla";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarViajesAsignados);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtDniFletero);
            groupBox1.Location = new Point(10, 58);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(696, 95);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Fletero";
            // 
            // btnBuscarViajesAsignados
            // 
            btnBuscarViajesAsignados.Location = new Point(424, 31);
            btnBuscarViajesAsignados.Margin = new Padding(3, 2, 3, 2);
            btnBuscarViajesAsignados.Name = "btnBuscarViajesAsignados";
            btnBuscarViajesAsignados.Size = new Size(224, 38);
            btnBuscarViajesAsignados.TabIndex = 2;
            btnBuscarViajesAsignados.Text = "Buscar viajes asignados";
            btnBuscarViajesAsignados.UseVisualStyleBackColor = true;
            btnBuscarViajesAsignados.Click += btnBuscarViajesAsignados_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 31);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 1;
            label2.Text = "DNI";
            // 
            // txtDniFletero
            // 
            txtDniFletero.Location = new Point(49, 48);
            txtDniFletero.Margin = new Padding(3, 2, 3, 2);
            txtDniFletero.Name = "txtDniFletero";
            txtDniFletero.Size = new Size(336, 23);
            txtDniFletero.TabIndex = 0;
            txtDniFletero.TextChanged += txtDniFletero_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lvDetalle);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(10, 158);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(696, 147);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Guias recibidas";
            // 
            // lvDetalle
            // 
            lvDetalle.CheckBoxes = true;
            lvDetalle.Columns.AddRange(new ColumnHeader[] { nguia, tipoCaja, estado, domicilio });
            lvDetalle.Location = new Point(21, 39);
            lvDetalle.Name = "lvDetalle";
            lvDetalle.Size = new Size(653, 96);
            lvDetalle.TabIndex = 43;
            lvDetalle.UseCompatibleStateImageBehavior = false;
            lvDetalle.View = View.Details;
            // 
            // nguia
            // 
            nguia.Text = "N° Guía";
            nguia.Width = 120;
            // 
            // tipoCaja
            // 
            tipoCaja.Text = "Tipo De Caja";
            tipoCaja.Width = 120;
            // 
            // estado
            // 
            estado.Text = "Estado";
            estado.Width = 250;
            // 
            // domicilio
            // 
            domicilio.Text = "Domicilio";
            domicilio.Width = 250;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 21);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 3;
            label3.Text = "Guías que trajo el fletero";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lvDistribucionesRealizadas);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(10, 310);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(696, 140);
            groupBox3.TabIndex = 44;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hojas de Ruta Cumplidas";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // lvDistribucionesRealizadas
            // 
            lvDistribucionesRealizadas.CheckBoxes = true;
            lvDistribucionesRealizadas.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader1, columnHeader3, columnHeader4 });
            lvDistribucionesRealizadas.Location = new Point(21, 39);
            lvDistribucionesRealizadas.Name = "lvDistribucionesRealizadas";
            lvDistribucionesRealizadas.Size = new Size(653, 91);
            lvDistribucionesRealizadas.TabIndex = 43;
            lvDistribucionesRealizadas.UseCompatibleStateImageBehavior = false;
            lvDistribucionesRealizadas.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "HDR Distribución";
            columnHeader2.Width = 120;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 2;
            columnHeader1.Text = "Estado";
            columnHeader1.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 3;
            columnHeader3.Text = "Domicilio";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 1;
            columnHeader4.Text = "CUIT Cliente";
            columnHeader4.Width = 250;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 21);
            label4.Name = "label4";
            label4.Size = new Size(225, 15);
            label4.TabIndex = 3;
            label4.Text = "Hojas de ruta que trajo firmadas el fletero";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lvDistNuevos);
            groupBox4.Controls.Add(lvRetirosNuevos);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Location = new Point(10, 454);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(696, 218);
            groupBox4.TabIndex = 45;
            groupBox4.TabStop = false;
            groupBox4.Text = "Viaje a realizar";
            // 
            // lvDistNuevos
            // 
            lvDistNuevos.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            lvDistNuevos.Location = new Point(21, 134);
            lvDistNuevos.Name = "lvDistNuevos";
            lvDistNuevos.Size = new Size(653, 74);
            lvDistNuevos.TabIndex = 47;
            lvDistNuevos.UseCompatibleStateImageBehavior = false;
            lvDistNuevos.View = View.Details;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "HDR Distribución";
            columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            columnHeader10.DisplayIndex = 2;
            columnHeader10.Text = "Estado";
            columnHeader10.Width = 250;
            // 
            // columnHeader11
            // 
            columnHeader11.DisplayIndex = 3;
            columnHeader11.Text = "Domicilio";
            columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            columnHeader12.DisplayIndex = 1;
            columnHeader12.Text = "CUIT Cliente";
            columnHeader12.Width = 250;
            // 
            // lvRetirosNuevos
            // 
            lvRetirosNuevos.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            lvRetirosNuevos.Location = new Point(21, 39);
            lvRetirosNuevos.Name = "lvRetirosNuevos";
            lvRetirosNuevos.Size = new Size(653, 74);
            lvRetirosNuevos.TabIndex = 44;
            lvRetirosNuevos.UseCompatibleStateImageBehavior = false;
            lvRetirosNuevos.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "HDR Retiro";
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.DisplayIndex = 2;
            columnHeader6.Text = "Estado";
            columnHeader6.Width = 250;
            // 
            // columnHeader7
            // 
            columnHeader7.DisplayIndex = 3;
            columnHeader7.Text = "Domicilio";
            columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            columnHeader8.DisplayIndex = 1;
            columnHeader8.Text = "CUIT Cliente";
            columnHeader8.Width = 250;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 116);
            label6.Name = "label6";
            label6.Size = new Size(283, 15);
            label6.TabIndex = 46;
            label6.Text = "Lo que el fletero debe entregar en domicilio/agencia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 21);
            label5.Name = "label5";
            label5.Size = new Size(286, 15);
            label5.TabIndex = 3;
            label5.Text = "Lo que el fletero debe ir a buscar a domicilio/agencia";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(540, 687);
            btnConfirmar.Margin = new Padding(3, 2, 3, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(144, 40);
            btnConfirmar.TabIndex = 47;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // CdRendicionFleteroForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(723, 738);
            Controls.Add(btnConfirmar);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CdRendicionFleteroForms";
            Text = "CdRendicionFleteroForms";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button btnBuscarViajesAsignados;
        private Label label2;
        private TextBox txtDniFletero;
        private GroupBox groupBox2;
        private Label label3;
        private ListView lvDetalle;
        private ColumnHeader tipoCaja;
        private ColumnHeader nguia;
        private ColumnHeader estado;
        private ColumnHeader domicilio;
        private GroupBox groupBox3;
        private ListView lvDistribucionesRealizadas;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label4;
        private GroupBox groupBox4;
        private Label label5;
        private Label label6;
        private Button btnConfirmar;
        private ListView lvRetirosNuevos;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ListView lvDistNuevos;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
    }
}