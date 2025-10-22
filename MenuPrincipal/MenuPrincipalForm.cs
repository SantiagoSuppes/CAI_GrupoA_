using System;
using System;
using System.Windows.Forms;

// === Referencias correctas según tu estructura ===
using CAI_GrupoA_.CallCenter;
using CAI_GrupoA_.CargasYDescargas;
using CAI_GrupoA_.CdEntregarCliente;
using CAI_GrupoA_.CdRecepcionPaquetes;
using CAI_GrupoA_.CdRendicionFletero;
using CAI_GrupoA_.GuiaEstadoHistorial;
using CAI_GrupoA_.ImposicionEnAgencia;
using CAI_GrupoA_.EstimacionCostosvsVentas;
using CAI_GrupoA_.FacturacionClientes;
using CAI_GrupoA_.LogIn;
using CAI_GrupoA_.AgenciaEntregarCliente;

namespace CAI_GrupoA_.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        // 🔹 Modelo de validaciones y roles
        private readonly MenuPrincipalModelo modelo = new();

        public MenuPrincipalForm()
        {
            InitializeComponent();

            // Configurar eventos
            Load += MenuPrincipalForm_Load;

            // Botones operativos (logística)
            btnCallCenter.Click += (s, e) => Abrir(() => new CallCenterForm());
            btnRecepcionCD.Click += (s, e) => Abrir(() => new CdRecepcionPaquetesForm());
            btnRecepcionAg.Click += (s, e) => Abrir(() => new ImposicionEnAgenciaForm());
            btnCargaDescarga.Click += (s, e) => Abrir(() => new CargasYDescargasForm());
            btnEntregaAgencia.Click += (s, e) => Abrir(() => new AgenciaEntregarClienteForm());
            btnRendicion.Click += (s, e) => Abrir(() => new CdRendicionFleteroForms());
            btnEstado.Click += (s, e) => Abrir(() => new GuiaEstadoHistorialForm());
            btnEntregaCD.Click += (s, e) => Abrir(() => new CdEntregarClienteForms());

            // Botones financieros → con validación
            btnReportesCostos.Click += (s, e) =>
            {
                if (!modelo.TieneAcceso("Reportes")) return;
                Abrir(() => new EstimacionCostosvsVentasForms());
            };

            btnFacturacion.Click += (s, e) =>
            {
                if (!modelo.TieneAcceso("Facturación")) return;
                Abrir(() => new FacturacionClienteForm());
            };

            // Cerrar sesión
            btnCerrarSesion.Click += btnCerrarSesion_Click;
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            // Mostrar fecha actual
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = DateTime.Today;

            // Usuario ficticio para la sesión actual
            txtUsuario.Text = "admin.finanzas"; // o "admin.finanzas" si querés probar
            txtUsuario.ReadOnly = true;

            // Inicializar sesión en el modelo
            modelo.IniciarSesion(txtUsuario.Text);
        }

        // Abre los formularios como modales
        private void Abrir(Func<Form> fabrica)
        {
            using (var f = fabrica())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        // Cerrar sesión y volver al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Hide();
            using (var login = new LogInForm())
            {
                login.StartPosition = FormStartPosition.CenterScreen;
                login.ShowDialog();
            }
            Close();
        }

        // Handler para el label del menú
        private void lblMenu_Click(object sender, EventArgs e) { }
    }
}