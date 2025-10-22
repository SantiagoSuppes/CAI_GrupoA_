using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAI_GrupoA_.Entidades;              // <-- importa tus Entidades
using CAI_GrupoA_.CdRendicionFletero;     // <-- importa el modelo

namespace CAI_GrupoA_.CdRendicionFletero
{//hola
    public partial class CdRendicionFleteroForms : Form
    {
        private readonly CdRendicionFleteroModelo modelo = new();

        private void btnBuscarViajesAsignados_Click(object sender, EventArgs e)
        {
            string dniStr = txtDniFletero.Text?.Trim();
            if (!modelo.ValidarDni(dniStr))
            {
                MessageBox.Show("El DNI ingresado no es válido (7 a 9 dígitos).");
                return;
            }

            // DNI entero (el modelo usa int)
            int dni = int.Parse(dniStr);

            // Limpiar listas
            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();

            // Datos random desde el modelo (coherentes con tus Entidades)
            var guias = modelo.GenerarGuiasRandom(dni, 3);
            var hojas = modelo.GenerarHojasDeRutaRandom(2);
            var fleteros = modelo.GenerarFleterosRandom(1);

            // Detalle de guías (tabla principal)
            foreach (var g in guias)
                lvDetalle.Items.Add(ItemFromGuia(g));

            // Distribuciones realizadas (hojas de ruta existentes)
            foreach (var h in hojas)
                lvDistribucionesRealizadas.Items.Add(ItemFromHoja(h));

            // Retiros nuevos (reuso de guías generadas)
            foreach (var g in guias)
                lvRetirosNuevos.Items.Add(ItemFromGuia(g));

            // Distribuciones nuevas (reuso de hojas generadas)
            foreach (var h in hojas)
                lvDistNuevos.Items.Add(ItemFromHoja(h));
        }

        // ---------------------------
        // Helpers de mapeo a ListView
        // ---------------------------
        private ListViewItem ItemFromGuia(GuiaEnt g)
        {
            // Columnas sugeridas:
            // 0: NumeroGuia
            // 1: TamañoCaja
            // 2: Destino (TipoPunto)
            // 3: Destino (Localidad y CP)
            // 4: FechaImposicion
            var destinoTipo = g.Destino?.TipoPunto.ToString() ?? "(s/d)";
            var destinoUbic = $"{g.Destino?.Localidad ?? "(s/d)"} - CP {g.Destino?.CodigoPostal.ToString() ?? "(s/d)"}";

            return new ListViewItem(new[]
            {
                g.NumeroGuia ?? "(sin nro)",
                g.TamañoCaja.ToString(),
                destinoTipo,
                destinoUbic,
                g.FechaImposicion.ToShortDateString()
            });
        }

        private ListViewItem ItemFromHoja(HojaDeRutaEnt h)
        {
            // Columnas sugeridas:
            // 0: TipoHojaDeRuta
            // 1: Estado
            // 2: Origen (Tipo + Localidad)
            // 3: Destino (Tipo + Localidad)
            // 4: Fletero (Nombre + DNI)
            // 5: Transportista (si hay dato)
            string origen = h.Origen is null
                ? "(s/d)"
                : $"{h.Origen.TipoPunto} - {h.Origen.Localidad}";

            string destino = h.Destino is null
                ? "(s/d)"
                : $"{h.Destino.TipoPunto} - {h.Destino.Localidad}";

            string fletero = h.Fletero is null
                ? "(s/d)"
                : $"{h.Fletero.Nombre} ({h.Fletero.DNI})";

            // TransportistaEnt no tiene campos en tu precarga, mostramos s/d
            string transportista = "(s/d)";

            return new ListViewItem(new[]
            {
                h.TipoHojaDeRuta.ToString(),
                h.Estado.ToString(),
                origen,
                destino,
                fletero,
                transportista
            });
        }
    }
}
