using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using CAI_GrupoA_.AgenciaEntregarCliente;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    internal class AgenciaEntregarClienteModelo
    {
        private long ultimoDNIConsultado = -1;

        // DNI -> Guías
        private readonly Dictionary<long, List<Guia>> guiasPorDNI = new();

        // Para la UI
        public List<Guia> Guias { get; private set; } = new();

        // =========================
        // BÚSQUEDA
        // =========================
        public bool BuscarEncomiendas(long dni)
        {
            // 8 a 10 dígitos
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

            var nuevas = new List<Guia>();
            for (int i = 0; i < cantidad; i++)
            {
                var g = GuiaFake(rng);
                var error = ValidarGuia(g);
                if (string.IsNullOrEmpty(error))
                    nuevas.Add(g);
            }

            guiasPorDNI[dni] = nuevas;
            Guias = nuevas;
            return true;
        }

        // =========================
        // ENTREGAR
        // =========================
        public bool Entregar(List<Guia> seleccionadas)
        {
            if (ultimoDNIConsultado < 0 || !guiasPorDNI.ContainsKey(ultimoDNIConsultado))
                return false;

            if (seleccionadas == null || seleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una guía.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var lista = guiasPorDNI[ultimoDNIConsultado];

            // Validar seleccionadas
            foreach (var g in seleccionadas.ToList())
            {
                var err = ValidarGuia(g);
                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show($"La guía {g?.NumeroGuia ?? "(sin número)"} es inválida:\n{err}",
                        "Guía inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    seleccionadas.Remove(g);
                }
            }

            // Remover sólo las seleccionadas existentes
            foreach (var g in seleccionadas)
                lista.Remove(g);

            Guias = lista; // refrescar UI
            return true;
        }

        // =========================
        // VALIDACIÓN
        // =========================
        private string ValidarGuia(Guia g)
        {
            if (g == null) return "La guía es nula.";

            // NumeroGuia: #AGddd
            if (string.IsNullOrWhiteSpace(g.NumeroGuia) ||
                !Regex.IsMatch(g.NumeroGuia, @"^#AG\d{3}$"))
                return "Número de guía inválido (formato esperado: #AG000 a #AG999).";

            if (g.FechaImposicion > DateTime.Now)
                return "La fecha de imposición no puede ser futura.";

            if (!Enum.IsDefined(typeof(TamañoCajaEnum), g.TamañoCaja))
                return "Tamaño de caja inválido.";

            if (string.IsNullOrWhiteSpace(g.Remitente) || g.Remitente.Trim().Length < 2)
                return "El remitente es obligatorio.";

            if (string.IsNullOrWhiteSpace(g.Destinatario) || g.Destinatario.Trim().Length < 2)
                return "El destinatario es obligatorio.";

            return string.Empty;
        }

        // =========================
        // FAKES
        // =========================
        private Guia GuiaFake(Random rng)
        {
            return new Guia
            {
                NumeroGuia = $"#AG{rng.Next(0, 1000):000}",
                FechaImposicion = FechaFake(rng),
                TamañoCaja = (Entidades.TamañoCajaEnum)RandomEnum<TamañoCajaEnum>(rng),
                Remitente = RandomRemitente(rng),
                Destinatario = RandomDestinatario(rng)
            };
        }

        private static DateTime FechaFake(Random r)
            => new DateTime(r.Next(2022, 2026), r.Next(1, 13), r.Next(1, 28))
               .AddHours(r.Next(0, 24))
               .AddMinutes(r.Next(0, 60));

        private static string RandomRemitente(Random r)
        {
            string[] remitentes =
            {
                "Distribuidora López", "Agro Sur SRL", "Textiles Mitre",
                "Electro Hogar SA", "Logística Andes", "Frigorífico Río"
            };
            return remitentes[r.Next(remitentes.Length)];
        }

        private static string RandomDestinatario(Random r)
        {
            string[] destinatarios =
            {
                "Juan Pérez", "María Gómez", "Lucía Díaz", "Carlos Ruiz",
                "Sofía Romero", "Hernán Torres", "Paula Rivas"
            };
            return destinatarios[r.Next(destinatarios.Length)];
        }

        private static TEnum RandomEnum<TEnum>(Random r) where TEnum : struct, Enum
        {
            var values = (TEnum[])Enum.GetValues(typeof(TEnum));
            return values[r.Next(values.Length)];
        }
    }
}
