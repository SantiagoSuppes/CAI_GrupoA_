using System;

namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    internal class GuiaAgencia
    {
        public string NumeroGuia { get; set; } = "";
        public TamañoCajaAgenciaEnum TamañoCaja { get; set; }
        public string Remitente { get; set; } = "";
        public string Destinatario { get; set; } = "";
        public DateTime FechaImposicion { get; set; }
    }
}



