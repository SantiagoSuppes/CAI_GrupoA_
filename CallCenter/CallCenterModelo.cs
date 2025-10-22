using CAI_GrupoA_.AgenciaEntregarCliente;
using CAI_GrupoA_.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CallCenter
{
    internal class CallCenterModelo
    {
        // -------- Datos de prueba ----------

        private readonly List<ClienteEnt> _clientes = new List<ClienteEnt>
        {
            new ClienteEnt
            {
                Cuit = "20123456780",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { Provincia = ProvinciaEnum.CiudadAutonomaDeBuenosAires, Localidad = "CABA", CalleYAltura = "Av. Corrientes 1234", CodigoPostal = 1001, TipoPunto = TipoPuntoEnum.Domicilio },
                    new DireccionEnt { Provincia = ProvinciaEnum.BuenosAires, Localidad = "Lanús", CalleYAltura = "Calle Falsa 123", CodigoPostal = 1824, TipoPunto = TipoPuntoEnum.Domicilio },
                    new DireccionEnt { Provincia = ProvinciaEnum.BuenosAires, Localidad = "Estación Central", CalleYAltura = "Ruta 3 Km 45", CodigoPostal = 1900, TipoPunto = TipoPuntoEnum.Domicilio }
                }
            },
            new ClienteEnt
            {
                Cuit = "27234567892",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { Provincia = ProvinciaEnum.Cordoba, Localidad = "Córdoba", CalleYAltura = "Av. San Martín 200", CodigoPostal = 5000, TipoPunto = TipoPuntoEnum.Domicilio },
                    new DireccionEnt { Provincia = ProvinciaEnum.Cordoba, Localidad = "Córdoba", CalleYAltura = "Parque Industrial 45", CodigoPostal = 5001, TipoPunto = TipoPuntoEnum.Domicilio }
                }
            },
            new ClienteEnt
            {
                Cuit = "20345678900",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { Provincia = ProvinciaEnum.BuenosAires, Localidad = "La Plata", CalleYAltura = "Av. 7 1500", CodigoPostal = 1900, TipoPunto = TipoPuntoEnum.Domicilio }
                }
            },
            new ClienteEnt
            {
                Cuit = "23321098761",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { Provincia = ProvinciaEnum.SantaFe, Localidad = "Rosario", CalleYAltura = "Calle 9 de Julio 555", CodigoPostal = 2000, TipoPunto = TipoPuntoEnum.Domicilio }
                }
            },
            new ClienteEnt
            {
                Cuit = "30765432108",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { Provincia = ProvinciaEnum.BuenosAires, Localidad = "Mar del Plata", CalleYAltura = "Av. Comercial 123", CodigoPostal = 7600, TipoPunto = TipoPuntoEnum.Domicilio }
                }
            }
        };

        private readonly Dictionary<ProvinciaEnum, List<string>> _agenciasPorProv =
            new Dictionary<ProvinciaEnum, List<string>>
        {
            { ProvinciaEnum.BuenosAires, new List<string>{ "Agencia Quilmes", "Agencia La Plata" } },
            { ProvinciaEnum.Cordoba,     new List<string>{ "Agencia Centro", "Agencia Nueva Córdoba" } },
            { ProvinciaEnum.SantaFe,     new List<string>{ "Agencia Rosario" } }
        };

        private readonly Dictionary<ProvinciaEnum, List<string>> _cdsPorProv =
            new Dictionary<ProvinciaEnum, List<string>>
        {
            { ProvinciaEnum.BuenosAires, new List<string>{ "CD Norte", "CD Sur" } },
            { ProvinciaEnum.Cordoba,     new List<string>{ "CD Córdoba 1" } },
            { ProvinciaEnum.SantaFe,     new List<string>{ "CD Rosario" } }
        };

        private readonly Dictionary<string, string> _codigoPorCD =
            new Dictionary<string, string>
        {
            { "CD Norte", "CD01" },
            { "CD Sur", "CD02" },
            { "CD Córdoba 1", "CD03" },
            { "CD Rosario", "CD04" }
        };

        private readonly Dictionary<string, int> _secuenciaPorCD =
            new Dictionary<string, int>();

        private readonly List<GuiaEnt> _guias = new List<GuiaEnt>();


        // -------- Catálogos ----------
        public string[] GetProvincias()
        {
            return Enum.GetNames(typeof(ProvinciaEnum));
        }

        public string[] GetModalidades()
        {
            return new[] { "Domicilio", "Agencia", "CD" };
        }

        public string[] GetTiposCaja()
        {
            return new[] { "S", "M", "L", "XL" };
        }

        public string[] GetAgencias(string provincia)
        {
            ProvinciaEnum p;
            if (TryParseProvincia(provincia, out p) && _agenciasPorProv.ContainsKey(p))
                return _agenciasPorProv[p].ToArray();
            return new string[0];
        }

        public string[] GetCDs(string provincia)
        {
            ProvinciaEnum p;
            if (TryParseProvincia(provincia, out p) && _cdsPorProv.ContainsKey(p))
                return _cdsPorProv[p].ToArray();
            return new string[0];
        }


        // -------- Cliente ----------
        public static string NormalizarCuit(string s)
        {
            if (s == null) return "";
            var chars = new List<char>();
            foreach (char c in s) if (char.IsDigit(c)) chars.Add(c);
            return new string(chars.ToArray());
        }

        public static bool EsCuitBasico(string cuit)
        {
            return !string.IsNullOrWhiteSpace(cuit) && cuit.Length == 11;
        }

        public ClienteEnt BuscarClientePorCuit(string cuitNormalizado)
        {
            foreach (var c in _clientes)
                if (c.Cuit == cuitNormalizado) return c;
            return null;
        }

        // -------- DTO simple ----------
        public class RegistroEnvioDto
        {
            public string Cuit;
            public string DireccionCliente;
            public string NombreApellido;
            public string Dni;
            public string Telefono;
            public string CodigoPostal;
            public string Modalidad;   // "Domicilio" | "Agencia" | "CD"
            public string Provincia;
            public string Localidad;
            public string CalleYAltura;
            public string Agencia;
            public string CD;
        }

        public class DetalleCaja
        {
            public TamañoCajaEnum Tam;
            public int Qty;
        }


        // -------- Validaciones de negocio ----------
        public List<string> Validar(RegistroEnvioDto dto, List<DetalleCaja> detalle)
        {
            var errors = new List<string>();

            var cuit = NormalizarCuit(dto.Cuit);
            if (!EsCuitBasico(cuit)) errors.Add("CUIT inválido. Debe tener 11 dígitos.");
            if (BuscarClientePorCuit(cuit) == null) errors.Add("Cliente inexistente para el CUIT dado.");
            if (string.IsNullOrWhiteSpace(dto.DireccionCliente)) errors.Add("Debe seleccionar una dirección de cliente.");

            if (string.IsNullOrWhiteSpace(dto.NombreApellido) || dto.NombreApellido.Trim().Length < 2)
                errors.Add("Nombre y Apellido requerido.");

            if (!SoloDigitosEntre(dto.Dni, 7, 8)) errors.Add("DNI inválido. Use 7–8 dígitos.");
            if (!SoloDigitosEntre(dto.Telefono, 6, 15)) errors.Add("Teléfono inválido. Solo números 6–15 dígitos.");
            if (!CPValido(dto.CodigoPostal)) errors.Add("Código Postal inválido.");

            if (string.IsNullOrWhiteSpace(dto.Modalidad)) errors.Add("Seleccione modalidad.");

            ProvinciaEnum _;
            if (!TryParseProvincia(dto.Provincia, out _)) errors.Add("Seleccione provincia válida.");

            if (string.IsNullOrWhiteSpace(dto.Localidad)) errors.Add("Ingrese localidad.");

            if (Equals(dto.Modalidad, "Domicilio"))
            {
                if (string.IsNullOrWhiteSpace(dto.CalleYAltura)) errors.Add("Calle y altura requerido para Domicilio.");
            }
            else if (Equals(dto.Modalidad, "Agencia"))
            {
                if (string.IsNullOrWhiteSpace(dto.Agencia)) errors.Add("Debe seleccionar una Agencia válida.");
            }
            else if (Equals(dto.Modalidad, "CD"))
            {
                if (string.IsNullOrWhiteSpace(dto.CD)) errors.Add("Debe seleccionar un CD válido.");
            }

            if (detalle == null || detalle.Count == 0) errors.Add("Debe agregar al menos un ítem de tipo de caja.");
            else
            {
                for (int i = 0; i < detalle.Count; i++)
                    if (detalle[i].Qty <= 0) { errors.Add("Todas las cantidades deben ser mayores a cero."); break; }
            }

            return errors;
        }

        // -------- Crear guía ----------
        public GuiaEnt CrearGuia(RegistroEnvioDto dto, List<DetalleCaja> detalle)
        {
            ProvinciaEnum prov;
            TryParseProvincia(dto.Provincia, out prov);

            string cdNombre = ObtenerCDOrigenPreferido(dto.Modalidad, dto.CD, prov);
            string nroGuia = GenerarNumeroGuia(cdNombre);

            var origen = new DireccionEnt
            {
                TipoPunto = TipoPuntoEnum.CD,
                CalleYAltura = string.Empty,
                Localidad = cdNombre,
                CodigoPostal = 0,
                Provincia = prov
            };

            var destino = new DireccionEnt
            {
                TipoPunto = ParseModalidad(dto.Modalidad),
                CalleYAltura = (dto.CalleYAltura ?? "").Trim(),
                Localidad = (dto.Localidad ?? "").Trim(),
                CodigoPostal = SafeInt(dto.CodigoPostal),
                Provincia = prov
            };

            var tam = detalle[0].Tam;

            var guia = new GuiaEnt
            {
                NumeroGuia = nroGuia,
                FechaImposicion = DateTime.Now,
                EstadoActual = EstadoActualEnum.EnCD_EnEsperaDeViaje,
                TamañoCaja = tam,
                Origen = origen,
                Destino = destino,
                HojaDeRuta = null
            };

            _guias.Add(guia);
            return guia;
        }

        // -------- Helpers internos ----------
        private string GenerarNumeroGuia(string cdNombre)
        {
            string prefijo = _codigoPorCD.ContainsKey(cdNombre) ? _codigoPorCD[cdNombre] : "CD00";
            int next = 1;
            if (_secuenciaPorCD.ContainsKey(prefijo)) next = _secuenciaPorCD[prefijo] + 1;
            _secuenciaPorCD[prefijo] = next;
            return prefijo + "-" + next.ToString("0000");
        }

        private string ObtenerCDOrigenPreferido(string modalidad, string cdSeleccionado, ProvinciaEnum provincia)
        {
            if (Equals(modalidad, "CD") && !string.IsNullOrWhiteSpace(cdSeleccionado))
                return cdSeleccionado;

            if (provincia == ProvinciaEnum.Cordoba) return "CD Córdoba 1";
            if (provincia == ProvinciaEnum.SantaFe) return "CD Rosario";
            return "CD Norte";
        }

        private static bool TryParseProvincia(string texto, out ProvinciaEnum prov)
        {
            return Enum.TryParse(texto, true, out prov);
        }

        private static TipoPuntoEnum ParseModalidad(string texto)
        {
            TipoPuntoEnum v;
            if (Enum.TryParse(texto, true, out v)) return v;
            return TipoPuntoEnum.Domicilio;
        }

        private static bool SoloDigitosEntre(string s, int min, int max)
        {
            if (string.IsNullOrEmpty(s)) return false;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i])) return false;
                count++;
            }
            return count >= min && count <= max;
        }

        private static bool CPValido(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim().ToUpperInvariant();

            bool soloDigitos = true;
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(s[i])) { soloDigitos = false; break; }

            if (soloDigitos && s.Length == 4) return true;

            bool alnum = true;
            for (int i = 0; i < s.Length; i++)
                if (!char.IsLetterOrDigit(s[i])) { alnum = false; break; }

            return alnum && s.Length == 8;
        }

        private static int SafeInt(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            string only = "";
            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i])) only += s[i];
            int v;
            if (int.TryParse(only, out v)) return v;
            return 0;
        }
    }
}
