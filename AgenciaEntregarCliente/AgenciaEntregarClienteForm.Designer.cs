namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    partial class AgenciaEntregarClienteForm
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
            btnBuscarEncomiendaDestinatario = new Button();
            txtDniDestinatario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lvEncomiendas = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            btnConfirmarEntrega = new Button();
            columnHeader4 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarEncomiendaDestinatario);
            groupBox1.Controls.Add(txtDniDestinatario);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(39, 95);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(653, 125);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Destinatario";
            // 
            // btnBuscarEncomiendaDestinatario
            // 
            btnBuscarEncomiendaDestinatario.Location = new Point(368, 43);
            btnBuscarEncomiendaDestinatario.Name = "btnBuscarEncomiendaDestinatario";
            btnBuscarEncomiendaDestinatario.Size = new Size(234, 51);
            btnBuscarEncomiendaDestinatario.TabIndex = 2;
            btnBuscarEncomiendaDestinatario.Text = "Buscar Encomiendas a Entregar";
            btnBuscarEncomiendaDestinatario.UseVisualStyleBackColor = true;
            btnBuscarEncomiendaDestinatario.Click += btnBuscarEncomiendaDestinatario_Click_1;
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
            label1.Location = new Point(23, 41);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(190, 36);
            label2.Name = "label2";
            label2.Size = new Size(399, 32);
            label2.TabIndex = 46;
            label2.Text = "🎯 Entrega de pedido en Agencia";
            // 
            // lvEncomiendas
            // 
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lvEncomiendas.Location = new Point(39, 257);
            lvEncomiendas.Margin = new Padding(3, 4, 3, 4);
            lvEncomiendas.Name = "lvEncomiendas";
            lvEncomiendas.Size = new Size(653, 143);
            lvEncomiendas.TabIndex = 48;
            lvEncomiendas.UseCompatibleStateImageBehavior = false;
            lvEncomiendas.View = View.Details;
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
            // columnHeader5
            // 
            columnHeader5.Text = "Fecha";
            columnHeader5.Width = 120;
            // 
            // btnConfirmarEntrega
            // 
            btnConfirmarEntrega.Location = new Point(243, 425);
            btnConfirmarEntrega.Name = "btnConfirmarEntrega";
            btnConfirmarEntrega.Size = new Size(234, 68);
            btnConfirmarEntrega.TabIndex = 45;
            btnConfirmarEntrega.Text = "Confirmar Entrega";
            btnConfirmarEntrega.UseVisualStyleBackColor = true;
            btnConfirmarEntrega.Click += btnConfirmarEntrega_Click_1;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "CUIT Remitente";
            columnHeader4.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "DNI Destinatario";
            columnHeader3.Width = 160;
            // 
            // AgenciaEntregarClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(742, 548);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(lvEncomiendas);
            Controls.Add(btnConfirmarEntrega);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AgenciaEntregarClienteForm";
            Text = "AgenciaEntregarClienteForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnBuscarEncomiendaDestinatario;
        private TextBox txtDniDestinatario;
        private Label label1;
        private Label label2;
        private ListView lvEncomiendas;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader5;
        private Button btnConfirmarEntrega;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}