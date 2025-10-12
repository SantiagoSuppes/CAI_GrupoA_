using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAI_GrupoA_.CdEntregarCliente
{
    public partial class CdEntregarClienteForms : Form
    {
        public CdEntregarClienteForms()
        {
            InitializeComponent();
        }




        // Padrón de destinatarios válidos (simulado)
        private readonly HashSet<string> _destinatariosValidos = new HashSet<string>
{
    "44997021","30111222","23333444","40999888","36555111"
};

        // Datos fake
        private static readonly string[] _talles = { "S", "M", "L", "XL", "XXL" };

        private static string CuitFake(Random r) => $"{r.Next(20, 28)}-{r.Next(10000000, 99999999)}-{r.Next(0, 9)}";
        private static string FechaFake(Random r)
        {
            var d = new DateTime(r.Next(2022, 2026), r.Next(1, 13), r.Next(1, 28));
            return d.ToString("dd/MM/yyyy");
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

            // 5. Destinatario existe
            if (!_destinatariosValidos.Contains(txtDniDestinatario.Text))
            {
                MessageBox.Show("El DNI ingresado no corresponde a un destinatario existente.", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rng = new Random(txtDniDestinatario.Text.GetHashCode());
            int cantidad = rng.Next(2, 5); // 2..4 filas

            for (int i = 0; i < cantidad; i++)
            {
                string nroGuia = $"#FR{rng.Next(1, 999):000}";
                string talle = _talles[rng.Next(_talles.Length)];
                string dniDest = txtDniDestinatario.Text;                     // el ingresado
                string cuitRem = CuitFake(rng);
                string fecha = FechaFake(rng);

                // Ejemplo de orden de columnas:
                // "#FR001", "S", "44997021", "23-44907018-8", "02/05/2023"
                lvEncomiendas.Items.Add(new ListViewItem(new[] { nroGuia, talle, dniDest, cuitRem, fecha }));
            }
        }



        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            // ¿Hay al menos una guía marcada?
            var seleccionadas = lvEncomiendas.Items
                .Cast<ListViewItem>()
                .Where(it => it.Checked)
                .ToList();

            if (seleccionadas.Count == 0)
            {
                MessageBox.Show(
                    "No puede confirmar una entrega sin haber seleccionado ninguna guía",
                    "Operación inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Confirmación de entrega
            MessageBox.Show(
                "Se ha completado la entrega al cliente seleccionado",
                "Entrega confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Eliminar SOLO las seleccionadas (iterar hacia atrás o usar lista previa)
            // Opción 1: usando la lista 'seleccionadas'
            foreach (var item in seleccionadas)
                lvEncomiendas.Items.Remove(item);

            // Si preferís iterar por índice:
            // for (int i = lvEncomiendas.Items.Count - 1; i >= 0; i--)
            //     if (lvEncomiendas.Items[i].Checked)
            //         lvEncomiendas.Items.RemoveAt(i);
        }
    }
}
