namespace GrupoA.cdEntregarCliente
{
    partial class cdEntregarClienteForms
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
            ListViewItem listViewItem6 = new ListViewItem("FR001");
            ListViewItem listViewItem7 = new ListViewItem("FR002");
            ListViewItem listViewItem8 = new ListViewItem("FR003");
            ListViewItem listViewItem9 = new ListViewItem("FR004");
            ListViewItem listViewItem10 = new ListViewItem("FR005");
            label2 = new Label();
            groupBox1 = new GroupBox();
            btnBuscarEncomiendaDestinatario = new Button();
            txtDniDestinatario = new TextBox();
            label1 = new Label();
            btnConfirmarEntrega = new Button();
            listViewEncomiendas = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            button3 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(179, 9);
            label2.Name = "label2";
            label2.Size = new Size(397, 32);
            label2.TabIndex = 6;
            label2.Text = "Centro de Distribución - Entregas";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarEncomiendaDestinatario);
            groupBox1.Controls.Add(txtDniDestinatario);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(56, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(653, 125);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Destinatario";
            // 
            // btnBuscarEncomiendaDestinatario
            // 
            btnBuscarEncomiendaDestinatario.Location = new Point(368, 42);
            btnBuscarEncomiendaDestinatario.Name = "btnBuscarEncomiendaDestinatario";
            btnBuscarEncomiendaDestinatario.Size = new Size(234, 50);
            btnBuscarEncomiendaDestinatario.TabIndex = 2;
            btnBuscarEncomiendaDestinatario.Text = "Buscar Encomiendas a Entregar";
            btnBuscarEncomiendaDestinatario.UseVisualStyleBackColor = true;
            btnBuscarEncomiendaDestinatario.Click += btnBuscarEncomiendaDestinatario_Click;
            // 
            // txtDniDestinatario
            // 
            txtDniDestinatario.Location = new Point(23, 65);
            txtDniDestinatario.Name = "txtDniDestinatario";
            txtDniDestinatario.Size = new Size(292, 27);
            txtDniDestinatario.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 42);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "DNI";
            // 
            // btnConfirmarEntrega
            // 
            btnConfirmarEntrega.Location = new Point(260, 392);
            btnConfirmarEntrega.Name = "btnConfirmarEntrega";
            btnConfirmarEntrega.Size = new Size(234, 68);
            btnConfirmarEntrega.TabIndex = 3;
            btnConfirmarEntrega.Text = "Confirmar Entrega";
            btnConfirmarEntrega.UseVisualStyleBackColor = true;
            btnConfirmarEntrega.Click += btnConfirmarEntrega_Click;
            // 
            // listViewEncomiendas
            // 
            listViewEncomiendas.CheckBoxes = true;
            listViewEncomiendas.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.StateImageIndex = 0;
            listViewItem9.StateImageIndex = 0;
            listViewItem10.StateImageIndex = 0;
            listViewEncomiendas.Items.AddRange(new ListViewItem[] { listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10 });
            listViewEncomiendas.Location = new Point(56, 224);
            listViewEncomiendas.Margin = new Padding(3, 4, 3, 4);
            listViewEncomiendas.Name = "listViewEncomiendas";
            listViewEncomiendas.Size = new Size(653, 142);
            listViewEncomiendas.TabIndex = 43;
            listViewEncomiendas.UseCompatibleStateImageBehavior = false;
            listViewEncomiendas.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "N° Guía";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Tipo";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "DNI Destinatario";
            columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "CUIT Remitente";
            columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Fecha";
            columnHeader5.Width = 120;
            // 
            // button3
            // 
            button3.Location = new Point(595, 410);
            button3.Name = "button3";
            button3.Size = new Size(114, 50);
            button3.TabIndex = 44;
            button3.Text = "Volver al Menú";
            button3.UseVisualStyleBackColor = true;
            // 
            // cdEntregarClienteForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 472);
            Controls.Add(button3);
            Controls.Add(listViewEncomiendas);
            Controls.Add(btnConfirmarEntrega);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Name = "cdEntregarClienteForms";
            Text = "cdEntregarClienteForms";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtDniDestinatario;
        private Label label1;
        private Button btnBuscarEncomiendaDestinatario;
        private Button btnConfirmarEntrega;
        private ListView listViewEncomiendas;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button button3;
    }
}