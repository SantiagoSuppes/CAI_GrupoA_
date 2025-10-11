namespace GrupoA.logIn
{
    partial class logInForm
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
            label2 = new Label();
            usuarioTextBox = new TextBox();
            contraseñaTextBox = new TextBox();
            label3 = new Label();
            ingresarButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 9);
            label1.Name = "label1";
            label1.Size = new Size(223, 41);
            label1.TabIndex = 0;
            label1.Text = "Inicio de sesión";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(contraseñaTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(usuarioTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(205, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 208);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Credencial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 34);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 0;
            label2.Text = "Usuario";
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(22, 57);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(330, 27);
            usuarioTextBox.TabIndex = 1;
            // 
            // contraseñaTextBox
            // 
            contraseñaTextBox.Location = new Point(22, 133);
            contraseñaTextBox.Name = "contraseñaTextBox";
            contraseñaTextBox.Size = new Size(330, 27);
            contraseñaTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 110);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // ingresarButton
            // 
            ingresarButton.Location = new Point(283, 278);
            ingresarButton.Name = "ingresarButton";
            ingresarButton.Size = new Size(214, 49);
            ingresarButton.TabIndex = 2;
            ingresarButton.Text = "Ingresar";
            ingresarButton.UseVisualStyleBackColor = true;
            ingresarButton.Click += ingresarButton_Click;
            // 
            // logInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ingresarButton);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "logInForm";
            Text = "logInForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox contraseñaTextBox;
        private Label label3;
        private TextBox usuarioTextBox;
        private Button ingresarButton;
    }
}