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

        public class Cliente
        {
            public string CUIT { get; set; }
            public string Nombre { get; set; }
        }

        private readonly Dictionary<string, Cliente> _clientesPorCUIT = new();

        public GuiasGeneradasEnAgencia()
        {
            CrearCliente("20-35123456-7", "Juan Pérez S.A.");
            CrearCliente("27-40333444-5", "Distribuidora López");
            CrearCliente("30-70998877-9", "Agro Sur SRL");
        }

        public bool TryGetCliente(string cuit, out Cliente cliente)
            => _clientesPorCUIT.TryGetValue(NormalizarCUIT(cuit), out cliente);

        public void CrearCliente(string cuit, string nombre)
        {
            if (string.IsNullOrWhiteSpace(cuit) || !EsCUITValido(cuit))
                throw new ArgumentException("El CUIT es obligatorio y debe tener 11 dígitos (con o sin guiones).");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("La razón social es obligatoria.");
            if (ContieneNumeros(nombre))
                throw new ArgumentException("La razón social no puede contener números.");

            var key = NormalizarCUIT(cuit);
            _clientesPorCUIT[key] = new Cliente { CUIT = key, Nombre = nombre.Trim() };
        }

        private static string NormalizarCUIT(string cuit)
            => cuit?.Replace("-", "").Trim() ?? "";

        private static bool EsCUITValido(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;
            cuit = cuit.Replace("-", "").Trim();
            return cuit.Length == 11 && cuit.All(char.IsDigit);
        }

        public class Encomienda
        {
            public string CUITRemitente { get; set; }
            public string NombreRemitente { get; set; }
            public string NombreDestinatario { get; set; }
            public string DNIDestinatario { get; set; }
            public string TelefonoDestinatario { get; set; }
            public string DomicilioDestinatario { get; set; }
            public string ProvinciaDestinatario { get; set; }
            public string CodigoPostalDestinatario { get; set; }
            public string Tamanio { get; set; }
            public int Cantidad { get; set; }
            public string ModalidadEntrega { get; set; }
            public string AgenciaDestino { get; set; }
            public string CDDestino { get; set; }
            public string Numero { get; set; }
            public DateTime FechaHora { get; set; }
            public string Estado { get; set; } = "En Agencia - Lista para Retirar";
        }

        public Dictionary<string, Encomienda> Guias { get; } = new();

        public Encomienda CrearGuia(
            string cuitR, string nomR, string telR,
            string nomD, string apeD, string dniD, string telD,
            string domicilio, string localidad, string provincia, string cp,
            string tamanio, int cantidad, string modalidad,
            bool omitirValidacionCaja = false,
            bool soloValidar = false)
        {
            string errores = ValidarCampos(cuitR, nomR, nomD, dniD, telD,
                domicilio, localidad, provincia, cp, tamanio, cantidad, modalidad, omitirValidacionCaja);

            if (!string.IsNullOrEmpty(errores))
                throw new ArgumentException(errores);

            if (soloValidar)
                return null;

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

        private string ValidarCampos(string cuitR, string nomR, string nomD, string dniD,
            string telD, string domicilio, string localidad, string provincia, string cp,
            string tamanio, int cantidad, string modalidad, bool omitirValidacionCaja = false)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cuitR))
                sb.AppendLine("- CUIT faltante.");
            else if(!EsCUITValido(cuitR))
                sb.AppendLine("- CUIT inválido (ej: 20-35123456-7 o 20351234567).");
            if (ContieneNumeros(nomR))
                sb.AppendLine("- La razón social no puede contener números.");
            if (string.IsNullOrWhiteSpace(nomD))
                sb.AppendLine("- El nombre del destinatario es obligatorio.");
            if (ContieneNumeros(nomD))
                sb.AppendLine("- El nombre del destinatario no puede contener números.");
            if (string.IsNullOrWhiteSpace(dniD))
                sb.AppendLine("- El DNI del destinatario es obligatorio.");
            else if (!dniD.All(char.IsDigit))
                sb.AppendLine("- El DNI debe contener solo números.");
            else if (dniD.Length < 8 || dniD.Length > 11)
                sb.AppendLine("- El DNI debe tener entre 8 y 11 dígitos.");

            if (string.IsNullOrWhiteSpace(provincia))
                sb.AppendLine("- Debe seleccionar una provincia.");
            if (string.IsNullOrWhiteSpace(localidad))
                sb.AppendLine("- La localidad es obligatoria.");
            else if (ContieneNumeros(localidad))
                sb.AppendLine("- La localidad no puede contener números.");
            if (string.IsNullOrWhiteSpace(cp))
                sb.AppendLine("- El código postal es obligatorio.");
            else if (!cp.All(char.IsDigit))
                sb.AppendLine("- El código postal debe contener solo números.");
            else if (cp.Length < 4 || cp.Length > 5)
                sb.AppendLine("- El código postal debe tener entre 4 y 5 dígitos.");

            if (!omitirValidacionCaja)
            {
                if (string.IsNullOrWhiteSpace(tamanio))
                    sb.AppendLine("- Debe seleccionar tamaño de caja.");
                if (cantidad <= 0)
                    sb.AppendLine("- La cantidad debe ser mayor a cero.");
            }

            return sb.ToString();
        }

        private string GenerarNumeroGuia(string prefijo)
            => $"{prefijo}-{_contadorGuias++.ToString("D4")}";

        private static bool ContieneNumeros(string v) => !string.IsNullOrWhiteSpace(v) && v.Any(char.IsDigit);
    }
}
