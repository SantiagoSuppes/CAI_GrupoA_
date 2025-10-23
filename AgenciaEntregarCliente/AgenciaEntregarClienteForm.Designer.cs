namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    partial class AgenciaEntregarClienteForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnBuscarEncomiendaDestinatario = new Button();
            txtDniDestinatario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lvEncomiendas = new ListView();
            btnConfirmarEntrega = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscarEncomiendaDestinatario);
            groupBox1.Controls.Add(txtDniDestinatario);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(34, 72);
            groupBox1.Size = new Size(670, 100);
            groupBox1.Text = "Datos del destinatario";
            // 
            // btnBuscarEncomiendaDestinatario
            // 
            btnBuscarEncomiendaDestinatario.Location = new Point(380, 40);
            btnBuscarEncomiendaDestinatario.Size = new Size(250, 35);
            btnBuscarEncomiendaDestinatario.Text = "Buscar encomiendas";
            btnBuscarEncomiendaDestinatario.UseVisualStyleBackColor = true;
            // 
            // txtDniDestinatario
            // 
            txtDniDestinatario.Location = new Point(20, 45);
            txtDniDestinatario.Size = new Size(300, 27);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 25);
            label1.Text = "DNI del destinatario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(180, 20);
            label2.Text = "🎯 Entrega de pedido en Agencia";
            // 
            // lvEncomiendas
            // 
            lvEncomiendas.Location = new Point(34, 190);
            lvEncomiendas.Size = new Size(670, 200);
            lvEncomiendas.FullRowSelect = true;
            lvEncomiendas.GridLines = true;
            lvEncomiendas.View = View.Details;
            // 
            // btnConfirmarEntrega
            // 
            btnConfirmarEntrega.Location = new Point(260, 410);
            btnConfirmarEntrega.Size = new Size(230, 50);
            btnConfirmarEntrega.Text = "Confirmar entrega";
            btnConfirmarEntrega.UseVisualStyleBackColor = true;
            // 
            // AgenciaEntregarClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 500);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(lvEncomiendas);
            Controls.Add(btnConfirmarEntrega);
            Text = "Entrega de pedido en Agencia";
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
        private Button btnConfirmarEntrega;
    }
}
