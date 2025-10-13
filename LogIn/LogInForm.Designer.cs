namespace CAI_GrupoA_.LogIn
{
    partial class LogInForm
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
            contraseñaTextBox = new TextBox();
            label3 = new Label();
            usuarioTextBox = new TextBox();
            label2 = new Label();
            ingresarButton = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(contraseñaTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(usuarioTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(53, 68);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(328, 156);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Credencial";
            // 
            // contraseñaTextBox
            // 
            contraseñaTextBox.Location = new Point(19, 100);
            contraseñaTextBox.Margin = new Padding(3, 2, 3, 2);
            contraseñaTextBox.Name = "contraseñaTextBox";
            contraseñaTextBox.Size = new Size(289, 23);
            contraseñaTextBox.TabIndex = 3;
            contraseñaTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 82);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(19, 43);
            usuarioTextBox.Margin = new Padding(3, 2, 3, 2);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(289, 23);
            usuarioTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 26);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Usuario";
            // 
            // ingresarButton
            // 
            ingresarButton.Location = new Point(121, 237);
            ingresarButton.Margin = new Padding(3, 2, 3, 2);
            ingresarButton.Name = "ingresarButton";
            ingresarButton.Size = new Size(187, 37);
            ingresarButton.TabIndex = 2;
            ingresarButton.Text = "Ingresar";
            ingresarButton.UseVisualStyleBackColor = true;
            ingresarButton.Click += ingresarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(107, 24);
            label1.Name = "label1";
            label1.Size = new Size(220, 25);
            label1.TabIndex = 5;
            label1.Text = "TUTASA - Iniciar Sesión";
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 301);
            Controls.Add(label1);
            Controls.Add(ingresarButton);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LogInForm";
            Text = "logInForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label2;
        private TextBox contraseñaTextBox;
        private Label label3;
        private TextBox usuarioTextBox;
        private Button ingresarButton;
        private Label label1;
    }
}