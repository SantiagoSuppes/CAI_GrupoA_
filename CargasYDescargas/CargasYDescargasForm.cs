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
                return;
            }

            txtEmpresa.Text = datosEmpresas[patente];
            MessageBox.Show($"Se encontró la empresa: {datosEmpresas[patente]}", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // EVENTO DEL TEXTBOX DE PATENTE
        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            int sel = txtPatente.SelectionStart;
            string texto = txtPatente.Text.ToUpper().Replace("-", "");

            // Limitar a 7 caracteres
            if (texto.Length > 7) texto = texto.Substring(0, 7);

            // Validar cada posición sin reordenar
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                char c = texto[i];
                if (i < 2 && char.IsLetter(c)) sb.Append(c);
                else if (i >= 2 && i < 5 && char.IsDigit(c)) sb.Append(c);
                else if (i >= 5 && i < 7 && char.IsLetter(c)) sb.Append(c);
            }

            // Insertar guiones y calcular nueva posición del cursor
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

            // Actualizar textbox sin recursión
            txtPatente.TextChanged -= txtPatente_TextChanged;
            txtPatente.Text = sb.ToString();
            txtPatente.SelectionStart = Math.Min(nuevaPos, txtPatente.Text.Length);
            txtPatente.TextChanged += txtPatente_TextChanged;
        }

        // BOTÓN ACEPTAR
        private void button2_Click(object sender, EventArgs e)
        {
            // Confirmación antes de registrar
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea registrar la carga y descarga de las guías del camión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                // Aquí va la lógica para registrar las guías
                MessageBox.Show("Las guías se han registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Si presiona No, no hace nada
        }
    }
}





