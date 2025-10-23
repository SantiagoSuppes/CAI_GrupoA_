using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAI_GrupoA_.CargasYDescargas
{
    public partial class CargasYDescargasForm : Form
    {
        private readonly CargasYDescargasModelo modelo = new();

        public CargasYDescargasForm()
        {
            InitializeComponent();
        }

        // BOTÓN BUSCAR
        private void button1_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text.Trim().ToUpper();

            var (valida, mensajeVal) = modelo.ValidarPatente(patente);
            if (!valida)
            {
                MessageBox.Show(mensajeVal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (encontradas, mensajeBusq) = modelo.BuscarGuiasPorPatente(patente);
            if (!encontradas)
            {
                MessageBox.Show(mensajeBusq, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpresa.Text = "";
                listView1.Items.Clear();
                listView2.Items.Clear();
                return;
            }

            txtEmpresa.Text = modelo.TransportistaActual?.Empresa ?? "";

            listView1.Items.Clear();
            listView2.Items.Clear();

            foreach (var g in modelo.Guias)
            {
                if (g.EsCarga)
                {
                    var it = new ListViewItem(g.NumeroGuia);
                    it.SubItems.Add(g.Destinatario);
                    it.SubItems.Add(g.Remitente);
                    it.SubItems.Add(g.Estado);
                    listView2.Items.Add(it);
                }
                else
                {
                    var it = new ListViewItem(g.Destinatario);
                    it.SubItems.Add(g.Remitente);
                    it.SubItems.Add(g.Estado);
                    it.SubItems.Add(g.NumeroGuia);
                    listView1.Items.Add(it);
                }
            }
        }

        // BOTÓN ACEPTAR (registrar cambios)
        private void button2_Click(object sender, EventArgs e)
        {
            if (modelo.Guias.Count == 0)
            {
                MessageBox.Show("No hay guías cargadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var guias = new List<Guia>();
            foreach (ListViewItem item in listView1.Items)
                guias.Add(new Guia { NumeroGuia = item.SubItems[3].Text, EsCarga = false });
            foreach (ListViewItem item in listView2.Items)
                guias.Add(new Guia { NumeroGuia = item.SubItems[0].Text, EsCarga = true });

            var (exito, mensajeReg) = modelo.RegistrarCargaDescarga(guias);
            if (!exito)
            {
                MessageBox.Show(mensajeReg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem item in listView1.Items)
                item.SubItems[2].Text = "En centro de distribución X";

            foreach (ListViewItem item in listView2.Items)
                item.SubItems[3].Text = "En distribución por transportista";

            MessageBox.Show(mensajeReg, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // FORMATO AUTOMÁTICO DE PATENTE
        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            int sel = txtPatente.SelectionStart;
            string texto = txtPatente.Text.ToUpper().Replace("-", "");
            if (texto.Length > 7) texto = texto.Substring(0, 7);

            StringBuilder sb = new();
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
    }
}
