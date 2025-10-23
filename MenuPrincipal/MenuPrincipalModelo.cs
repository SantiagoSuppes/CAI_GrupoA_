using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAI_GrupoA_.MenuPrincipal
{
    internal class MenuPrincipalModelo
    {
        private readonly Dictionary<string, string> _usuariosPorRol = new()
        {
            { "admin.finanzas", "financiero" },
            { "operador.logistica", "logistica" }
        };

        private string? _usuarioActual;

        public bool TieneAcceso(string seccion)
        {
            if (string.IsNullOrEmpty(_usuarioActual))
            {
                MessageBox.Show("Debe iniciar sesión.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var rol = _usuariosPorRol[_usuarioActual];

            if (rol == "financiero" && seccion is not ("Facturación" or "Reportes"))
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rol == "logistica" && seccion is "Facturación" or "Reportes")
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool IniciarSesion(string usuario)
        {
            if (!_usuariosPorRol.ContainsKey(usuario))
            {
                MessageBox.Show("Usuario no encontrado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
