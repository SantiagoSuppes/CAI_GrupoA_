using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoA_.CdEntregarCliente;
internal class Guia
{
    public string NroGuia { get; set; } 
    public string Talle { get; set; }
    public long DniDestinatario { get; set; }
    public DateTime Fecha { get; set; }
    public string Cuit { get; set; }
}
