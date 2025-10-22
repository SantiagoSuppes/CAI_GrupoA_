// Archivo: GuiaEstadoHistorial/GuiaEstadoHistorialModelo.cs
using System;
using System.Collections.Generic;
using CAI_GrupoA_.Entidades;

namespace CAI_GrupoA_.GuiaEstadoHistorial
{
    // Resultado para la UI: contiene la guía real y sus movimientos reales
    public class GuiaDetalleResultado
    {
        public GuiaEnt Guia;                           // entidad real
        public List<MovimientoGuiaEnt> Movimientos;   // entidades reales

        // Derivados para mostrar
        public string Numero;
        public string Cliente;
        public string EstadoActualTexto;
        public DateTime? FechaUltimoMov;
        public string TipoCajaTexto;
        public string ModalidadTexto;
        public string DestinoFinalTexto;
    }

    public class GuiaEstadoHistorialModelo
    {
        // ------- Datos de prueba con ENTIDADES reales -------
        private readonly List<GuiaEnt> _guias = new List<GuiaEnt>();
        private readonly Dictionary<string, List<MovimientoGuiaEnt>> _movsPorGuia =
            new Dictionary<string, List<MovimientoGuiaEnt>>();
        private readonly Dictionary<string, string> _clientePorGuia =
            new Dictionary<string, string>();

        public GuiaEstadoHistorialModelo()
        {
            // ===== Guía 1 — Rosario (Santa Fe) → Córdoba (Córdoba)
            var g1 = new GuiaEnt
            {
                NumeroGuia = "AGC01-0001",
                FechaImposicion = DateTime.Today.AddDays(-7).AddHours(9),
                EstadoActual = EstadoActualEnum.EnDistribucion,     // coincide con el último movimiento
                TamañoCaja = TamañoCajaEnum.M,
                Origen = new DireccionEnt { Localidad = "Rosario", Provincia = ProvinciaEnum.SantaFe, TipoPunto = TipoPuntoEnum.CD },
                Destino = new DireccionEnt { Localidad = "Córdoba", Provincia = ProvinciaEnum.Cordoba, TipoPunto = TipoPuntoEnum.Domicilio },
                HojaDeRuta = null
            };
            _guias.Add(g1);
            _clientePorGuia[g1.NumeroGuia] = "Transporte TUTASA S.A.";
            _movsPorGuia[g1.NumeroGuia] = new List<MovimientoGuiaEnt>
    {
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-6).AddHours(8),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_EnEsperaDeViaje,
            Origen  = new DireccionEnt{ Localidad="Rosario", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.CD },
            Guia = g1
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-5).AddHours(18),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="Rosario", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.CD },
            Guia = g1
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-4).AddHours(10),
            TipoTramo = TipoTramoEnum.UltimaMilla,
            Estado = EstadoActualEnum.EnAgencia_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.Agencia },
            Guia = g1
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-3).AddHours(14),
            TipoTramo = TipoTramoEnum.UltimaMilla,
            Estado = EstadoActualEnum.EnDistribucion,
            Origen  = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.Agencia },
            Destino = new DireccionEnt{ Localidad="Córdoba", Provincia=ProvinciaEnum.Cordoba, TipoPunto=TipoPuntoEnum.Domicilio },
            Guia = g1
        }
    };

            // ===== Guía 2 — San Martín (Buenos Aires) → Calchaquí (Santa Fe)
            var g2 = new GuiaEnt
            {
                NumeroGuia = "AGC05-0005",
                FechaImposicion = DateTime.Today.AddDays(-9).AddHours(11),
                EstadoActual = EstadoActualEnum.Entregada,          // coincide con el último movimiento
                TamañoCaja = TamañoCajaEnum.S,
                Origen = new DireccionEnt { Localidad = "San Martín", Provincia = ProvinciaEnum.BuenosAires, TipoPunto = TipoPuntoEnum.CD },
                Destino = new DireccionEnt { Localidad = "Calchaquí", Provincia = ProvinciaEnum.SantaFe, TipoPunto = TipoPuntoEnum.Domicilio },
                HojaDeRuta = null
            };
            _guias.Add(g2);
            _clientePorGuia[g2.NumeroGuia] = "Logística Andina SRL";
            _movsPorGuia[g2.NumeroGuia] = new List<MovimientoGuiaEnt>
    {
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-8).AddHours(7),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_EnEsperaDeViaje,
            Origen  = new DireccionEnt{ Localidad="San Martín", Provincia=ProvinciaEnum.BuenosAires, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Rosario", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Guia = g2
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-7).AddHours(20),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="San Martín", Provincia=ProvinciaEnum.BuenosAires, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Rosario", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Guia = g2
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-6).AddHours(9),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="Rosario", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Reconquista", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Guia = g2
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-5).AddHours(17),
            TipoTramo = TipoTramoEnum.UltimaMilla,
            Estado = EstadoActualEnum.EnDistribucion,
            Origen  = new DireccionEnt{ Localidad="Reconquista", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Calchaquí", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.Domicilio },
            Guia = g2
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-5).AddHours(20),
            TipoTramo = TipoTramoEnum.UltimaMilla,
            Estado = EstadoActualEnum.Entregada,
            Origen  = new DireccionEnt{ Localidad="Calchaquí", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.Domicilio },
            Destino = new DireccionEnt{ Localidad="Calchaquí", Provincia=ProvinciaEnum.SantaFe, TipoPunto=TipoPuntoEnum.Domicilio },
            Guia = g2
        }
    };

            // ===== Guía 3 — Mendoza (Mendoza) → Villa Mercedes (San Luis)
            var g3 = new GuiaEnt
            {
                NumeroGuia = "MZA01-0010",
                FechaImposicion = DateTime.Today.AddDays(-6).AddHours(10),
                EstadoActual = EstadoActualEnum.EnAgencia_ListaParaEntregar, // coincide con el último movimiento
                TamañoCaja = TamañoCajaEnum.L,
                Origen = new DireccionEnt { Localidad = "Mendoza", Provincia = ProvinciaEnum.Mendoza, TipoPunto = TipoPuntoEnum.CD },
                Destino = new DireccionEnt { Localidad = "Villa Mercedes", Provincia = ProvinciaEnum.SanLuis, TipoPunto = TipoPuntoEnum.Agencia },
                HojaDeRuta = null
            };
            _guias.Add(g3);
            _clientePorGuia[g3.NumeroGuia] = "Andes Cargo SA";
            _movsPorGuia[g3.NumeroGuia] = new List<MovimientoGuiaEnt>
    {
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-6).AddHours(16),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_EnEsperaDeViaje,
            Origen  = new DireccionEnt{ Localidad="Mendoza", Provincia=ProvinciaEnum.Mendoza, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="San Luis", Provincia=ProvinciaEnum.SanLuis, TipoPunto=TipoPuntoEnum.CD },
            Guia = g3
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-5).AddHours(12),
            TipoTramo = TipoTramoEnum.LargaDistancia,
            Estado = EstadoActualEnum.EnCD_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="Mendoza", Provincia=ProvinciaEnum.Mendoza, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="San Luis", Provincia=ProvinciaEnum.SanLuis, TipoPunto=TipoPuntoEnum.CD },
            Guia = g3
        },
        new MovimientoGuiaEnt {
            Fecha = DateTime.Today.AddDays(-4).AddHours(15),
            TipoTramo = TipoTramoEnum.UltimaMilla,
            Estado = EstadoActualEnum.EnAgencia_ListaParaEntregar,
            Origen  = new DireccionEnt{ Localidad="San Luis", Provincia=ProvinciaEnum.SanLuis, TipoPunto=TipoPuntoEnum.CD },
            Destino = new DireccionEnt{ Localidad="Villa Mercedes", Provincia=ProvinciaEnum.SanLuis, TipoPunto=TipoPuntoEnum.Agencia },
            Guia = g3
        }
    };
        }

        // Búsqueda por número de guía
        public GuiaDetalleResultado BuscarPorNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero)) return null;

            GuiaEnt guia = null;
            for (int i = 0; i < _guias.Count; i++)
                if (string.Equals(_guias[i].NumeroGuia, numero.Trim(), StringComparison.OrdinalIgnoreCase))
                { guia = _guias[i]; break; }

            if (guia == null) return null;

            List<MovimientoGuiaEnt> lista;
            if (!_movsPorGuia.TryGetValue(guia.NumeroGuia, out lista)) lista = new List<MovimientoGuiaEnt>();

            // ordenar por fecha ascendente
            lista.Sort((a, b) => a.Fecha.CompareTo(b.Fecha));

            DateTime? ultimo = null;
            for (int i = 0; i < lista.Count; i++)
                if (ultimo == null || lista[i].Fecha > ultimo.Value) ultimo = lista[i].Fecha;

            var res = new GuiaDetalleResultado();
            res.Guia = guia;
            res.Movimientos = lista;
            res.Numero = guia.NumeroGuia;
            res.Cliente = _clientePorGuia.ContainsKey(guia.NumeroGuia) ? _clientePorGuia[guia.NumeroGuia] : "";
            res.EstadoActualTexto = guia.EstadoActual.ToString();
            res.FechaUltimoMov = ultimo;
            res.TipoCajaTexto = guia.TamañoCaja.ToString();
            res.ModalidadTexto = guia.Destino != null ? guia.Destino.TipoPunto.ToString() : "";
            res.DestinoFinalTexto = guia.Destino != null ? guia.Destino.Localidad : "";

            return res;
        }
    }
}
