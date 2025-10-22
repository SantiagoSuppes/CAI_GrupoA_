using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAI_GrupoA_.CdRecepcionPaquetes;

namespace CAI_GrupoA_.Entidades
{
    public class GuiaEnt
    {
        public string NumeroGuia { get; set; }
        public DateTime FechaImposicion { get; set; }

        public EstadoActualEnum EstadoActual { get; set; }
        public TamañoCajaEnum TamañoCaja { get; set; }

        public DireccionEnt Origen { get; set; }
        public DireccionEnt Destino { get; set; }

        public HojaDeRutaEnt HojaDeRuta { get; set; }
    }
}
