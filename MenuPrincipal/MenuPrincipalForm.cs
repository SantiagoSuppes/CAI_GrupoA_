using System;
using System.Windows.Forms;

// === Referencias correctas según tu estructura de carpetas ===
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
using CAI_GrupoA_.AgenciaEntregarCliente;   // Nombre correcto del namespace del Login

namespace CAI_GrupoA_.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();

            // Cargar eventos
            Load += MenuPrincipalForm_Load;

            btnCallCenter.Click += (s, e) => Abrir(() => new CallCenterForm());
            btnRecepcionCD.Click += (s, e) => Abrir(() => new CdRecepcionPaquetesForm());
            btnRecepcionAg.Click += (s, e) => Abrir(() => new ImposicionEnAgenciaForm());
            btnCargaDescarga.Click += (s, e) => Abrir(() => new CargasYDescargasForm());
            btnEntregaAgencia.Click += (s, e) => Abrir(() => new AgenciaEntregarClienteForm());
            btnRendicion.Click += (s, e) => Abrir(() => new CdRendicionFleteroForms());
            btnEstado.Click += (s, e) => Abrir(() => new GuiaEstadoHistorialForm());
            btnEntregaCD.Click += (s, e) => Abrir(() => new CdEntregarClienteForms());
            btnReportesCostos.Click += (s, e) => Abrir(() => new EstimacionCostosvsVentasForms());
            btnFacturacion.Click += (s, e) => Abrir(() => new FacturacionClienteForm());

            btnCerrarSesion.Click += btnCerrarSesion_Click;
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            // Fecha actual
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = DateTime.Today;

            // Usuario ficticio
            txtUsuario.Text = "operador.demo";
            txtUsuario.ReadOnly = true;
        }

        // Abrir formularios modales
        private void Abrir(Func<Form> fabrica)
        {
            using (var f = fabrica())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        // Cerrar sesión → volver al login
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Hide();
            using (var login = new LogInForm()) // nombre correcto
            {
                login.StartPosition = FormStartPosition.CenterScreen;
                login.ShowDialog();
            }
            Close();
        }

        // Handler si el diseñador lo necesita
        private void lblMenu_Click(object sender, EventArgs e) { }

        private void btnEntregaAg_Click(object sender, EventArgs e)
        {

        }
    }
}
