using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoA.cdEntregarCliente
{
    public partial class cdEntregarClienteForms : Form
    {
        public cdEntregarClienteForms()
        {
            InitializeComponent();
        }

        private void btnBuscarEncomiendaDestinatario_Click(object sender, EventArgs e)
        {
            // 1. Campo vacío
            if (string.IsNullOrWhiteSpace(txtDniDestinatario.Text))
            {
                MessageBox.Show("Debe ingresar un DNI antes de buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDniDestinatario.Focus();
                return;
            }

            // 2. Solo números
            if (!txtDniDestinatario.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Clear();
                txtDniDestinatario.Focus();
                return;
            }

            // 3. Longitud válida
            if (txtDniDestinatario.Text.Length < 7 || txtDniDestinatario.Text.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Focus();
                return;
            }

            // 4. No negativos ni cero
            if (!long.TryParse(txtDniDestinatario.Text, out long dni) || dni <= 0)
            {
                MessageBox.Show("El DNI no puede ser negativo o cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniDestinatario.Focus();
                return;
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya elementos en el ListView
            if (listViewEncomiendas.Items.Count == 0)
            {
                MessageBox.Show("No hay encomiendas cargadas para confirmar entrega.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que al menos uno esté seleccionado (checked)
            var seleccionadas = listViewEncomiendas.Items.Cast<ListViewItem>().Where(i => i.Checked).ToList();

            if (seleccionadas.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una encomienda para confirmar la entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
