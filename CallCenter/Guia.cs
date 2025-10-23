using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAI_GrupoA_.CdRecepcionPaquetes;

namespace CAI_GrupoA_.CallCenter
{
    internal class Guia
    {
        public string NumeroGuia { get; set; } 
        public DateTime FechaImposicion { get; set; }
        public TamañoCajaEnum TamañoCaja { get; set; }
        public Direccion Origen { get; set; }
        public Direccion Destino { get; set; }
        public string Destinatario { get; set; } 
        public string Remitente { get; set; } 
        public string Estado { get; set; } 
    }
}

