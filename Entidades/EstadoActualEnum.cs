using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.Entidades
{
    public enum EstadoActualEnum
    {
        EnDomicilio_ListaParaRetirar = 1,
        EnAgencia_ListaParaRetirar = 2,
        EnCD_ListaParaEntregar = 3,
        EnCD_EnEsperaDeViaje = 4,
        EnAgencia_ListaParaEntregar = 5,
        Entregada = 6,
        EnRetiro = 7,
        EnDistribucion = 8
    }
}
