using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.ImposicionEnAgencia
{
    public class Cliente
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string DomicilioFiscal { get; set; }

        public CondicionIVA CondicionIVA { get; set; }

        public bool ConvenioVigente { get; set; }

        public List<Direccion> Direcciones { get; set; } = new();
    }
}
