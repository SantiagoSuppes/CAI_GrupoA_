namespace CAI_GrupoA_.AgenciaEntregarCliente
{
    internal class Guia
    {
        public string NumeroGuia { get; set; }
        public DateTime FechaImposicion { get; set; }

        // ✅ Usa el enum local, no el de Entidades
        public TamañoCajaEnum TamañoCaja { get; set; }

        public string Destinatario { get; set; }
        public string Remitente { get; set; }
    }
}

