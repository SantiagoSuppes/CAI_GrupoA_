using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public class GuiasGeneradasEnAgencia
    {
        private int _contadorGuias = 1;

        // ----------------- Clientes -----------------
        public class Cliente
        {
            public string CUIT { get; set; }
            public string Nombre { get; set; }
        }

        // Diccionario de clientes precargados
        private readonly Dictionary<string, Cliente> _clientesPorCUIT = new();

        public GuiasGeneradasEnAgencia()
        {
            // Clientes ficticios precargados
            CrearCliente("20-35123456-7", "Juan Pérez S.A.");
            CrearCliente("27-40333444-5", "Distribuidora López");
            CrearCliente("30-70998877-9", "Agro Sur SRL");
        }

        public bool TryGetCliente(string cuit, out Cliente cliente)
            => _clientesPorCUIT.TryGetValue(NormalizarCUIT(cuit), out cliente);

        public void CrearCliente(string cuit, string nombre)
        {
            if (string.IsNullOrWhiteSpace(cuit) || !EsCUITValido(cuit))
                throw new ArgumentException("El CUIT es obligatorio y debe ser válido (ej: 20-35123456-7).");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("La razón social es obligatoria.");
            if (ContieneNumeros(nombre))
                throw new ArgumentException("La razón social no puede contener números.");

            var key = NormalizarCUIT(cuit);
            _clientesPorCUIT[key] = new Cliente { CUIT = key, Nombre = nombre.Trim() };
        }

        private static string NormalizarCUIT(string cuit) => cuit?.Replace("-", "").Trim() ?? "";

        // ----------------- Encomiendas -----------------
        public class Encomienda
        {
            // Remitente
            public string CUITRemitente { get; set; }
            public string NombreRemitente { get; set; }

            // Destinatario
            public string NombreDestinatario { get; set; }
            public string DNIDestinatario { get; set; }
            public string TelefonoDestinatario { get; set; }
            public string DomicilioDestinatario { get; set; }
            public string ProvinciaDestinatario { get; set; }
            public string CodigoPostalDestinatario { get; set; }

            // Envío
            public string Tamanio { get; set; }
            public int Cantidad { get; set; }
            public string ModalidadEntrega { get; set; }
            public string AgenciaDestino { get; set; }
            public string CDDestino { get; set; }

            // Sistema
            public string Numero { get; set; }
            public DateTime FechaHora { get; set; }
            public string Estado { get; set; } = "En Agencia - Lista para Retirar";
        }

        // Diccionario de guías generadas
        public Dictionary<string, Encomienda> Guias { get; } = new();

        public Encomienda CrearGuia(
            string cuitR, string nomR, string telR,
            string nomD, string apeD, string dniD, string telD,
            string domicilio, string altura, string provincia, string cp,
            string tamanio, int cantidad, string modalidad)
        {
            string errores = ValidarCampos(
                cuitR, nomR, nomD, dniD, telD,
                domicilio, provincia, cp, tamanio, cantidad, modalidad);

            if (!string.IsNullOrEmpty(errores))
                throw new ArgumentException(errores);

            var g = new Encomienda
            {
                Numero = GenerarNumeroGuia("AGC01"),
                FechaHora = DateTime.Now,

                CUITRemitente = NormalizarCUIT(cuitR),
                NombreRemitente = nomR.Trim(),

                NombreDestinatario = nomD.Trim(),
                DNIDestinatario = dniD.Trim(),
                TelefonoDestinatario = telD?.Trim(),
                DomicilioDestinatario = domicilio?.Trim(),
                ProvinciaDestinatario = provincia.Trim(),
                CodigoPostalDestinatario = cp.Trim(),

                Tamanio = tamanio,
                Cantidad = cantidad,
                ModalidadEntrega = modalidad
            };

            Guias[g.Numero] = g;
            return g;
        }

        // ----------------- Validaciones -----------------
        private string ValidarCampos(
            string cuitR, string nomR, string nomD, string dniD, string telD,
            string domicilio, string provincia, string cp,
            string tamanio, int cantidad, string modalidad)
        {
            var sb = new StringBuilder();

            // --- Remitente ---
            if (string.IsNullOrWhiteSpace(cuitR) || !EsCUITValido(cuitR))
                sb.AppendLine("- El CUIT del remitente es obligatorio y debe tener formato válido (ej: 20-35123456-7).");
            if (string.IsNullOrWhiteSpace(nomR))
                sb.AppendLine("- La razón social del remitente es obligatoria.");
            if (ContieneNumeros(nomR))
                sb.AppendLine("- La razón social no puede contener números.");

            // --- Destinatario ---
            if (string.IsNullOrWhiteSpace(nomD))
                sb.AppendLine("- El nombre del destinatario es obligatorio.");
            else if (ContieneNumeros(nomD))
                sb.AppendLine("- El nombre del destinatario no puede contener números.");

            if (string.IsNullOrWhiteSpace(dniD))
                sb.AppendLine("- El DNI del destinatario es obligatorio.");
            else if (dniD.Contains("."))
                sb.AppendLine("- El DNI no debe contener puntos.");
            else if (!SoloDigitos(dniD))
                sb.AppendLine("- El DNI debe contener solo números.");
            else if (dniD.Length < 8 || dniD.Length > 11)
                sb.AppendLine("- El DNI debe tener entre 8 y 11 dígitos.");

            if (!string.IsNullOrWhiteSpace(telD) && !SoloDigitos(telD))
                sb.AppendLine("- El teléfono debe contener solo números.");

            if (string.IsNullOrWhiteSpace(provincia))
                sb.AppendLine("- Debe seleccionar una provincia.");

            if (string.IsNullOrWhiteSpace(cp))
                sb.AppendLine("- El código postal es obligatorio.");
            else if (!SoloDigitos(cp))
                sb.AppendLine("- El código postal debe contener solo números.");
            else if (cp.Length < 4 || cp.Length > 5)
                sb.AppendLine("- El código postal debe tener entre 4 y 5 dígitos.");

            // --- Envío ---
            if (string.IsNullOrWhiteSpace(tamanio))
                sb.AppendLine("- Debe seleccionar el tipo de caja.");
            if (cantidad <= 0)
                sb.AppendLine("- La cantidad debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(modalidad))
                sb.AppendLine("- Debe seleccionar la modalidad de entrega.");

            // --- Modalidad específica ---
            if (modalidad == "Envío a Domicilio" && string.IsNullOrWhiteSpace(domicilio))
                sb.AppendLine("- Debe ingresar la dirección para envío a domicilio.");

            return sb.ToString();
        }

        // ----------------- Auxiliares -----------------
        private string GenerarNumeroGuia(string prefijo)
            => $"{prefijo}-{_contadorGuias++.ToString("D4")}";

        private static bool SoloDigitos(string v) => !string.IsNullOrWhiteSpace(v) && v.All(char.IsDigit);
        private static bool ContieneNumeros(string v) => !string.IsNullOrWhiteSpace(v) && v.Any(char.IsDigit);
        private static bool EsCUITValido(string cuit) => Regex.IsMatch(cuit ?? "", @"^\d{2}-?\d{8}-?\d{1}$");
    }
}

