using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    public class Registro
    {
        public DateTime Fecha { get; set; }
        public string Empresa { get; set; } = "";
        public string Categoria { get; set; } = ""; // "Última Milla" | "Larga Distancia"
        public decimal Venta { get; set; }
        public decimal Costo { get; set; }
    }
}


