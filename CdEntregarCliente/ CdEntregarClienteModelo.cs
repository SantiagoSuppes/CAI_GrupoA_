using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms; // por MessageBox
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.CdEntregarCliente
{
    internal class CdEntregarClienteModelo
    {
        private long ultimoDNIConsultado = -1;

        // DNI -> guías (usando tu entidad real)
        private readonly Dictionary<long, List<GuiaEnt>> guiasPorDNI = new();

        // Para que la UI pueda bindear
        public List<GuiaEnt> Guias { get; private set; } = new();

        // =========================
        // BÚSQUEDA
        // =========================
        public bool BuscarEncomiendas(long dni)
        {
            // 8 a 10 dígitos
            if (dni < 10_000_000L || dni > 9_999_999_999L)
            {
                MessageBox.Show("El DNI debe tener entre 8 y 10 dígitos.");
                return false;
            }

            ultimoDNIConsultado = dni;

            if (guiasPorDNI.TryGetValue(dni, out var cargadas))
            {
                Guias = cargadas;
                return true;
            }

            // Genera datos determinísticos por DNI
            var rng = new Random(unchecked((int)dni));
            int cantidad = rng.Next(2, 5); // 2..4

            var nuevas = new List<GuiaEnt>();
            for (int i = 0; i < cantidad; i++)
                nuevas.Add(GuiaFake(rng));

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

            // Remueve sólo las seleccionadas que estén presentes
            foreach (var g in seleccionadas.ToList())
                lista.Remove(g);

            Guias = lista;
            return true;
        }

        // =========================
        // HELPERS (fakes coherentes)
        // =========================
        private GuiaEnt GuiaFake(Random rng)
        {
            // En "CD entregar al cliente" suele ser retiro en CD:
            // Origen: CD (depósito), Destino: CD (mostrador/recepción)
            return new GuiaEnt
            {
                NumeroGuia = $"#AG{rng.Next(1, 999):000}",
                FechaImposicion = FechaFake(rng),
                EstadoActual = RandomEnum<EstadoActualEnum>(rng),
                TamañoCaja = RandomEnum<TamañoCajaEnum>(rng),
                Origen = DireccionCD(rng, "CD Origen"),
                Destino = DireccionCD(rng, "CD Entrega"),
                HojaDeRuta = null
            };
        }

        private DireccionEnt DireccionCD(Random rng, string aliasLocalidad)
        {
            var (prov, loc) = RandomProvinciaYLocalidad(rng);
            // Mostramos el alias al usuario manteniendo provincia/CP válidos
            return new DireccionEnt
            {
                TipoPunto = TipoPuntoEnum.CD,
                Provincia = prov,
                Localidad = $"{loc} - {aliasLocalidad}",
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
        //hola
        private static TEnum RandomEnum<TEnum>(Random r) where TEnum : struct, Enum
        {
            var values = (TEnum[])Enum.GetValues(typeof(TEnum));
            return values[r.Next(values.Length)];
        }
    }
}
