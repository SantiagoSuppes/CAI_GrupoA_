using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.Entidades
{
    public class CostoOperativaEnt
    {
        public GuiaEnt Guia { get; set; }
        public ActorEnum Actor { get; set; }
        public DateTime Periodo { get; set; }
        public decimal Monto { get; set; }
    }
}
//