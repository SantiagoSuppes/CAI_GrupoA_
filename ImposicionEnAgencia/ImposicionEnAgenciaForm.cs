using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public partial class ImposicionEnAgenciaForm : Form
    {
        public GuiasGeneradasEnAgencia modelo = new();

        // Diccionario simulado de agencias y CD por provincia---
        private readonly Dictionary<string, (List<string> Agencias, List<string> CDs)> zonasPorProvincia = new()
        {
            { "Ciudad Autónoma de Buenos Aires", (new List<string>{ "Agencia Retiro", "Agencia Palermo" }, new List<string>{ "CD Central" }) },
            { "Buenos Aires", (new List<string>{ "Agencia Morón", "Agencia Ituzaingó" }, new List<string>{ "CD Oeste" }) },
            { "Córdoba", (new List<string>{ "Agencia Córdoba Centro", "Agencia Nueva Córdoba" }, new List<string>{ "CD Córdoba" }) },
            { "Mendoza", (new List<string>{ "Agencia Mendoza Norte" }, new List<string>{ "CD Cuyo" }) },
            { "Santa Fe", (new List<string>{ "Agencia Rosario", "Agencia Santa Fe" }, new List<string>{ "CD Litoral" }) },
        };

        private List<(string Tamanio, int Cantidad)> cajasTemporales = new();

        public ImposicionEnAgenciaForm()
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
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
        }

        // --- Buscar remitente ---
        private void btnBuscarRemitente_Click(object sender, EventArgs e)
        {
            string cuit = txtCUIT.Text.Trim();

            // Permitir con o sin guiones
            cuit = cuit.Replace("-", "").Trim();

            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
            {
                MessageBox.Show("Formato de CUIT inválido. Debe tener 11 dígitos (ej: 20-35123456-7 o 20351234567).",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            // Limpiar selección previa
            txtDomicilio.Clear();
            cmbAgencia.SelectedIndex = -1;
            cmbCD.SelectedIndex = -1;

            // Deshabilitar todo
            txtDomicilio.Enabled = false;
            cmbAgencia.Enabled = false;
            cmbCD.Enabled = false;

            // Habilitar según modalidad
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

        // --- Agregar caja ---
        private void btnAgregarCaja_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTipoCaja.Text))
            {
                MessageBox.Show("Debe seleccionar un tamaño de caja antes de agregar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cajasTemporales.Add((cmbTipoCaja.Text, cantidad));

            var item = new ListViewItem("(Pendiente)");
            item.SubItems.Add(cantidad.ToString());
            item.SubItems.Add(cmbTipoCaja.Text);
            lstGuiasGeneradas.Items.Add(item);

            cmbTipoCaja.SelectedIndex = -1;

            MessageBox.Show("Caja agregada correctamente.",
                "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- Generar guía ---
        private void btnGenerarGuia_Click_1(object sender, EventArgs e)
        {
            var errores = new System.Text.StringBuilder();

            try
            {
                // --- SOLO validaciones del FORM que el modelo no conoce ---
                if (cajasTemporales.Count == 0)
                    errores.AppendLine("- Debe agregar al menos una caja antes de generar la guía.");

                if (string.IsNullOrWhiteSpace(cmbModalidadEntrega.Text))
                    errores.AppendLine("- Debe seleccionar la modalidad de entrega.");

                string modalidad = cmbModalidadEntrega.Text;
                if (modalidad == "Entrega en Agencia" && string.IsNullOrWhiteSpace(cmbAgencia.Text))
                    errores.AppendLine("- Debe seleccionar una Agencia para la entrega.");
                if (modalidad == "Entrega en CD" && string.IsNullOrWhiteSpace(cmbCD.Text))
                    errores.AppendLine("- Debe seleccionar un Centro de Distribución (CD).");
                if (modalidad == "Envío a Domicilio" && string.IsNullOrWhiteSpace(txtDomicilio.Text))
                    errores.AppendLine("- Debe ingresar la dirección de envío a domicilio.");

                // --- 2) Validación de negocio (una sola llamada, sin crear guía) ---
                try
                {
                    modelo.CrearGuia(
                        txtCUIT.Text,              // CUIT (con/sin guiones)
                        txtRazonSocial.Text,       // Razón social
                        "",                        // tel remitente (si no lo usás)
                        txtNombreDestinatario.Text,
                        "",                        // apellido no usado
                        txtDNIDest.Text,
                        txtTelefonoDest.Text,
                        txtDomicilio.Text,
                        txtLocalidad.Text,
                        cmbProvincia.Text,
                        txtCP.Text,
                        "", 0, cmbModalidadEntrega.Text,
                        omitirValidacionCaja: true,
                        soloValidar: true
                    );
                }
                catch (ArgumentException ex)
                {
                    // Agregar los errores del modelo (puede traer varios)
                    errores.AppendLine(ex.Message);
                }

                // --- 3) DEDUPLICAR LÍNEAS antes de mostrar ---
                var unico = DeduplicarLineas(errores.ToString());
                if (!string.IsNullOrWhiteSpace(unico))
                {
                   
                    int cant = unico.Split('\n').Count(l => !string.IsNullOrWhiteSpace(l));
                    MessageBox.Show($"Se detectaron {cant} errores:\n\n{unico}",
                        "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- 4) Crear guía REAL (sin validar cajas en el modelo) ---
                var g = modelo.CrearGuia(
                    txtCUIT.Text, txtRazonSocial.Text, "",
                    txtNombreDestinatario.Text, "",
                    txtDNIDest.Text, txtTelefonoDest.Text,
                    txtDomicilio.Text, txtLocalidad.Text,
                    cmbProvincia.Text, txtCP.Text,
                    "", 0, cmbModalidadEntrega.Text,
                    omitirValidacionCaja: true,
                    soloValidar: false
                );

                // pintar las cajas en la lista
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

       
        private static string DeduplicarLineas(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            var hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var sb = new System.Text.StringBuilder();
            foreach (var raw in texto.Replace("\r", "").Split('\n'))
            {
                var line = raw.TrimEnd();
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (hs.Add(line)) sb.AppendLine(line);
            }
            return sb.ToString();
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
