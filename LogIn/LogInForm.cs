using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.LogIn
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        class user
        {
            public string usuario { get; set; }
            public string contraseña { get; set; }
        }
        List<user> usuarios = new List<user>();



        private bool validarUsuario(user usuarioIngresado)
        {
            bool flag;
            if (string.IsNullOrEmpty(usuarioIngresado.usuario) || string.IsNullOrEmpty(usuarioIngresado.contraseña))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }
            else if (usuarios.Any(u => u.usuario == usuarioIngresado.usuario && u.contraseña == usuarioIngresado.contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = true;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }

            return flag;
        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            usuarios.Add(new user { usuario = "admin", contraseña = "password" });

            user usuarioIngresado = new user
            {
                usuario = usuarioTextBox.Text,
                contraseña = contraseñaTextBox.Text
            };

            bool accesoConcedido = validarUsuario(usuarioIngresado);

            if (accesoConcedido)
            {
                // Aca se va a abrir el formulario principal de la aplicación.}
            }
        }
    }
}
