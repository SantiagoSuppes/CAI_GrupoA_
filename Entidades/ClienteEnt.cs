using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.Entidades
{
    public class ClienteEnt
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string DomicilioFiscal { get; set; }

        public CondicionIVAEnum CondicionIVA { get; set; }

        public bool ConvenioVigente { get; set; }

        public List<DireccionEnt> Direcciones { get; set; } = new();
    }
}
