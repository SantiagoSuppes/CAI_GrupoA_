using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    public class ResumenEmpresa
    {
        public string Empresa { get; set; } = "";
        public decimal Venta { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia => Venta - Costo;
    }
}
