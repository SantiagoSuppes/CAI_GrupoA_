namespace CAI_GrupoA_.CargasYDescargas
{
    partial class CargasYDescargasForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            txtEmpresa = new TextBox();
            label5 = new Label();
            BuscarBtn = new Button();
            txtPatente = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            listView2 = new ListView();
            Guia = new ColumnHeader();
            Destinatario2 = new ColumnHeader();
            Remitente2 = new ColumnHeader();
            EstadoActual2 = new ColumnHeader();
            listView1 = new ListView();
            Destinatario = new ColumnHeader();
            Remitente = new ColumnHeader();
            EstadoActual = new ColumnHeader();
            NDeGuia = new ColumnHeader();
            label4 = new Label();
            label3 = new Label();
            button2 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtEmpresa);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(BuscarBtn);
            panel1.Controls.Add(txtPatente);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 74);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 66);
            panel1.TabIndex = 1;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(400, 16);
            txtEmpresa.Margin = new Padding(4, 3, 4, 3);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.ReadOnly = true;
            txtEmpresa.Size = new Size(116, 23);
            txtEmpresa.TabIndex = 4;
            txtEmpresa.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(329, 22);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 3;
            label5.Text = "Empresa";
            // 
            // BuscarBtn
            // 
            BuscarBtn.Location = new Point(200, 16);
            BuscarBtn.Margin = new Padding(4, 3, 4, 3);
            BuscarBtn.Name = "BuscarBtn";
            BuscarBtn.Size = new Size(88, 27);
            BuscarBtn.TabIndex = 2;
            BuscarBtn.Text = "Buscar";
            BuscarBtn.UseVisualStyleBackColor = true;
            BuscarBtn.Click += button1_Click;
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(76, 16);
            txtPatente.Margin = new Padding(4, 3, 4, 3);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(116, 23);
            txtPatente.TabIndex = 1;
            txtPatente.TextChanged += txtPatente_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 22);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Patente";
            // 
            // panel2
            // 
            panel2.Controls.Add(listView2);
            panel2.Controls.Add(listView1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(21, 163);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(565, 361);
            panel2.TabIndex = 2;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { Guia, Destinatario2, Remitente2, EstadoActual2 });
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(20, 219);
            listView2.Margin = new Padding(4, 3, 4, 3);
            listView2.Name = "listView2";
            listView2.Size = new Size(524, 111);
            listView2.TabIndex = 5;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // Guia
            // 
            Guia.Text = "N° de Guia";
            Guia.Width = 110;
            // 
            // Destinatario2
            // 
            Destinatario2.Text = "Destinatario";
            Destinatario2.Width = 110;
            // 
            // Remitente2
            // 
            Remitente2.Text = "Remitente";
            Remitente2.Width = 110;
            // 
            // EstadoActual2
            // 
            EstadoActual2.Text = "Estado Actual";
            EstadoActual2.Width = 190;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Destinatario, Remitente, EstadoActual, NDeGuia });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(20, 39);
            listView1.Margin = new Padding(4, 3, 4, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(524, 118);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Destinatario
            // 
            Destinatario.DisplayIndex = 1;
            Destinatario.Text = "Destinatario";
            Destinatario.Width = 110;
            // 
            // Remitente
            // 
            Remitente.DisplayIndex = 2;
            Remitente.Text = "Remitente";
            Remitente.Width = 110;
            // 
            // EstadoActual
            // 
            EstadoActual.DisplayIndex = 3;
            EstadoActual.Text = "Estado Actual";
            EstadoActual.Width = 190;
            // 
            // NDeGuia
            // 
            NDeGuia.DisplayIndex = 0;
            NDeGuia.Text = "N° de Guia";
            NDeGuia.Width = 110;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 182);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 19);
            label4.TabIndex = 1;
            label4.Text = "Cargar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 14);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 19);
            label3.TabIndex = 0;
            label3.Text = "Descargar";
            // 
            // button2
            // 
            button2.Location = new Point(498, 548);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(88, 27);
            button2.TabIndex = 3;
            button2.Text = "Aceptar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(509, 28);
            label1.TabIndex = 0;
            label1.Text = "🚛 Carga / Descarga de pedidos larga distancia";
            // 
            // CargasYDescargasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(607, 612);
            Controls.Add(button2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CargasYDescargasForm";
            Text = "Cargas y descargas";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BuscarBtn;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Destinatario;
        private System.Windows.Forms.ColumnHeader Remitente;
        private System.Windows.Forms.ColumnHeader EstadoActual;
        private System.Windows.Forms.ColumnHeader NDeGuia;
        private System.Windows.Forms.ColumnHeader Guia;
        private System.Windows.Forms.ColumnHeader Destinatario2;
        private System.Windows.Forms.ColumnHeader Remitente2;
        private System.Windows.Forms.ColumnHeader EstadoActual2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmpresa;
        private Button button1;
        private Label label1;
    }
}

