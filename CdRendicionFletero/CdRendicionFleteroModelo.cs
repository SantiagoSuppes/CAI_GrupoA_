using System;
using System.Collections.Generic;

namespace CAI_GrupoA_.CdRendicionFletero
{
    internal class CdRendicionFleteroModelo
    {
        public bool ValidarDni(string dniStr)
        {
            if (!long.TryParse(dniStr, out long dni))
                return false;
            return dni >= 10_000_000 && dni <= 9_999_999_999;
        }

        public List<GuiaEnt> GenerarGuiasRandom(long dni, int cantidad)
        {
            var rng = new Random();
            var guias = new List<GuiaEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                guias.Add(new GuiaEnt
                {
                    NroGuia = $"AG{rng.Next(1000, 9999)}",
                    DniDestinatario = dni,
                    // Completa con más propiedades si es necesario
                });
            }
            return guias;
        }

        public List<HojasDeRutaEnt> GenerarHojasDeRutaRandom(int cantidad)
        {
            var rng = new Random();
            var hojas = new List<HojasDeRutaEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                hojas.Add(new HojasDeRutaEnt
                {
                    // Completa con propiedades según HojasDeRutaEnt
                });
            }
            return hojas;
        }

        public List<FleteroEnt> GenerarFleterosRandom(int cantidad)
        {
            var rng = new Random();
            var fleteros = new List<FleteroEnt>();
            for (int i = 0; i < cantidad; i++)
            {
                fleteros.Add(new FleteroEnt
                {
                    // Completa con propiedades según FleteroEnt
                });
            }
            return fleteros;
        }

    }
}
