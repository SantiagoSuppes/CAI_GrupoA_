using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.LogIn
{
    internal class LogInModelo
    {
        readonly List<Usuario> usuarios = new List<Usuario>();

        public LogInModelo()
        {
            usuarios.Add(new Usuario { usuario = "user", contraseña = "user" });
            usuarios.Add(new Usuario { usuario = "admin", contraseña = "admin" });
            usuarios.Add(new Usuario { usuario = "playero", contraseña = "playero" });
        }

        public bool ValidarUsuario(Usuario usuarioIngresado)
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

    }
}
