using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms; 
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{//hola
    internal class AgenciaEntregarClienteModelo
    {
        private long ultimoDNIConsultado = -1;

        // Clave: DNI consultado -> Guías (tipadas con tu GuiaEnt real)
        private readonly Dictionary<long, List<GuiaEnt>> guiasPorDNI = new();

        // Exposición para la UI
        public List<GuiaEnt> Guias { get; private set; } = new();

        // =========================
        // BÚSQUEDA
        // =========================
        public bool BuscarEncomiendas(long dni)
        {
            // Validación: 8 a 10 dígitos
            if (dni < 10000000L || dni > 9999999999L)
            {
                MessageBox.Show("El DNI debe tener entre 8 y 10 dígitos.");
                return false;
            }

            ultimoDNIConsultado = dni;

            if (guiasPorDNI.TryGetValue(dni, out var yaCargadas))
            {
                Guias = yaCargadas;
                return true;
            }

            // Generar datos determinísticos por DNI (2..4 guías)
            var rng = new Random(unchecked((int)dni));
            int cantidad = rng.Next(2, 5);

            var nuevas = new List<GuiaEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                nuevas.Add(GuiaFake(rng));
            }

            guiasPorDNI[dni] = nuevas;
            Guias = nuevas;
            return true;
        }

        // =========================
        // ENTREGAR
        // =========================
        public bool Entregar(List<GuiaEnt> seleccionadas)
        {
            if (ultimoDNIConsultado < 0 || !guiasPorDNI.ContainsKey(ultimoDNIConsultado))
                return false;

            var lista = guiasPorDNI[ultimoDNIConsultado];

            // eliminamos solo las seleccionadas que existan en la lista actual
            foreach (var g in seleccionadas.ToList())
            {
                lista.Remove(g);
            }

            // refrescamos la lista expuesta a la UI
            Guias = lista;
            return true;
        }

        // =========================
        // HELPERS DE FAKES
        // =========================
        private GuiaEnt GuiaFake(Random rng)
        {
            return new GuiaEnt
            {
                NumeroGuia = $"#AG{rng.Next(1, 999):000}",
                FechaImposicion = FechaFake(rng),
                EstadoActual = RandomEnum<EstadoActualEnum>(rng),
                TamañoCaja = RandomEnum<TamañoCajaEnum>(rng),
                Origen = DireccionCD(rng),
                Destino = DireccionAgencia(rng),
                HojaDeRuta = null
            };
        }

        private DireccionEnt DireccionCD(Random rng)
        {
            var (prov, loc) = RandomProvinciaYLocalidad(rng);
            return new DireccionEnt
            {
                TipoPunto = TipoPuntoEnum.CD,
                Provincia = prov,
                Localidad = loc,
                CodigoPostal = rng.Next(1000, 9999),
                CalleYAltura = $"{RandomCalle(rng)} {rng.Next(100, 9999)}"
            };
        }

        private DireccionEnt DireccionAgencia(Random rng)
        {
            var (prov, loc) = RandomProvinciaYLocalidad(rng);
            return new DireccionEnt
            {
                TipoPunto = TipoPuntoEnum.Agencia,
                Provincia = prov,
                Localidad = loc,
                CodigoPostal = rng.Next(1000, 9999),
                CalleYAltura = $"{RandomCalle(rng)} {rng.Next(100, 9999)}"
            };
        }

        private static DateTime FechaFake(Random r)
            => new DateTime(r.Next(2022, 2026), r.Next(1, 13), r.Next(1, 28))
               .AddHours(r.Next(0, 24))
               .AddMinutes(r.Next(0, 60));

        private static string RandomCalle(Random r)
        {
            string[] calles = { "San Martín", "Belgrano", "Rivadavia", "Mitre", "Sarmiento", "Lavalle", "9 de Julio" };
            return calles[r.Next(calles.Length)];
        }

        private static (ProvinciaEnum, string) RandomProvinciaYLocalidad(Random r)
        {
            var provincias = (ProvinciaEnum[])Enum.GetValues(typeof(ProvinciaEnum));
            var prov = provincias[r.Next(provincias.Length)];

            string[] ba = { "Morón", "Ituzaingó", "Quilmes", "Lanús", "Tigre", "San Isidro" };
            string[] sf = { "Rosario", "Santa Fe", "Rafaela", "Venado Tuerto" };
            string[] cb = { "Córdoba", "Villa María", "Río Cuarto" };
            string[] gen = { "Centro", "Norte", "Sur", "Oeste", "Este" };

            string loc = prov switch
            {
                ProvinciaEnum.BuenosAires => ba[r.Next(ba.Length)],
                ProvinciaEnum.SantaFe => sf[r.Next(sf.Length)],
                ProvinciaEnum.Cordoba => cb[r.Next(cb.Length)],
                _ => gen[r.Next(gen.Length)]
            };

            return (prov, loc);
        }

        // prueba 
        private static TEnum RandomEnum<TEnum>(Random r) where TEnum : struct, Enum
        {
            var values = (TEnum[])Enum.GetValues(typeof(TEnum));
            return values[r.Next(values.Length)];
        }
    }
}
