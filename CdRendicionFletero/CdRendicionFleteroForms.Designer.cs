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
            ListViewItem listViewItem1 = new ListViewItem("FR001");
            ListViewItem listViewItem2 = new ListViewItem("HDRDF001");
            ListViewItem listViewItem3 = new ListViewItem("HDRDF002");
            ListViewItem listViewItem4 = new ListViewItem("HDRDF003");
            ListViewItem listViewItem5 = new ListViewItem("HDRDF004");
            ListViewItem listViewItem6 = new ListViewItem("HDRDF005");
            ListViewItem listViewItem7 = new ListViewItem("FD001");
            ListViewItem listViewItem8 = new ListViewItem("FR001");
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
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            label4 = new Label();
            groupBox4 = new GroupBox();
            label6 = new Label();
            listView3 = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            label5 = new Label();
            button2 = new Button();
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
            label1.Location = new Point(109, 24);
            label1.Name = "label1";
            label1.Size = new Size(601, 38);
            label1.TabIndex = 0;
            label1.Text = "Centro de Distribución - Rendición de Fleteros";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarViajesAsignados);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtDniFletero);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(795, 127);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Fletero";
            // 
            // btnBuscarViajesAsignados
            // 
            btnBuscarViajesAsignados.Location = new Point(484, 41);
            btnBuscarViajesAsignados.Name = "btnBuscarViajesAsignados";
            btnBuscarViajesAsignados.Size = new Size(256, 50);
            btnBuscarViajesAsignados.TabIndex = 2;
            btnBuscarViajesAsignados.Text = "Buscar viajes asignados";
            btnBuscarViajesAsignados.UseVisualStyleBackColor = true;
            btnBuscarViajesAsignados.Click += btnBuscarViajesAsignados_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 41);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 1;
            label2.Text = "DNI";
            // 
            // txtDniFletero
            // 
            txtDniFletero.Location = new Point(56, 64);
            txtDniFletero.Name = "txtDniFletero";
            txtDniFletero.Size = new Size(384, 27);
            txtDniFletero.TabIndex = 0;
            txtDniFletero.TextChanged += txtDniFletero_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lvDetalle);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 211);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(795, 196);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Encomiendas a recibir";
            // 
            // lvDetalle
            // 
            lvDetalle.CheckBoxes = true;
            lvDetalle.Columns.AddRange(new ColumnHeader[] { nguia, tipoCaja, estado, domicilio });
            listViewItem1.StateImageIndex = 0;
            lvDetalle.Items.AddRange(new ListViewItem[] { listViewItem1 });
            lvDetalle.Location = new Point(24, 52);
            lvDetalle.Margin = new Padding(3, 4, 3, 4);
            lvDetalle.Name = "lvDetalle";
            lvDetalle.Size = new Size(746, 127);
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
            label3.Location = new Point(24, 28);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 3;
            label3.Text = "Detalle de Guías";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listView1);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 413);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(795, 187);
            groupBox3.TabIndex = 44;
            groupBox3.TabStop = false;
            groupBox3.Text = "Entregas en ejecución";
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader1, columnHeader3, columnHeader4 });
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6 });
            listView1.Location = new Point(24, 52);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(746, 120);
            listView1.TabIndex = 43;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "ID Distribución";
            columnHeader2.Width = 120;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 2;
            columnHeader1.Text = "Domicilio";
            columnHeader1.Width = 250;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 3;
            columnHeader3.Text = "CUIT Cliente";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 1;
            columnHeader4.Text = "Estado";
            columnHeader4.Width = 250;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 28);
            label4.Name = "label4";
            label4.Size = new Size(271, 20);
            label4.TabIndex = 3;
            label4.Text = "Detalle de hojas de ruta de distribución";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(listView3);
            groupBox4.Controls.Add(listView2);
            groupBox4.Controls.Add(label5);
            groupBox4.Location = new Point(12, 606);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(795, 291);
            groupBox4.TabIndex = 45;
            groupBox4.TabStop = false;
            groupBox4.Text = "Viajes a realizar";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 154);
            label6.Name = "label6";
            label6.Size = new Size(217, 20);
            label6.TabIndex = 46;
            label6.Text = "Detalle de Guías para Distribuir";
            // 
            // listView3
            // 
            listView3.CheckBoxes = true;
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listViewItem7.StateImageIndex = 0;
            listView3.Items.AddRange(new ListViewItem[] { listViewItem7 });
            listView3.Location = new Point(24, 178);
            listView3.Margin = new Padding(3, 4, 3, 4);
            listView3.Name = "listView3";
            listView3.Size = new Size(746, 93);
            listView3.TabIndex = 45;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "N° Guía";
            columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Tipo De Caja";
            columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Estado";
            columnHeader11.Width = 250;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Domicilio";
            columnHeader12.Width = 250;
            // 
            // listView2
            // 
            listView2.CheckBoxes = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            listViewItem8.StateImageIndex = 0;
            listView2.Items.AddRange(new ListViewItem[] { listViewItem8 });
            listView2.Location = new Point(24, 52);
            listView2.Margin = new Padding(3, 4, 3, 4);
            listView2.Name = "listView2";
            listView2.Size = new Size(746, 94);
            listView2.TabIndex = 44;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "N° Guía";
            columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Tipo De Caja";
            columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Estado";
            columnHeader7.Width = 250;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Domicilio";
            columnHeader8.Width = 250;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 28);
            label5.Name = "label5";
            label5.Size = new Size(204, 20);
            label5.TabIndex = 3;
            label5.Text = "Detalle de Guías para Retirar ";
            // 
            // button2
            // 
            button2.Location = new Point(643, 903);
            button2.Name = "button2";
            button2.Size = new Size(164, 53);
            button2.TabIndex = 46;
            button2.Text = "Volver al Menú";
            button2.UseVisualStyleBackColor = true;
            // 
            // CdRendicionFleteroForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 962);
            Controls.Add(button2);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
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
        private ListView listView1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label4;
        private GroupBox groupBox4;
        private Label label5;
        private Label label6;
        private ListView listView3;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button button2;
    }
}