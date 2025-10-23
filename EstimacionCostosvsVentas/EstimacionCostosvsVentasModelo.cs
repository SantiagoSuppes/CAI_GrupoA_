using System;
using System.Collections.Generic;
using System.Linq;

namespace CAI_GrupoA_.EstimacionCostosvsVentas
{
    internal class EstimacionCostosvsVentasModelo
    {
        private readonly List<Registro> _datos = new()
        {
            new(){Fecha=new DateTime(2025,10,01), Empresa="Transporte Andino S.A",     Categoria="Larga Distancia", Venta=120000, Costo=90000},
            new(){Fecha=new DateTime(2025,10,10), Empresa="Transporte Andino S.A",     Categoria="Última Milla",    Venta=80000,  Costo=56000},
            new(){Fecha=new DateTime(2025,10,05), Empresa="Distribuidora Córdoba SRL", Categoria="Larga Distancia", Venta=60000,  Costo=42000},
            new(){Fecha=new DateTime(2025,10,15), Empresa="Logística del Litoral S.A", Categoria="Última Milla",    Venta=100000, Costo=70000},
            new(){Fecha=new DateTime(2025,10,21), Empresa="Logística del Litoral S.A", Categoria="Larga Distancia", Venta=40000,  Costo=26000},
        };

        public List<string> ObtenerEmpresas()
        {
            var lista = _datos.Select(d => d.Empresa).Distinct().OrderBy(x => x).ToList();
            lista.Insert(0, "(Todas)");
            return lista;
        }

        public List<string> ObtenerCategorias()
        {
            return new() { "(Todas)", "Última Milla", "Larga Distancia" };
        }

        public List<ResumenEmpresa> Filtrar(DateTime periodo, string empresa, string categoria)
        {
            var q = _datos.Where(d => d.Fecha.Year == periodo.Year && d.Fecha.Month == periodo.Month);

            if (empresa != "(Todas)") q = q.Where(d => d.Empresa == empresa);
            if (categoria != "(Todas)") q = q.Where(d => d.Categoria == categoria);

            return q.GroupBy(d => d.Empresa)
                    .Select(g => new ResumenEmpresa
                    {
                        Empresa = g.Key,
                        Venta = g.Sum(x => x.Venta),
                        Costo = g.Sum(x => x.Costo)
                    })
                    .OrderBy(r => r.Empresa)
                    .ToList();
        }
    }
}

