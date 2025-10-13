using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    public partial class AgenciaEntregarClienteForm : Form
    {
        public AgenciaEntregarClienteForm()
        {
            InitializeComponent();
        }

        // Padrón de destinatarios válidos (simulado)
        private readonly HashSet<string> _destinatariosValidos = new HashSet<string>
        {
            "44997021","30111222","23333444","40999888","36555111"
        };

        // DNI ya cargados
        private readonly HashSet<string> _dnisAgregados = new HashSet<string>();

        // Datos fake
        private static readonly string[] _talles = { "S", "M", "L", "XL", "XXL" };

        private static string CuitFake(Random r) => $"{r.Next(20, 28)}-{r.Next(10000000, 99999999)}-{r.Next(0, 9)}";
        private static string FechaFake(Random r)
        {
            var d = new DateTime(r.Next(2022, 2026), r.Next(1, 13), r.Next(1, 28));
            return d.ToString("dd/MM/yyyy");
        }

        private void AgenciaEntregarClienteForm_Load(object sender, EventArgs e)
        {
            // Configuración esperada del ListView
            lvEncomiendas.View = View.Details;
            lvEncomiendas.CheckBoxes = true;
            lvEncomiendas.FullRowSelect = true;
        }

        private void btnBuscarEncomiendaDestinatario_Click_1(object sender, EventArgs e)
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

            var dniTexto = txtDniDestinatario.Text;

            // 6. Evitar duplicados
            if (_dnisAgregados.Contains(dniTexto) || YaCargadoEnLista(dniTexto))
            {
                MessageBox.Show("Las encomiendas para este DNI ya fueron cargadas.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Generar filas fake determinísticas por DNI
            var rng = new Random(txtDniDestinatario.Text.GetHashCode());
            int cantidad = rng.Next(2, 5); // 2..4 filas

            for (int i = 0; i < cantidad; i++)
            {
                string nroGuia = $"#AG{rng.Next(1, 999):000}";
                string talle = _talles[rng.Next(_talles.Length)];
                string dniDest = txtDniDestinatario.Text;
                string cuitRem = CuitFake(rng);
                string fecha = FechaFake(rng);

                lvEncomiendas.Items.Add(new ListViewItem(new[] { nroGuia, talle, dniDest, cuitRem, fecha }));
            }

            _dnisAgregados.Add(dniTexto);
        }

        private bool YaCargadoEnLista(string dni)
        {
            return lvEncomiendas.Items.Cast<ListViewItem>()
                .Any(it => it.SubItems.Count > 2 && it.SubItems[2].Text == dni);
        }

        private void btnConfirmarEntrega_Click_1(object sender, EventArgs e)
        {
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

            MessageBox.Show(
                "Se ha completado la entrega al cliente seleccionado",
                "Entrega confirmada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            foreach (var item in seleccionadas)
                lvEncomiendas.Items.Remove(item);
        }
    }
}
