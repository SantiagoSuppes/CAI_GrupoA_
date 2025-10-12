using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public partial class ImposicionEnAgencia : Form
    {
        public GuiasGeneradasEnAgencia modelo = new();

        // Diccionario simulado de agencias y CD por código postal
        private readonly Dictionary<string, (List<string> Agencias, List<string> CDs)> zonas = new()
        {
            { "1000", (new List<string>{ "Agencia Retiro", "Agencia Palermo" }, new List<string>{ "CD Central" }) },
            { "1708", (new List<string>{ "Agencia Morón", "Agencia Ituzaingó" }, new List<string>{ "CD Oeste" }) },
            { "5000", (new List<string>{ "Agencia Córdoba Centro" }, new List<string>{ "CD Córdoba" }) },
            { "5500", (new List<string>{ "Agencia Mendoza Norte" }, new List<string>{ "CD Cuyo" }) },
        };
        private List<(string Tamanio, int Cantidad)> cajasTemporales = new();

        public ImposicionEnAgencia()
        {
            InitializeComponent();
        }

        private void ImposicionEnAgencia_Load(object sender, EventArgs e)
        {
            // --- Configuración ListView ---
            lstGuiasGeneradas.View = View.Details;
            lstGuiasGeneradas.FullRowSelect = true;
            lstGuiasGeneradas.Columns.Clear();
            lstGuiasGeneradas.Columns.Add("N° Guía", 120);
            lstGuiasGeneradas.Columns.Add("Cantidad", 100);
            lstGuiasGeneradas.Columns.Add("Tamaño", 120);

            // --- Configuración de combos ---
            cmbTipoCaja.Items.AddRange(new[] { "S", "M", "L", "XL" });
            cmbTipoCaja.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbProvincia.Items.AddRange(new[]
            {
                "Buenos Aires","Ciudad Autónoma de Buenos Aires","Catamarca","Chaco","Chubut","Córdoba",
                "Corrientes","Entre Ríos","Formosa","Jujuy","La Pampa","La Rioja","Mendoza","Misiones",
                "Neuquén","Río Negro","Salta","San Juan","San Luis","Santa Cruz","Santa Fe",
                "Santiago del Estero","Tierra del Fuego, Antártida e Islas del Atlántico Sur","Tucumán"
            });
            cmbProvincia.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbModalidadEntrega.Items.AddRange(new[] { "Entrega en Agencia", "Entrega en CD", "Envío a Domicilio" });
            cmbModalidadEntrega.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAgencia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCD.DropDownStyle = ComboBoxStyle.DropDownList;

            numCantidad.Minimum = 1;
            numCantidad.Value = 1;

            // --- Estado inicial ---
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;
            txtDomicilio.Enabled = false;
        }

        // --- Buscar remitente ---
        private void btnBuscarRemitente_Click(object sender, EventArgs e)
        {

            string cuit = txtCUIT.Text.Trim();

            // 1️⃣ Verificar formato de CUIT
            if (!Regex.IsMatch(cuit, @"^\d{2}-?\d{8}-?\d{1}$"))
            {
                MessageBox.Show("Formato de CUIT inválido. Ejemplo correcto: 20-35123456-7",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Buscar cliente
            if (modelo.TryGetCliente(cuit, out var cli))
            {
                txtRazonSocial.Text = cli.Nombre;
                MessageBox.Show($"Cliente encontrado:\n\n{cli.Nombre}", "Cliente existente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtRazonSocial.Clear();
                MessageBox.Show($"El cliente con CUIT {cuit} no existe en el sistema.",
                    "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- Modalidad de entrega ---
        private void cmbModalidadEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            string modalidad = cmbModalidadEntrega.Text;

            // Limpiar campos previos al cambiar modalidad
            txtDomicilio.Clear();
            cmbAgencia.SelectedIndex = -1;
            cmbCD.SelectedIndex = -1;

            // Deshabilitar todos
            txtDomicilio.Enabled = false;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;

            // Habilitar solo lo correspondiente
            if (modalidad == "Entrega en Agencia")
                cmbAgencia.Enabled = true;
            else if (modalidad == "Entrega en CD")
                cmbCD.Enabled = true;
            else if (modalidad == "Envío a Domicilio")
                txtDomicilio.Enabled = true;
        }

        // --- Código postal cambia: actualizar Agencias/CD ---
        private void txtCP_TextChanged(object sender, EventArgs e)
        {
            string cp = txtCP.Text.Trim();
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();

            if (cp.Length < 4) return;

            // Buscar coincidencia parcial (ej: 5001, 5002 -> coincide con 5000)
            var zona = zonas.FirstOrDefault(z => cp.StartsWith(z.Key));

            if (!zona.Equals(default(KeyValuePair<string, (List<string>, List<string>)>)))
            {
                cmbAgencia.Items.AddRange(zona.Value.Agencias.ToArray());
                cmbCD.Items.AddRange(zona.Value.CDs.ToArray());
            }
        }

        // --- Generar Guía ---
        private void btnGenerarGuia_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cajasTemporales.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos una caja antes de generar la guía.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var g = modelo.CrearGuia(
                    txtCUIT.Text,
                    txtRazonSocial.Text,
                    "",
                    txtNombreDestinatario.Text,
                    "", // apellido no se usa
                    txtDNIDest.Text,
                    txtTelefonoDest.Text,
                    txtDomicilio.Text,
                    "",
                    cmbProvincia.Text,
                    txtCP.Text,
                    "", // tamaño no se usa aquí, se agregan varias
                    0,
                    cmbModalidadEntrega.Text
                );

                // Agregar todas las cajas registradas
                foreach (var c in cajasTemporales)
                {
                    var item = new ListViewItem(g.Numero);
                    item.SubItems.Add(c.Cantidad.ToString());
                    item.SubItems.Add(c.Tamanio);
                    lstGuiasGeneradas.Items.Insert(0, item);
                }

                MessageBox.Show($"Guía generada correctamente.\n\nN° {g.Numero}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar
                cajasTemporales.Clear();
                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Revisá los datos:\n\n" + ex.Message,
                    "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombreDestinatario.Clear();
            txtDNIDest.Clear();
            txtTelefonoDest.Clear();
            txtDomicilio.Clear();
            txtCP.Clear();
            cmbProvincia.SelectedIndex = -1;
            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();
            cmbTipoCaja.SelectedIndex = -1;
            cmbModalidadEntrega.SelectedIndex = -1;
            numCantidad.Value = 1;

            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;
            txtDomicilio.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar selección de tamaño
            if (string.IsNullOrWhiteSpace(cmbTipoCaja.Text))
            {
                MessageBox.Show("Debe seleccionar un tamaño de caja antes de agregar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar cantidad
            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agregar a la lista temporal
            cajasTemporales.Add((cmbTipoCaja.Text, cantidad));

            // Mostrar en ListView
            var item = new ListViewItem($"(Pendiente)"); // aún no tiene número de guía
            item.SubItems.Add(cantidad.ToString());
            item.SubItems.Add(cmbTipoCaja.Text);
            lstGuiasGeneradas.Items.Add(item);

            // Limpiar los campos de caja
            cmbTipoCaja.SelectedIndex = -1;
        

            MessageBox.Show("Caja agregada correctamente.",
                "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
