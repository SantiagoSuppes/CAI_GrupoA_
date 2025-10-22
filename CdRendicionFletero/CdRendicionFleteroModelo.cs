using System;
using System.Collections.Generic;
using System.Linq;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.CdRendicionFletero
{
    internal class CdRendicionFleteroModelo
    {
        private readonly Random _rng = new Random(12345);

        private readonly List<FleteroEnt> _fleteros = new();
        private readonly List<HojaDeRutaEnt> _hojas = new();
        private readonly List<GuiaEnt> _guias = new();
        private readonly List<GuiaHojaDeRutaEnt> _links = new();

        public IReadOnlyList<FleteroEnt> Fleteros => _fleteros;
        public IReadOnlyList<HojaDeRutaEnt> HojasDeRuta => _hojas;
        public IReadOnlyList<GuiaEnt> Guias => _guias;
        public IReadOnlyList<GuiaHojaDeRutaEnt> VinculosGuiaHoja => _links;

        public CdRendicionFleteroModelo()
        {
            PrecargarDatos();
        }

        // ---------------------------
        // Validación DNI (int)
        // ---------------------------
        public bool ValidarDni(string dniStr)
        {
            if (string.IsNullOrWhiteSpace(dniStr)) return false;
            if (!int.TryParse(dniStr, out var dni)) return false;
            // rango típico AR: 7–9 dígitos
            return dni >= 1_000_000 && dni <= 999_999_999;
        }

        // ---------------------------
        // Precarga
        // ---------------------------
        private void PrecargarDatos()
        {
            // 1) Fleteros: DNI int
            _fleteros.AddRange(new[]
            {
                new FleteroEnt { Nombre = "Juan Gómez",  DNI = 40_999_888 },
                new FleteroEnt { Nombre = "María López", DNI = 37_222_444 },
                new FleteroEnt { Nombre = "Carlos Díaz", DNI = 33_888_777 },
            });

            // 2) Hojas de ruta (enums random para evitar miembros inexistentes)
            _hojas.AddRange(new[]
            {
                new HojaDeRutaEnt
                {
                    TipoHojaDeRuta = RandomEnum<TipoHojaDeRutaEnum>(),
                    Estado = RandomEnum<EstadoActualHojaDeRutaEnum>(),
                    Origen = DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123"),
                    Destino = DireccionAgencia("Retiro", 1104, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "Agencia Retiro 500"),
                    Fletero = _fleteros[0],
                    Transportista = new TransportistaEnt()
                },
                new HojaDeRutaEnt
                {
                    TipoHojaDeRuta = RandomEnum<TipoHojaDeRutaEnum>(),
                    Estado = RandomEnum<EstadoActualHojaDeRutaEnum>(),
                    Origen = DireccionCD("Morón", 1708, ProvinciaEnum.BuenosAires, "CD Oeste 2500"),
                    Destino = DireccionAgencia("Rosario", 2000, ProvinciaEnum.SantaFe, "Agencia Rosario 220"),
                    Fletero = _fleteros[1],
                    Transportista = new TransportistaEnt()
                },
                new HojaDeRutaEnt
                {
                    TipoHojaDeRuta = RandomEnum<TipoHojaDeRutaEnum>(),
                    Estado = RandomEnum<EstadoActualHojaDeRutaEnum>(),
                    Origen = DireccionCD("Córdoba", 5000, ProvinciaEnum.Cordoba, "CD Córdoba 800"),
                    Destino = DireccionAgencia("Nueva Córdoba", 5000, ProvinciaEnum.Cordoba, "Agencia NC 1400"),
                    Fletero = _fleteros[2],
                    Transportista = new TransportistaEnt()
                }
            });

            // 3) Guías
            _guias.AddRange(new[]
            {
                Guia("AG-0001", TamañoCajaEnum.S,  DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123"),
                                       DireccionDomicilio("Quilmes", 1878, ProvinciaEnum.BuenosAires, "Mitre 456")),
                Guia("AG-0002", TamañoCajaEnum.M,  DireccionCD("Morón", 1708, ProvinciaEnum.BuenosAires, "CD Oeste 2500"),
                                       DireccionAgencia("Ituzaingó", 1714, ProvinciaEnum.BuenosAires, "Agencia Ituzaingó 300")),
                Guia("AG-0003", TamañoCajaEnum.L,  DireccionCD("Córdoba", 5000, ProvinciaEnum.Cordoba, "CD Córdoba 800"),
                                       DireccionDomicilio("Rosario", 2000, ProvinciaEnum.SantaFe, "San Martín 1234")),
                Guia("AG-0004", TamañoCajaEnum.XL, DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123"),
                                       DireccionAgencia("Retiro", 1104, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "Agencia Retiro 500")),
                Guia("AG-0005", TamañoCajaEnum.S,  DireccionCD("Morón", 1708, ProvinciaEnum.BuenosAires, "CD Oeste 2500"),
                                       DireccionDomicilio("Lanús", 1824, ProvinciaEnum.BuenosAires, "Rivadavia 890")),
                Guia("AG-0006", TamañoCajaEnum.M,  DireccionCD("Córdoba", 5000, ProvinciaEnum.Cordoba, "CD Córdoba 800"),
                                       DireccionAgencia("Nueva Córdoba", 5000, ProvinciaEnum.Cordoba, "Agencia NC 1400")),
                Guia("AG-0007", TamañoCajaEnum.L,  DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123"),
                                       DireccionDomicilio("Tigre", 1648, ProvinciaEnum.BuenosAires, "Lavalle 765")),
                Guia("AG-0008", TamañoCajaEnum.XL, DireccionCD("Rosario", 2000, ProvinciaEnum.SantaFe, "CD Litoral 600"),
                                       DireccionAgencia("Rosario", 2000, ProvinciaEnum.SantaFe, "Agencia Rosario 220")),
            });

            // 4) Asignación round-robin
            for (int i = 0; i < _guias.Count; i++)
            {
                var hoja = _hojas[i % _hojas.Count];
                _guias[i].HojaDeRuta = hoja;
                _links.Add(new GuiaHojaDeRutaEnt { Guia = _guias[i], HojaDeRuta = hoja });
            }
        }

        // ---------------------------
        // Generadores 
        // ---------------------------
        public List<GuiaEnt> GenerarGuiasRandom(int dniDestinatario, int cantidad)
        {
            var list = new List<GuiaEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                var origen = DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123");
                var destino = _rng.NextDouble() < 0.5
                    ? DireccionDomicilio("Quilmes", 1878, ProvinciaEnum.BuenosAires, $"{RandomCalle()} {_rng.Next(100, 9999)}")
                    : DireccionAgencia("Rosario", 2000, ProvinciaEnum.SantaFe, $"{RandomCalle()} {_rng.Next(100, 9999)}");

                list.Add(new GuiaEnt
                {
                    NumeroGuia = $"AG{_rng.Next(1000, 9999)}-{_rng.Next(1000, 9999)}",
                    FechaImposicion = DateTime.Now.AddMinutes(-_rng.Next(0, 10_000)),
                    EstadoActual = RandomEnum<EstadoActualEnum>(),
                    TamañoCaja = RandomEnum<TamañoCajaEnum>(),
                    Origen = origen,
                    Destino = destino,
                    HojaDeRuta = null
                });
            }
            return list;
        }

        public List<HojaDeRutaEnt> GenerarHojasDeRutaRandom(int cantidad)
        {
            var list = new List<HojaDeRutaEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                list.Add(new HojaDeRutaEnt
                {
                    TipoHojaDeRuta = RandomEnum<TipoHojaDeRutaEnum>(),
                    Estado = RandomEnum<EstadoActualHojaDeRutaEnum>(),
                    Origen = DireccionCD("CABA", 1000, ProvinciaEnum.CiudadAutonomaDeBuenosAires, "CD Central 123"),
                    Destino = DireccionAgencia("Ituzaingó", 1714, ProvinciaEnum.BuenosAires, "Agencia Ituzaingó 300"),
                    Fletero = RandomFletero(),
                    Transportista = new TransportistaEnt()
                });
            }
            return list;
        }

        public List<FleteroEnt> GenerarFleterosRandom(int cantidad)
        {
            var list = new List<FleteroEnt>();
            for (int i = 0; i < cantidad; i++)
                list.Add(RandomFletero());
            return list;
        }

        public List<GuiaHojaDeRutaEnt> AsignarGuiasAHojas(IList<GuiaEnt> guias, IList<HojaDeRutaEnt> hojas)
        {
            var links = new List<GuiaHojaDeRutaEnt>();
            if (guias == null || hojas == null || hojas.Count == 0) return links;

            for (int i = 0; i < guias.Count; i++)
            {
                var hoja = hojas[i % hojas.Count];
                guias[i].HojaDeRuta = hoja;
                links.Add(new GuiaHojaDeRutaEnt { Guia = guias[i], HojaDeRuta = hoja });
            }
            return links;
        }

        // Filtros para UI
        public IEnumerable<GuiaEnt> GuiasPorFletero(int dniFletero)
            => _guias.Where(g => g.HojaDeRuta?.Fletero?.DNI == dniFletero);

        public IEnumerable<GuiaEnt> GuiasPorFletero(string dniStr)
            => int.TryParse(dniStr, out var dni) ? GuiasPorFletero(dni) : Enumerable.Empty<GuiaEnt>();

        public IEnumerable<GuiaEnt> GuiasPorHoja(HojaDeRutaEnt hoja)
            => _guias.Where(g => ReferenceEquals(g.HojaDeRuta, hoja));

        private GuiaEnt Guia(string numero, TamañoCajaEnum tamaño, DireccionEnt origen, DireccionEnt destino)
            => new GuiaEnt
            {
                NumeroGuia = numero,
                FechaImposicion = DateTime.Now.AddMinutes(-_rng.Next(0, 5000)),
                EstadoActual = RandomEnum<EstadoActualEnum>(),
                TamañoCaja = tamaño,
                Origen = origen,
                Destino = destino,
                HojaDeRuta = null
            };

        private DireccionEnt DireccionCD(string localidad, int cp, ProvinciaEnum prov, string calle)
            => new DireccionEnt { TipoPunto = TipoPuntoEnum.CD, Localidad = localidad, CodigoPostal = cp, Provincia = prov, CalleYAltura = calle };

        private DireccionEnt DireccionAgencia(string localidad, int cp, ProvinciaEnum prov, string calle)
            => new DireccionEnt { TipoPunto = TipoPuntoEnum.Agencia, Localidad = localidad, CodigoPostal = cp, Provincia = prov, CalleYAltura = calle };

        private DireccionEnt DireccionDomicilio(string localidad, int cp, ProvinciaEnum prov, string calle)
            => new DireccionEnt { TipoPunto = TipoPuntoEnum.Domicilio, Localidad = localidad, CodigoPostal = cp, Provincia = prov, CalleYAltura = calle };

        private string RandomCalle()
        {
            string[] calles = { "San Martín", "Belgrano", "Rivadavia", "Mitre", "Sarmiento", "Lavalle", "9 de Julio" };
            return calles[_rng.Next(calles.Length)];
        }

        private TEnum RandomEnum<TEnum>() where TEnum : struct, Enum
        {
            var values = (TEnum[])Enum.GetValues(typeof(TEnum));
            return values[_rng.Next(values.Length)];
        }

        private FleteroEnt RandomFletero()
        {
            string[] nombres = { "Juan Gómez", "María López", "Carlos Díaz", "Ana Fernández", "Luis Pérez" };
            var dni = _rng.Next(10_000_000, 99_999_999); // int
            return new FleteroEnt { Nombre = nombres[_rng.Next(nombres.Length)], DNI = dni };
        }
    }
}
