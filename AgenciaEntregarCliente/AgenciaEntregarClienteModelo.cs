namespace CAI_GrupoA_.AgenciaEntregarCliente;
internal class AgenciaEntregarClienteModelo
{
    private long ultimoDNIConsultado = -1;
    private readonly Dictionary<long, List<Guia>> guiasPorDNI = new();
    private static readonly string[] _talles = { "S", "M", "L", "XL", "XXL" };


    public List<Guia> Guias { get; set; }
    


    public bool BuscarEncomiendas(long dni)
    {
        if (dni < 1_0000_0000 || dni > 99_9999_9999)
        {
            MessageBox.Show("El DNI debe tener entre 8 y 10 dígitos.");
            return false;
        }

        ultimoDNIConsultado = dni;

        if (guiasPorDNI.ContainsKey(dni))
        {
            Guias = guiasPorDNI[dni];
            return true;
        }

        // Generar filas fake determinísticas por DNI
        var rng = new Random((int)dni);
        int cantidad = rng.Next(2, 5); // 2..4 filas

        var guias = new List<Guia>();
        for (int i = 0; i < cantidad; i++)
        {
            guias.Add(new()
            {
                NroGuia = $"#AG{rng.Next(1, 999):000}",
                Talle = _talles[rng.Next(_talles.Length)],
                DniDestinatario = dni,
                Fecha = FechaFake(rng),
                Cuit = CuitFake(rng)
            });
        }

        guiasPorDNI.Add(dni, guias);
        Guias = guias;
        return true;
    }

    public bool Entregar(List<Guia> seleccionadas)
    {
        foreach (var guia in seleccionadas)
        {
            guiasPorDNI[ultimoDNIConsultado].Remove(guia);
        }

        return true;
    }


    private static string CuitFake(Random r) => $"{r.Next(20, 28)}-{r.Next(10000000, 99999999)}-{r.Next(0, 9)}";
    private static DateTime FechaFake(Random r)
    {
        var d = new DateTime(r.Next(2022, 2026), r.Next(1, 13), r.Next(1, 28));
        return d;
    }
}
