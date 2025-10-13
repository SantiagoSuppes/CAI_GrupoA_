using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.CdRendicionFletero
{
    public partial class CdRendicionFleteroForms : Form
    {
        public CdRendicionFleteroForms()
        {
            InitializeComponent();
        }

        private void txtDniFletero_TextChanged(object sender, EventArgs e) { }

        private readonly HashSet<string> _dnisHabilitados = new()
        {
            "12345678","87654321","11223344","33445566","44556677"
        };

        private static readonly string[] _talles = { "S", "M", "L", "XL", "XXL" };
        private static readonly string[] _calles = { "San Martín", "Belgrano", "Rivadavia", "Lavalle", "Mitre", "Sarmiento" };
        private static readonly string[] _ciudades = { "CABA", "Córdoba", "Rosario", "Mendoza", "La Plata", "Tucumán" };

        private static string CuitFake(Random rng)
            => $"{rng.Next(20, 28)}-{rng.Next(10000000, 99999999)}-{rng.Next(0, 9)}";

        private static string DomicilioFake(Random rng)
            => $"{_calles[rng.Next(_calles.Length)]} {rng.Next(100, 9999)}, {_ciudades[rng.Next(_ciudades.Length)]}";

        private void ClearUiForNewSearch()
        {
            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();
        }

        private void btnBuscarViajesAsignados_Click(object sender, EventArgs e)
        {
            ClearUiForNewSearch();

            // Validaciones del DNI
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

            if (!_dnisHabilitados.Contains(txtDniFletero.Text))
            {
                MessageBox.Show("El DNI ingresado no existe en el padrón de fleteros.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearUiForNewSearch();
                return;
            }

            // Generación de datos ficticios
            var rng = new Random(txtDniFletero.Text.GetHashCode());
            int nDetalle = rng.Next(2, 5);
            int nDistrib = rng.Next(2, 5);
            int nRetiros = rng.Next(1, 4);
            int nDistNuev = rng.Next(1, 4);

            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();

            // Detalle de viajes anteriores
            for (int i = 0; i < nDetalle; i++)
            {
                string cod = $"FR{rng.Next(100, 999)}";
                string talle = _talles[rng.Next(_talles.Length)];
                string estado = "Retirando por fletero";
                string domicilio = DomicilioFake(rng);

                lvDetalle.Items.Add(new ListViewItem(new[] { cod, talle, estado, domicilio }));
            }

            // Distribuciones realizadas
            for (int i = 0; i < nDistrib; i++)
            {
                string id = $"HDRDF{rng.Next(100, 999)}";
                string estado = "A cumplir";
                string domicilio = DomicilioFake(rng);
                string cuit = CuitFake(rng);

                lvDistribucionesRealizadas.Items.Add(new ListViewItem(new[] { id, estado, domicilio, cuit }));
            }

            // Retiros nuevos (sin validaciones de marcado)
            for (int i = 0; i < nRetiros; i++)
            {
                string id = $"FR{rng.Next(100, 999)}";
                string estado = "A cumplir";
                string domicilio = DomicilioFake(rng);
                string cuit = CuitFake(rng);

                lvRetirosNuevos.Items.Add(new ListViewItem(new[] { id, estado, domicilio, cuit }));
            }

            // Distribuciones nuevas (sin validaciones de marcado)
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
            // Se elimina la validación de selección de retiros/distribuciones
            var dni = string.IsNullOrWhiteSpace(txtDniFletero.Text) ? "(sin DNI)" : txtDniFletero.Text;

            MessageBox.Show(
                $"Rendición registrada correctamente para el fletero con DNI {dni}.",
                "Rendición confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            ClearUiForNewSearch();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
    }
}
