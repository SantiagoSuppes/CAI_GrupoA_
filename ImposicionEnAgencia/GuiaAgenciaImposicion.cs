using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public class GuiaAgenciaImposicion
    {
        public string NumeroGuia { get; set; }
        public DateTime FechaImposicion { get; set; }
        public EstadoActual EstadoActual { get; set; }
        public TamañoCajaAgencia TamañoCaja { get; set; }
        public Direccion Origen { get; set; }
        public Direccion Destino { get; set; }
        public HojaDeRuta HojaDeRuta { get; set; }
    }
}
