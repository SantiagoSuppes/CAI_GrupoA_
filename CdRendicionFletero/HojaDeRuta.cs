using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CdRendicionFletero
{
    internal class HojaDeRuta
    {
        public TipoHojaDeRutaEnum TipoHojaDeRuta { get; set; }
        public EstadoActualHojaDeRutaEnum Estado { get; set; }

        public Direccion Origen { get; set; }
        public Direccion Destino { get; set; }

        public Fletero Fletero { get; set; }
        public Transportista Transportista { get; set; }
    }
}

