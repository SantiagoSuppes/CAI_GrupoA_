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

        // Ideal: a nivel de clase (arriba en el Form)
        private readonly HashSet<string> _dnisHabilitados = new HashSet<string>
{
        "12345678","87654321","11223344","33445566","44556677"
};
        private static readonly string[] _talles = { "S", "M", "L", "XL", "XXL" };
        private static readonly string[] _calles = { "San Martín", "Belgrano", "Rivadavia", "Lavalle", "Mitre", "Sarmiento" };
        private static readonly string[] _ciudades = { "CABA", "Córdoba", "Rosario", "Mendoza", "La Plata", "Tucumán" };

        private static string CuitFake(Random rng)
        {
            return $"{rng.Next(20, 28)}-{rng.Next(10000000, 99999999)}-{rng.Next(0, 9)}";
        }
        private static string DomicilioFake(Random rng)
        {
            return $"{_calles[rng.Next(_calles.Length)]} {rng.Next(100, 9999)}, {_ciudades[rng.Next(_ciudades.Length)]}";
        }

        private void ClearUiForNewSearch()
        {
            // Resultados y checks fuera
            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();

            // Si tenés labels o totales, reinicialos acá
            // lblNombreFletero.Text = "";
            // lblTotalPendiente.Text = "0";
        }

        private int CountChecked(ListView lv)
        {
            return lv.Items.Cast<ListViewItem>().Count(i => i.Checked);
        }
        private void btnBuscarViajesAsignados_Click(object sender, EventArgs e)
        {
            ClearUiForNewSearch();
            // 1) Validaciones del DNI
            if (string.IsNullOrWhiteSpace(txtDniFletero.Text))
            {
                MessageBox.Show("Debe ingresar un DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDniFletero.Focus();
                return;
            }
            if (!txtDniFletero.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.SelectAll();
                txtDniFletero.Focus();
                return;
            }
            if (txtDniFletero.Text.Length < 7 || txtDniFletero.Text.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.Focus();
                return;
            }
            if (!long.TryParse(txtDniFletero.Text, out long dniNum) || dniNum <= 0)
            {
                MessageBox.Show("El DNI no puede ser cero ni negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDniFletero.Focus();
                return;
            }
            if (!_dnisHabilitados.Contains(txtDniFletero.Text))
            {
                MessageBox.Show("El DNI ingresado no existe en el padrón de fleteros.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpio listas si el DNI no existe
                lvDetalle.Items.Clear();
                lvDistribucionesRealizadas.Items.Clear();
                lvRetirosNuevos.Items.Clear();
                lvDistNuevos.Items.Clear();
                return;
            }

            // 2) Generación de datos ficticios determinísticos por DNI
            var rng = new Random(txtDniFletero.Text.GetHashCode()); // mismo DNI => mismos datos
            int nDetalle = rng.Next(2, 5);    // 2..4 filas
            int nDistrib = rng.Next(2, 5);
            int nRetiros = rng.Next(1, 4);
            int nDistNuev = rng.Next(1, 4);

            // Limpio antes de rellenar
            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();

            // 3) lvDetalle
            for (int i = 0; i < nDetalle; i++)
            {
                string cod = $"FR{rng.Next(100, 999)}";
                string talle = _talles[rng.Next(_talles.Length)];
                string estado = "Retirando por fletero";
                string domicilio = DomicilioFake(rng);

                lvDetalle.Items.Add(new ListViewItem(new[] { cod, talle, estado, domicilio }));
            }

            // 4) lvDistribucionesRealizadas
            for (int i = 0; i < nDistrib; i++)
            {
                string id = $"HDRDF{rng.Next(100, 999)}";
                string estado = "A cumplir";
                string domicilio = DomicilioFake(rng);
                string cuit = CuitFake(rng);

                lvDistribucionesRealizadas.Items.Add(new ListViewItem(new[] { id, estado, domicilio, cuit }));
            }

            // 5) lvRetirosNuevos
            for (int i = 0; i < nRetiros; i++)
            {
                string id = $"FR{rng.Next(100, 999)}";
                string estado = "A cumplir";
                string domicilio = DomicilioFake(rng);
                string cuit = CuitFake(rng);

                lvRetirosNuevos.Items.Add(new ListViewItem(new[] { id, estado, domicilio, cuit }));
            }

            // 6) lvDistNuevos
            for (int i = 0; i < nDistNuev; i++)
            {
                string id = $"FD{rng.Next(100, 999)}";
                string estado = "A cumplir";
                string domicilio = DomicilioFake(rng);
                string cuit = CuitFake(rng);

                lvDistNuevos.Items.Add(new ListViewItem(new[] { id, estado, domicilio, cuit }));
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Sólo importa lo que el vehículo va a llevar ahora:
            // Retiros nuevos y Distribuciones nuevas
            int retirosMarcados = CountChecked(lvRetirosNuevos);
            int distMarcadas = CountChecked(lvDistNuevos);

            if (retirosMarcados + distMarcadas == 0)
            {
                MessageBox.Show(
                    "No puede dejar al vehículo sin encomiendas para ir a retirar/distribuir",
                    "Operación inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Si querés mostrar quién es el fletero:
            var dni = string.IsNullOrWhiteSpace(txtDniFletero.Text) ? "(sin DNI)" : txtDniFletero.Text;

            MessageBox.Show(
                $"Se confirmó la rendición con el fletero seleccionado (DNI {dni}) y se cargaron/descargaron las encomiendas correspondientes.",
                "Rendición confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            ClearUiForNewSearch();

            // Aquí enviarías al modelo lo marcado y actualizarías estados...
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
