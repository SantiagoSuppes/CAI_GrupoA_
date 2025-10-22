using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CAI_GrupoA_.CdRendicionFletero
{
    public partial class CdRendicionFleteroForms : Form
    {
        private CdRendicionFleteroModelo modelo = new();
        private void btnBuscarViajesAsignados_Click(object sender, EventArgs e)
        {
            string dniStr = txtDniFletero.Text;
            if (!modelo.ValidarDni(dniStr))
            {
                MessageBox.Show("El DNI ingresado no es válido.");
                return;
            }
            long dni = long.Parse(dniStr);

            // Limpiar listas
            lvDetalle.Items.Clear();
            lvDistribucionesRealizadas.Items.Clear();
            lvRetirosNuevos.Items.Clear();
            lvDistNuevos.Items.Clear();

            // Generar y mostrar datos random
            var guias = modelo.GenerarGuiasRandom(dni, 3);
            var hojas = modelo.GenerarHojasDeRutaRandom(2);
            var fleteros = modelo.GenerarFleterosRandom(1);

            foreach (var guia in guias)
                lvDetalle.Items.Add(new ListViewItem(new[] {
            guia.NroGuia,
            guia.Talle,
            guia.DniDestinatario.ToString(),
            guia.Fecha.ToShortDateString(),
            guia.Cuit
        }));

            foreach (var hoja in hojas)
                lvDistribucionesRealizadas.Items.Add(new ListViewItem(new[] {
            hoja.NroHoja,
            hoja.TipoHojaDeRuta,
            hoja.Estado,
            hoja.Origen,
            hoja.Destino,
            hoja.fletero,
            hoja.transportista
        }));

            foreach (var retiro in guias)
                lvRetirosNuevos.Items.Add(new ListViewItem(new[] {
            retiro.NroGuia,
            retiro.Talle,
            retiro.DniDestinatario.ToString(),
            retiro.Fecha.ToShortDateString(),
            retiro.Cuit
        }));

            foreach (var dist in hojas)
                lvDistNuevos.Items.Add(new ListViewItem(new[] {
            dist.NroHoja,
            dist.TipoHojaDeRuta,
            dist.Estado,
            dist.Origen,
            dist.Destino,
            dist.fletero,
            dist.transportista
        }));
        }


    }
}