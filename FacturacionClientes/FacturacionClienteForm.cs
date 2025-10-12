using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.FacturacionClientes
{
    public partial class FacturacionClienteForm : Form
    {
        Dictionary<string, Cliente> clientesPrueba = new Dictionary<string, Cliente>
        {
            { "30123456789", new Cliente
                {
                    RazonSocial = "Transporte Andino S.A.",
                    CondicionIVA = "Responsable Inscripto",
                    Direcciones = new List<string>
                    {
                        "Av. Corrientes 1234, CABA",
                        "Calle Falsa 123, Lanús",
                        "Ruta 3 Km 45, Estación Central"
                    }
                }
            },
            { "27876543210", new Cliente
                {
                    RazonSocial = "Distribuidora Córdoba SRL",
                    CondicionIVA = "Monotributista",
                    Direcciones = new List<string>
                    {
                        "Av. San Martín 200, Córdoba",
                        "Parque Industrial 45, Córdoba"
                    }
                }
            },
            { "33111222334", new Cliente
                {
                    RazonSocial = "Logística del Litoral S.A.",
                    CondicionIVA = "Exento",
                    Direcciones = new List<string>
                    {
                        "Calle 9 de Julio 555, Rosario"
                    }
                }
            }
        };

        // Clase interna
        class Cliente
        {
            public string RazonSocial { get; set; }
            public string CondicionIVA { get; set; }
            public List<string> Direcciones { get; set; }
        }

        

        public FacturacionClienteForm()
        {
            InitializeComponent();
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {

            string cuitIngresado = txtCUIT.Text.Trim();

            // Limpiar lista y campos previos
            lstGuiasCliente.Items.Clear();
            txtRazonSocial.Clear();
            txtDomicilio.Clear();
            txtIVA.Clear();
            txtMontoTotal.Text = "$ 0,00";

            // Diccionario con datos de prueba
            var clientesPrueba = new Dictionary<string, (string razonSocial, string domicilio, string iva, List<(string guia, string fecha, decimal importe)>)>
    {
            { "30123456789", ("Transportes del Sur S.A.", "Av. Corrientes 1234, CABA", "Responsable Inscripto",
            new List<(string,string,decimal)> { ("001", "01/10/2025", 4500.00m), ("002", "03/10/2025", 3200.00m) }) 
            },

            { "27876543210", ("Envios Córdoba S.R.L.", "Parque Industrial 45, Córdoba", "Monotributista",
            new List<(string,string,decimal)> { ("003", "04/10/2025", 2800.00m), ("004", "06/10/2025", 3500.00m) }) 
            },

            { "33111222334", ("Rosario Logística", "Calle 9 de Julio 555, Rosario", "Exento",
            new List<(string,string,decimal)> { ("005", "05/10/2025", 1500.00m) }) 
            }
    };

            // Validar existencia
            if (!clientesPrueba.ContainsKey(cuitIngresado))
            {
                MessageBox.Show("CUIT no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar datos del cliente
            var cliente = clientesPrueba[cuitIngresado];
            txtRazonSocial.Text = cliente.razonSocial;
            txtDomicilio.Text = cliente.domicilio;
            txtIVA.Text = cliente.iva;

            // Cargar guías en el ListView
            decimal total = 0;
            foreach (var guia in cliente.Item4)
            {
                ListViewItem item = new ListViewItem(guia.guia);
                item.SubItems.Add(guia.fecha);
                item.SubItems.Add("$ " + guia.importe.ToString("N2"));
                lstGuiasCliente.Items.Add(item);
                total += guia.importe;
            }

            // Mostrar total
            txtMontoTotal.Text = "$ " + total.ToString("N2");
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Validar si hay guías
            if (lstGuiasCliente.Items.Count == 0)
            {
                MessageBox.Show("No hay guías cargadas para facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar monto total
            if (txtMontoTotal.Text == "$ 0,00")
            {
                MessageBox.Show("No hay monto a facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Confirmar acción
            DialogResult confirm = MessageBox.Show("¿Desea generar la factura?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Factura generada y enviada al cliente correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstGuiasCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
