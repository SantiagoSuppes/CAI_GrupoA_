using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.CdRendicionFletero
{
    public partial class CdRendicionFleteroForms : Form
    {
        public CdRendicionFleteroForms()
        {
            InitializeComponent();
        }

        private void txtDniFletero_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarViajesAsignados_Click(object sender, EventArgs e)
        {
            // --- 1. Validar campo vacío ---
            if (string.IsNullOrWhiteSpace(txtDniFletero.Text))
            {
                MessageBox.Show("Debe ingresar un DNI antes de buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDniFletero.Focus();
                return;
            }
            
            // --- 2. Validar que sean solo números ---
            if (!txtDniFletero.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.Clear();
                txtDniFletero.Focus();
                return;
            }

            // --- 3. Validar longitud mínima/máxima ---
            if (txtDniFletero.Text.Length < 7 || txtDniFletero.Text.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.Focus();
                return;
            }

            // --- 4. Validar que no sea negativo o cero ---
            if (!long.TryParse(txtDniFletero.Text, out long dni) || dni <= 0)
            {
                MessageBox.Show("El DNI no puede ser cero ni negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.Focus();
                return;
            }


        }
    }
}
