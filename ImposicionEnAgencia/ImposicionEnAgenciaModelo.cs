using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public class ImposicionEnAgenciaModelo
    {
        private int _contadorGuias = 1;
        private readonly Dictionary<string, ClienteEnt> _clientesPorCUIT = new();
        public Dictionary<string, GuiaEnt> Guias { get; } = new();

        public ImposicionEnAgenciaModelo()
        {
            // Clientes precargados
            CrearCliente("20-35123456-7", "Juan Pérez S.A.", "Av. Belgrano 1200", CondicionIVAEnum.ResponsableInscripto);
            CrearCliente("27-40333444-5", "Distribuidora López", "Ruta 9 km 44", CondicionIVAEnum.Monotributo);
            CrearCliente("30-70998877-9", "Agro Sur SRL", "Calle 25 de Mayo 950", CondicionIVAEnum.Exento);
        }

        // ======================================================
        // CLIENTES
        // ======================================================
        public bool TryGetCliente(string cuit, out ClienteEnt cliente)
            => _clientesPorCUIT.TryGetValue(NormalizarCUIT(cuit), out cliente);

        public void CrearCliente(string cuit, string razonSocial, string domicilioFiscal, CondicionIVAEnum condicion)
        {
            if (string.IsNullOrWhiteSpace(cuit) || !EsCUITValido(cuit))
                throw new ArgumentException("El CUIT es obligatorio y debe tener 11 dígitos (con o sin guiones).");
            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social es obligatoria.");
            if (ContieneNumeros(razonSocial))
                throw new ArgumentException("La razón social no puede contener números.");

            var key = NormalizarCUIT(cuit);
            _clientesPorCUIT[key] = new ClienteEnt
            {
                Cuit = key,
                RazonSocial = razonSocial.Trim(),
                DomicilioFiscal = domicilioFiscal?.Trim(),
                CondicionIVA = condicion,
                ConvenioVigente = true
            };
        }

        // ======================================================
        // GUÍAS
        // ======================================================
        public GuiaEnt CrearGuia(
            string cuitRemitente,
            DireccionEnt origen,
            DireccionEnt destino,
            TamañoCajaEnum tamaño,
            EstadoActualEnum estado = EstadoActualEnum.EnAgencia_ListaParaRetirar)
        {
            string errores = ValidarCampos(cuitRemitente, origen, destino);
            if (!string.IsNullOrEmpty(errores))
                throw new ArgumentException(errores);

            if (!TryGetCliente(cuitRemitente, out var clienteRemitente))
                throw new ArgumentException($"No se encontró el cliente con CUIT {cuitRemitente}");

            var guia = new GuiaEnt
            {
                NumeroGuia = GenerarNumeroGuia("AGC01"),
                FechaImposicion = DateTime.Now,
                EstadoActual = estado,
                TamañoCaja = tamaño,
                Origen = origen,
                Destino = destino,
                HojaDeRuta = null
            };

            Guias[guia.NumeroGuia] = guia;
            return guia;
        }

        // ======================================================
        // VALIDACIONES
        // ======================================================
        private string ValidarCampos(string cuitR, DireccionEnt origen, DireccionEnt destino)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(cuitR))
                sb.AppendLine("- CUIT faltante.");
            else if (!EsCUITValido(cuitR))
                sb.AppendLine("- CUIT inválido (ej: 20-35123456-7 o 20351234567).");

            if (origen == null)
                sb.AppendLine("- La dirección de origen es obligatoria.");
            if (destino == null)
                sb.AppendLine("- La dirección de destino es obligatoria.");

            if (destino != null)
            {
                if (destino.CodigoPostal <= 0)
                    sb.AppendLine("- Código postal del destino inválido.");
                if (string.IsNullOrWhiteSpace(destino.Localidad))
                    sb.AppendLine("- La localidad de destino es obligatoria.");
            }

            return sb.ToString();
        }

        // ======================================================
        // AUXILIARES
        // ======================================================
        private string GenerarNumeroGuia(string prefijo)
            => $"{prefijo}-{_contadorGuias++.ToString("D4")}";

        private static string NormalizarCUIT(string cuit)
            => cuit?.Replace("-", "").Trim() ?? "";

        private static bool EsCUITValido(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;
            cuit = cuit.Replace("-", "").Trim();
            return cuit.Length == 11 && cuit.All(char.IsDigit);
        }

        private static bool ContieneNumeros(string v)
            => !string.IsNullOrWhiteSpace(v) && v.Any(char.IsDigit);
    }
}
