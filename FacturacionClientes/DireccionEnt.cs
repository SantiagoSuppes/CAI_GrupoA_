using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.FacturacionClientes
{
    internal class DireccionEnt
    {
        public string CalleYAltura { get; set; }
        public string Localidad { get; set; } 
        public ProvinciaEnum Provincia { get; set; }
    }
}
