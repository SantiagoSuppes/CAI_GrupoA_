using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CAI_GrupoA_.CargasYDescargas
{
    internal class CargasYDescargasModelo
    {
        public List<Guia> Guias { get; private set; } = new();
        public Transportista? TransportistaActual { get; private set; }

        // ✅ Validar formato de patente con regex
        public (bool exito, string mensaje) ValidarPatente(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
                return (false, "Debe ingresar una patente.");

            var regex = new Regex(@"^[A-Z]{2}-\d{3}-[A-Z]{2}$");
            if (!regex.IsMatch(patente))
                return (false, "El formato de la patente es inválido. Debe ser del tipo 'AA-123-AA'.");

            return (true, "");
        }

        // Buscar guías por patente
        public (bool exito, string mensaje) BuscarGuiasPorPatente(string patente)
        {
            Guias = ObtenerGuiasPorPatente(patente);
            TransportistaActual = ObtenerTransportistaPorPatente(patente);

            if (Guias.Count == 0)
                return (false, "No se encontró información para la patente ingresada.");

            return (true, "");
        }

        // Datos simulados de guías
        private List<Guia> ObtenerGuiasPorPatente(string patente)
        {
            return patente switch
            {
                "AB-123-CD" => new List<Guia>
                {
                    new() { NumeroGuia = "G001", Destinatario = "Mariana Torres", Remitente = "Cliente A", Estado = "Pendiente", EsCarga = false },
                    new() { NumeroGuia = "G002", Destinatario = "Julián Gómez", Remitente = "Cliente B", Estado = "Pendiente", EsCarga = true },
                    new() { NumeroGuia = "G003", Destinatario = "Lucía Fernández", Remitente = "Cliente C", Estado = "Pendiente", EsCarga = true },
                    new() { NumeroGuia = "G004", Destinatario = "Santiago Romero", Remitente = "Cliente D", Estado = "Pendiente", EsCarga = false }
                },
                "AC-456-BD" => new List<Guia>
                {
                    new() { NumeroGuia = "G010", Destinatario = "Paula Domínguez", Remitente = "Cliente E", Estado = "Pendiente", EsCarga = false },
                    new() { NumeroGuia = "G011", Destinatario = "Martín Acosta", Remitente = "Cliente F", Estado = "Pendiente", EsCarga = true },
                    new() { NumeroGuia = "G012", Destinatario = "Valeria Quiroga", Remitente = "Cliente G", Estado = "Pendiente", EsCarga = false }
                },
                "AA-111-AA" => new List<Guia>
                {
                    new() { NumeroGuia = "G020", Destinatario = "Federico Rivas", Remitente = "Cliente H", Estado = "Pendiente", EsCarga = true },
                    new() { NumeroGuia = "G021", Destinatario = "Agustina López", Remitente = "Cliente I", Estado = "Pendiente", EsCarga = false },
                    new() { NumeroGuia = "G022", Destinatario = "Tomás Benítez", Remitente = "Cliente J", Estado = "Pendiente", EsCarga = true },
                    new() { NumeroGuia = "G023", Destinatario = "Carolina Méndez", Remitente = "Cliente K", Estado = "Pendiente", EsCarga = false }
                },
                _ => new List<Guia>()
            };
        }

        // Datos simulados de transportista
        private Transportista ObtenerTransportistaPorPatente(string patente)
        {
            var empresas = new Dictionary<string, string>
            {
                { "AB-123-CD", "Transporte López S.A." },
                { "AC-456-BD", "Logística Pérez SRL" },
                { "AA-111-AA", "Camiones del Sur" }
            };

            return new Transportista
            {
                Nombre = "Juan Pérez",
                Empresa = empresas.ContainsKey(patente) ? empresas[patente] : "",
                Patente = patente,
                Cuit = "20-12345678-9"
            };
        }

        // Registrar operación
        public (bool exito, string mensaje) RegistrarCargaDescarga(List<Guia> guiasSeleccionadas)
        {
            if (guiasSeleccionadas.Count == 0)
                return (false, "Debe haber al menos una guía para registrar la operación.");

            return (true, "Estados actualizados correctamente.");
        }
    }
}
