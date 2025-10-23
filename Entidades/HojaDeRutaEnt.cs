using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.Entidades
{
    public class HojaDeRutaEnt
    {
        public TipoHojaDeRutaEnum TipoHojaDeRuta { get; set; }
        public EstadoActualHojaDeRutaEnum Estado { get; set; }

        public DireccionEnt Origen { get; set; }
        public DireccionEnt Destino { get; set; }

        public FleteroEnt Fletero { get; set; }
        public TransportistaEnt Transportista { get; set; }
    }
}

//

