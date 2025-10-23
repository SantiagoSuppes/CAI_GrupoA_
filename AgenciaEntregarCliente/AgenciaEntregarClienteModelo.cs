using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    internal class AgenciaEntregarClienteModelo
    {
        private readonly Dictionary<long, List<GuiaAgencia>> _data = new();

        public List<GuiaAgencia> BuscarPorDni(long dni)
        {
            if (dni < 10000000L)
            {
                MessageBox.Show("El DNI ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new();
            }

            if (_data.ContainsKey(dni))
                return _data[dni];

            var random = new Random(unchecked((int)dni));
            int cantidad = random.Next(2, 5);
            var guias = new List<GuiaAgencia>();

            for (int i = 0; i < cantidad; i++)
            {
                guias.Add(new GuiaAgencia
                {
                    NumeroGuia = $"#AG{random.Next(0, 999):000}",
                    TamañoCaja = (TamañoCajaAgenciaEnum)random.Next(1, 5),
                    Remitente = RemitenteFake(random),
                    Destinatario = DestinatarioFake(random),
                    FechaImposicion = DateTime.Today.AddDays(-random.Next(1, 15))
                });
            }

            _data[dni] = guias;
            return guias;
        }

        public void ConfirmarEntrega(List<GuiaAgencia> guias)
        {
            if (guias == null || guias.Count == 0) return;

            foreach (var g in guias)
                Console.WriteLine($"Entrega confirmada: {g.NumeroGuia} para {g.Destinatario}");
        }

        private static string RemitenteFake(Random r)
        {
            string[] remitentes = { "Textiles Mitre", "Distribuidora López", "Logística Andes", "Electro Hogar SA" };
            return remitentes[r.Next(remitentes.Length)];
        }

        private static string DestinatarioFake(Random r)
        {
            string[] destinatarios = { "Juan Pérez", "Lucía Díaz", "Carlos Ruiz", "María Gómez", "Sofía Romero" };
            return destinatarios[r.Next(destinatarios.Length)];
        }
    }
}


