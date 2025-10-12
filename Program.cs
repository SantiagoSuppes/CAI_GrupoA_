using CAI_GrupoA_.LogIn;
using CAI_GrupoA_.MenuPrincipal;
using CAI_GrupoA_.CallCenter;
using CAI_GrupoA_.ImposicionEnAgencia;
using CAI_GrupoA_.CdRecepcionPaquetes;
using CAI_GrupoA_.CdEntregarCliente;
using CAI_GrupoA_.FacturacionClientes;
using CAI_GrupoA_.CdRendicionFletero;
using CAI_GrupoA_.EstimacionCostosvsVentas;
using CAI_GrupoA_.GuiaEstadoHistorial;

namespace CAI_GrupoA_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new LogInForm());

            Application.Run(new MenuPrincipalForm());

            Application.Run(new CallCenterForm());
            Application.Run(new ImposicionEnAgenciaForm());
            Application.Run(new CdRecepcionPaquetesForm());

            Application.Run(new CdEntregarClienteForm());
            Application.Run(new FacturacionClienteForm());

            Application.Run(new CdRendicionFleteroForm());
            Application.Run(new EstimacionCostosvsVentasForms());
            Application.Run(new GuiaEstadoHistorialForm());

        }
    }
}