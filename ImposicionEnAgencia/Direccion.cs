using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public  class Direccion
    {
        public string Localidad { get; set; }
        public int CodigoPostal { get; set; }

        public TipoPunto TipoPunto { get; set; }

        public string CalleYAltura { get; set; }

        public Provincia Provincia { get; set; }
    }
}
