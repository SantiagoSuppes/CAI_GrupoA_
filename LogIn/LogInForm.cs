using CAI_GrupoA_.MenuPrincipal;
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

        private LogInModelo logInModelo = new LogInModelo();

        private void ingresarButton_Click(object sender, EventArgs e)
        {

            Usuario usuarioIngresado = new Usuario
            {
                usuario = usuarioTextBox.Text,
                contraseña = contraseñaTextBox.Text
            };

            bool accesoConcedido = logInModelo.ValidarUsuario(usuarioIngresado);

            if (accesoConcedido)
            {
                MenuPrincipalForm menu = new MenuPrincipalForm();
                menu.Show();

                Hide();
            }
        }
    }
}
