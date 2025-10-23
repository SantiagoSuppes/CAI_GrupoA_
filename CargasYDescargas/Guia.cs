using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CargasYDescargas
{
    public class Guia
    {
        public string NumeroGuia { get; set; }
        public string Destinatario { get; set; }
        public string Remitente { get; set; }
        public string Estado { get; set; }
        public bool EsCarga { get; set; }
    }
}

