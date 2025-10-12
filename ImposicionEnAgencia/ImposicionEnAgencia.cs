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

        // Diccionario simulado de agencias y CD por provincia
        private readonly Dictionary<string, (List<string> Agencias, List<string> CDs)> zonasPorProvincia = new()
        {
            { "Ciudad Autónoma de Buenos Aires", (new List<string>{ "Agencia Retiro", "Agencia Palermo" }, new List<string>{ "CD Central" }) },
            { "Buenos Aires", (new List<string>{ "Agencia Morón", "Agencia Ituzaingó" }, new List<string>{ "CD Oeste" }) },
            { "Córdoba", (new List<string>{ "Agencia Córdoba Centro", "Agencia Nueva Córdoba" }, new List<string>{ "CD Córdoba" }) },
            { "Mendoza", (new List<string>{ "Agencia Mendoza Norte" }, new List<string>{ "CD Cuyo" }) },
            { "Santa Fe", (new List<string>{ "Agencia Rosario", "Agencia Santa Fe" }, new List<string>{ "CD Litoral" }) },
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

            // Validar formato de CUIT
            if (!Regex.IsMatch(cuit, @"^\d{2}-?\d{8}-?\d{1}$"))
            {
                MessageBox.Show("Formato de CUIT inválido. Ejemplo: 20-35123456-7",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar cliente
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

            // Limpiar valores anteriores
            txtDomicilio.Clear();
            cmbAgencia.SelectedIndex = -1;
            cmbCD.SelectedIndex = -1;

            // Deshabilitar todos
            txtDomicilio.Enabled = false;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;

            // Habilitar el correspondiente
            if (modalidad == "Entrega en Agencia")
                cmbAgencia.Enabled = true;
            else if (modalidad == "Entrega en CD")
                cmbCD.Enabled = true;
            else if (modalidad == "Envío a Domicilio")
                txtDomicilio.Enabled = true;
        }

        // --- Cambio de provincia ---
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string provincia = cmbProvincia.Text.Trim();

            cmbAgencia.Items.Clear();
            cmbCD.Items.Clear();

            if (zonasPorProvincia.TryGetValue(provincia, out var datos))
            {
                cmbAgencia.Items.AddRange(datos.Agencias.ToArray());
                cmbCD.Items.AddRange(datos.CDs.ToArray());
            }
        }

        // --- Agregar Caja ---
        private void btnAgregarCaja_Click(object sender, EventArgs e)
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

            // Mostrar en ListView (como pendiente)
            var item = new ListViewItem($"(Pendiente)");
            item.SubItems.Add(cantidad.ToString());
            item.SubItems.Add(cmbTipoCaja.Text);
            lstGuiasGeneradas.Items.Add(item);

            cmbTipoCaja.SelectedIndex = -1;
            MessageBox.Show("Caja agregada correctamente.",
                "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerarGuia_Click_1(object sender, EventArgs e)
        {
            var errores = new System.Text.StringBuilder();

            try
            {
                // ---  Validaciones del formulario ---
                if (cajasTemporales.Count == 0)
                    errores.AppendLine("- Debe agregar al menos una caja antes de generar la guía.");

             
                else if (!Regex.IsMatch(txtCUIT.Text, @"^\d{2}-?\d{8}-?\d{1}$"))
                    errores.AppendLine("- El formato del CUIT es inválido (ejemplo: 20-35123456-7).");

                

                if (string.IsNullOrWhiteSpace(txtNombreDestinatario.Text))
                    errores.AppendLine("- Debe ingresar el nombre del destinatario.");

                if (string.IsNullOrWhiteSpace(txtDNIDest.Text))
                    errores.AppendLine("- Debe ingresar el DNI del destinatario.");
                else if (!txtDNIDest.Text.All(char.IsDigit))
                    errores.AppendLine("- El DNI debe contener solo números.");

                if (string.IsNullOrWhiteSpace(cmbProvincia.Text))
                    errores.AppendLine("- Debe seleccionar una provincia.");

                if (string.IsNullOrWhiteSpace(txtLocalidad.Text))
                    errores.AppendLine("- Debe ingresar la localidad de destino.");
                else if (txtLocalidad.Text.Any(char.IsDigit))
                    errores.AppendLine("- La localidad no puede contener números.");

                if (string.IsNullOrWhiteSpace(txtCP.Text))
                    errores.AppendLine("- Debe ingresar el código postal.");
                else if (!txtCP.Text.All(char.IsDigit))
                    errores.AppendLine("- El código postal debe contener solo números.");

                if (string.IsNullOrWhiteSpace(cmbModalidadEntrega.Text))
                    errores.AppendLine("- Debe seleccionar la modalidad de entrega.");

                string modalidad = cmbModalidadEntrega.Text;
                if (modalidad == "Entrega en Agencia" && string.IsNullOrWhiteSpace(cmbAgencia.Text))
                    errores.AppendLine("- Debe seleccionar una Agencia para la entrega.");
                if (modalidad == "Entrega en CD" && string.IsNullOrWhiteSpace(cmbCD.Text))
                    errores.AppendLine("- Debe seleccionar un Centro de Distribución (CD).");
                if (modalidad == "Envío a Domicilio" && string.IsNullOrWhiteSpace(txtDomicilio.Text))
                    errores.AppendLine("- Debe ingresar la dirección de envío a domicilio.");

                // --- Validaciones de negocio (modelo) ---
                try
                {
                    modelo.CrearGuia(
                        txtCUIT.Text,
                        txtRazonSocial.Text,
                        "",
                        txtNombreDestinatario.Text,
                        "",
                        txtDNIDest.Text,
                        txtTelefonoDest.Text,
                        txtDomicilio.Text,
                        txtLocalidad.Text,
                        cmbProvincia.Text,
                        txtCP.Text,
                        "",
                        0,
                        cmbModalidadEntrega.Text,
                        true,  
                        true   
                    );
                }
                catch (ArgumentException ex)
                {
                    errores.AppendLine(ex.Message);
                }

                // --- Mostrar todo junto ---
                if (errores.Length > 0)
                {
                    MessageBox.Show("Revisá los siguientes errores antes de continuar:\n\n" + errores.ToString(),
                        "Campos incompletos o inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- Si todo está bien, generar la guía ---
                var g = modelo.CrearGuia(
    txtCUIT.Text,
    txtRazonSocial.Text,
    "",
    txtNombreDestinatario.Text,
    "",
    txtDNIDest.Text,
    txtTelefonoDest.Text,
    txtDomicilio.Text,
    txtLocalidad.Text,
    cmbProvincia.Text,
    txtCP.Text,
    "",
    0,
    cmbModalidadEntrega.Text,
    true,   
    false   
);

                lstGuiasGeneradas.Items.Clear();
                foreach (var c in cajasTemporales)
                {
                    var item = new ListViewItem(g.Numero);
                    item.SubItems.Add(c.Cantidad.ToString());
                    item.SubItems.Add(c.Tamanio);
                    lstGuiasGeneradas.Items.Insert(0, item);
                }

                MessageBox.Show($"Guía generada correctamente.\n\nN° {g.Numero}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cajasTemporales.Clear();
                LimpiarCampos();
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
            txtLocalidad.Clear();
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
    }
}
