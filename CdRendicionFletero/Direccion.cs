using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CdRendicionFletero
{
    internal class Direccion
    {
        public ProvinciaEnum Provincia { get; set; }
        public string Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public TipoPuntoEnum TipoPunto { get; set; }
        public string CalleYAltura { get; set; }

    }
}

