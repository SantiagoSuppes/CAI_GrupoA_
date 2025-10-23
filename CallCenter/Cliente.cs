using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CallCenter
{
    internal class Cliente
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public List<Direccion> Direcciones { get; set; } = new();
    }
}
