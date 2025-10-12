using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.CargasYDescargas
{
    public partial class CargasYDescargasForm : Form
    {
        // Diccionarios para guardar los estados originales
        private Dictionary<string, string> estadosOriginalesDescarga = new Dictionary<string, string>();
        private Dictionary<string, string> estadosOriginalesCarga = new Dictionary<string, string>();

        public CargasYDescargasForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Simulación de datos de guías por patente
        private Dictionary<string, List<(string NGuia, string Destinatario, string Remitente, string Estado, bool EsCarga)>> guiasPorPatente
            = new Dictionary<string, List<(string, string, string, string, bool)>>()
        {
            {
                "AB-123-CD", new List<(string, string, string, string, bool)>()
                {
                    ("G001", "Cliente A", "Transporte López", "Pendiente", false),
                    ("G002", "Cliente B", "Transporte López", "Pendiente", true),
                    ("G003", "Cliente C", "Transporte López", "Pendiente", true),
                    ("G004", "Cliente D", "Transporte López", "Pendiente", false)
                }
            },
            {
                "AC-456-BD", new List<(string, string, string, string, bool)>()
                {
                    ("G010", "Cliente E", "Logística Pérez", "Pendiente", false),
                    ("G011", "Cliente F", "Logística Pérez", "Pendiente", true),
                    ("G012", "Cliente G", "Logística Pérez", "Pendiente", false)
                }
            },
            {
                "AA-111-AA", new List<(string, string, string, string, bool)>()
                {
                    ("G020", "Cliente H", "Camiones del Sur", "Pendiente", true),
                    ("G021", "Cliente I", "Camiones del Sur", "Pendiente", false),
                    ("G022", "Cliente J", "Camiones del Sur", "Pendiente", true),
                    ("G023", "Cliente K", "Camiones del Sur", "Pendiente", false)
                }
            }
        };

        // BOTÓN BUSCAR
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatente.Text))
            {
                MessageBox.Show("Debe ingresar una patente antes de buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patente = txtPatente.Text.Trim().ToUpper();

            Dictionary<string, string> datosEmpresas = new Dictionary<string, string>()
            {
                { "AB-123-CD", "Transporte López S.A." },
                { "AC-456-BD", "Logística Pérez SRL" },
                { "AA-111-AA", "Camiones del Sur" }
            };

            if (!datosEmpresas.ContainsKey(patente))
            {
                MessageBox.Show("No se encontró información para la patente ingresada.", "Patente no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpresa.Text = "";
                listView1.Items.Clear();
                listView2.Items.Clear();
                return;
            }

            txtEmpresa.Text = datosEmpresas[patente];
            MessageBox.Show($"Se encontró la empresa: {datosEmpresas[patente]}", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar listViews y diccionarios de estados originales
            listView1.Items.Clear();
            listView2.Items.Clear();
            estadosOriginalesDescarga.Clear();
            estadosOriginalesCarga.Clear();

            // Cargar guías con estado según tipo
            if (guiasPorPatente.ContainsKey(patente))
            {
                foreach (var guia in guiasPorPatente[patente])
                {
                    string estadoInicial = guia.EsCarga
                        ? "En espera de viaje en CD Central"
                        : "En distribución por transportista";

                    if (guia.EsCarga)
                    {
                        var item = new ListViewItem(guia.NGuia);
                        item.SubItems.Add(guia.Destinatario);
                        item.SubItems.Add(guia.Remitente);
                        item.SubItems.Add(estadoInicial);
                        listView2.Items.Add(item);
                        estadosOriginalesCarga[guia.NGuia] = estadoInicial; // Guardar estado original
                    }
                    else
                    {
                        var item = new ListViewItem(guia.Destinatario);
                        item.SubItems.Add(guia.Remitente);
                        item.SubItems.Add(estadoInicial);
                        item.SubItems.Add(guia.NGuia);
                        listView1.Items.Add(item);
                        estadosOriginalesDescarga[guia.NGuia] = estadoInicial; // Guardar estado original
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // EVENTO DEL TEXTBOX DE PATENTE
        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            int sel = txtPatente.SelectionStart;
            string texto = txtPatente.Text.ToUpper().Replace("-", "");

            if (texto.Length > 7) texto = texto.Substring(0, 7);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (i < 2 && char.IsLetter(c)) sb.Append(c);
                else if (i >= 2 && i < 5 && char.IsDigit(c)) sb.Append(c);
                else if (i >= 5 && i < 7 && char.IsLetter(c)) sb.Append(c);
            }

            int nuevaPos = sel;
            if (sb.Length > 2)
            {
                sb.Insert(2, "-");
                if (sel > 2) nuevaPos++;
            }
            if (sb.Length > 6)
            {
                sb.Insert(6, "-");
                if (sel > 6) nuevaPos++;
            }

            txtPatente.TextChanged -= txtPatente_TextChanged;
            txtPatente.Text = sb.ToString();
            txtPatente.SelectionStart = Math.Min(nuevaPos, txtPatente.Text.Length);
            txtPatente.TextChanged += txtPatente_TextChanged;
        }

        // BOTÓN ACEPTAR
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea registrar la carga y descarga de las guías del camión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                foreach (ListViewItem item in listView1.Items) // DESCARGA
                {
                    item.SubItems[2].Text = "En centro de distribución X";
                }

                foreach (ListViewItem item in listView2.Items) // CARGA
                {
                    item.SubItems[3].Text = "En distribución por transportista";
                }

                MessageBox.Show("Los estados de las guías se actualizaron correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // BOTÓN DESHACER
        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items) // DESCARGA
            {
                string nGuia = item.SubItems[3].Text;
                if (estadosOriginalesDescarga.ContainsKey(nGuia))
                    item.SubItems[2].Text = estadosOriginalesDescarga[nGuia];
            }

            foreach (ListViewItem item in listView2.Items) // CARGA
            {
                string nGuia = item.SubItems[0].Text;
                if (estadosOriginalesCarga.ContainsKey(nGuia))
                    item.SubItems[3].Text = estadosOriginalesCarga[nGuia];
            }

            MessageBox.Show("Se deshicieron los cambios y se restauraron los estados originales.", "Deshacer completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}







