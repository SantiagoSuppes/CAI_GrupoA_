using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CAI_GrupoA_.FacturacionClientes
{
    internal class FacturacionClienteModelo
    {
        
        private readonly Dictionary<string, ClienteEnt> _clientesPrueba = new();
        public ClienteEnt ClienteActual { get; private set; }
        public List<GuiaEnt> GuiasCliente { get; private set; } = new();

        public FacturacionClienteModelo() 
        {
            CargarClientesDePrueba();
        }

        private void CargarClientesDePrueba()
        {
            _clientesPrueba["30123456789"] = new ClienteEnt
            {
                Cuit = "30123456789",
                RazonSocial = "Transportes del Sur S.A.",
                CondicionIVA = CondicionIVAEnum.ResponsableInscripto,
                DomicilioFiscal = "Av. Corrientes 1234, CABA",
                Direcciones = new List<DireccionEnt>
                {
                   new DireccionEnt { CalleYAltura = "Av. Corrientes 1234", Localidad = "CABA", Provincia = ProvinciaEnum.BuenosAires }
                } 
            };

            _clientesPrueba["27876543210"] = new ClienteEnt
            {
                Cuit = "27876543210",
                RazonSocial = "Envios Córdoba S.R.L.",
                CondicionIVA = CondicionIVAEnum.Monotributo,
                DomicilioFiscal = "Parque Industrial 45, Córdoba",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { CalleYAltura = "Parque Industrial 45", Localidad = "Córdoba", Provincia = ProvinciaEnum.Cordoba }
                }
            };

            _clientesPrueba["33111222334"] = new ClienteEnt
            {
                Cuit = "33111222334",
                RazonSocial = "Rosario Logística",
                CondicionIVA = CondicionIVAEnum.Exento,
                DomicilioFiscal = "Calle 9 de Julio 555, Rosario",
                Direcciones = new List<DireccionEnt>
                {
                    new DireccionEnt { CalleYAltura = "9 de Julio 555", Localidad = "Rosario", Provincia = ProvinciaEnum.SantaFe }
                }
            };
        }
        public bool ValidarCuit(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
            {
                MessageBox.Show("Debe ingresar un CUIT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_clientesPrueba.ContainsKey(cuit))
            {
                MessageBox.Show("CUIT no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public ClienteEnt BuscarCliente(string cuit)
        {
            ClienteActual = _clientesPrueba[cuit];
            GuiasCliente = GenerarGuiasFake(cuit);
            return ClienteActual;
        }

        private List<GuiaEnt> GenerarGuiasFake(string cuit)
        {
            var rng = new Random(cuit.GetHashCode());
            int cantidad = rng.Next(1, 4);
            var guias = new List<GuiaEnt>();

            for (int i = 0; i < cantidad; i++)
            {
                guias.Add(new GuiaEnt
                {
                    NroGuia = $"G-{rng.Next(100, 999)}",
                    Fecha = DateTime.Now.AddDays(-rng.Next(1, 10)),
                    EstadoActual = EstadoActualEnum.Entregada,
                    TamañoCaja = (TamañoCajaEnum)rng.Next(0, 4),
                    Origen = ClienteActual.Direcciones.First(),
                    Destino = ClienteActual.Direcciones.LastOrDefault() ?? ClienteActual.Direcciones.First()
                });
            }

            return guias;
        }

        public decimal CalcularTotal()
        {
            return GuiasCliente.Count * 3500m; // valor ficticio
        }

       
        
    }

}

