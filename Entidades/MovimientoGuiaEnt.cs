using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.Entidades
{
    public class MovimientoGuiaEnt
    {
        public DateTime Fecha { get; set; }

        public TipoTramoEnum TipoTramo { get; set; }

        public EstadoActualEnum Estado { get; set; }

        public DireccionEnt Origen { get; set; }
        public DireccionEnt Destino { get; set; }

        public GuiaEnt Guia { get; set; }
    }
}

//