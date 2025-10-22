using System;
using System.Collections.Generic;
using System.Linq;
using CAI_GrupoA_.Entidades;


namespace CAI_GrupoA_.CargasYDescargas
{
    internal class CargasYDescargasModelo
    {
        public List<GuiaEnt> Guias { get; private set; } = new();
        public TransportistaEnt? TransportistaActual { get; private set; }

        //  Validar formato de patente (sin MessageBox)
        public (bool exito, string mensaje) ValidarPatente(string patente)
        {
            if (string.IsNullOrWhiteSpace(patente))
                return (false, "Debe ingresar una patente.");

            if (patente.Length != 8 || patente.Count(c => c == '-') != 2)
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
        private List<GuiaEnt> ObtenerGuiasPorPatente(string patente)
        {
            return patente switch
            {
                "AB-123-CD" => new List<GuiaEnt>
                {
                    new() { NGuia = "G001", Destinatario = "Mariana Torres", Remitente = "Cliente A", Estado = "Pendiente", EsCarga = false },
                    new() { NGuia = "G002", Destinatario = "Julián Gómez", Remitente = "Cliente B", Estado = "Pendiente", EsCarga = true },
                    new() { NGuia = "G003", Destinatario = "Lucía Fernández", Remitente = "Cliente C", Estado = "Pendiente", EsCarga = true },
                    new() { NGuia = "G004", Destinatario = "Santiago Romero", Remitente = "Cliente D", Estado = "Pendiente", EsCarga = false }
                },
                "AC-456-BD" => new List<GuiaEnt>
                {
                    new() { NGuia = "G010", Destinatario = "Paula Domínguez", Remitente = "Cliente E", Estado = "Pendiente", EsCarga = false },
                    new() { NGuia = "G011", Destinatario = "Martín Acosta", Remitente = "Cliente F", Estado = "Pendiente", EsCarga = true },
                    new() { NGuia = "G012", Destinatario = "Valeria Quiroga", Remitente = "Cliente G", Estado = "Pendiente", EsCarga = false }
                },
                "AA-111-AA" => new List<GuiaEnt>
                {
                    new() { NGuia = "G020", Destinatario = "Federico Rivas", Remitente = "Cliente H", Estado = "Pendiente", EsCarga = true },
                    new() { NGuia = "G021", Destinatario = "Agustina López", Remitente = "Cliente I", Estado = "Pendiente", EsCarga = false },
                    new() { NGuia = "G022", Destinatario = "Tomás Benítez", Remitente = "Cliente J", Estado = "Pendiente", EsCarga = true },
                    new() { NGuia = "G023", Destinatario = "Carolina Méndez", Remitente = "Cliente K", Estado = "Pendiente", EsCarga = false }
                },
                _ => new List<GuiaEnt>()
            };
        }

        // Datos simulados de transportista
        private TransportistaEnt ObtenerTransportistaPorPatente(string patente)
        {
            var empresas = new Dictionary<string, string>
            {
                { "AB-123-CD", "Transporte López S.A." },
                { "AC-456-BD", "Logística Pérez SRL" },
                { "AA-111-AA", "Camiones del Sur" }
            };

            return new TransportistaEnt
            {
                Nombre = "Juan Pérez",
                Empresa = empresas.ContainsKey(patente) ? empresas[patente] : "",
                Patente = patente,
                Cuit = "20-12345678-9"
            };
        }

        // Registrar operación
        public (bool exito, string mensaje) RegistrarCargaDescarga(List<GuiaEnt> guiasSeleccionadas)
        {
            if (guiasSeleccionadas.Count == 0)
                return (false, "Debe haber al menos una guía para registrar la operación.");

            // Simulación exitosa
            return (true, "Estados actualizados correctamente.");
        }
    }
}
