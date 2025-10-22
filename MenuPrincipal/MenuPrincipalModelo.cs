using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAI_GrupoA_.MenuPrincipal
{
    internal class MenuPrincipalModelo
    {
        // Usuarios ficticios para la demo
        private readonly Dictionary<string, string> _usuariosPorRol = new()
        {
            { "admin.finanzas", "financiero" },
            { "operador.logistica", "logistica" },
        };

        private string _usuarioActual;

        // ✅ Validar si el usuario tiene permiso
        public bool TieneAcceso(string seccion)
        {
            if (string.IsNullOrEmpty(_usuarioActual))
            {
                MessageBox.Show("Debe iniciar sesión.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var rol = _usuariosPorRol[_usuarioActual];

            // Admin financiera → solo Finanzas
            if (rol == "financiero" && (seccion != "Facturación" && seccion != "Reportes"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Logística → todo excepto finanzas
            if (rol == "logistica" && (seccion == "Facturación" || seccion == "Reportes"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Simula login (en realidad después vendría desde tu formulario LogIn)
        public bool IniciarSesion(string usuario)
        {
            if (!_usuariosPorRol.ContainsKey(usuario))
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _usuarioActual = usuario;
            return true;
        }

        public string ObtenerRolActual()
        {
            return _usuarioActual != null ? _usuariosPorRol[_usuarioActual] : "Sin sesión";
        }
    }
}