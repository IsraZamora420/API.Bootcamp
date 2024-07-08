using EjemploEntity2.Model;
using System;

namespace EjemploEntity2.DTO_s
{
    public class VentaDTO
    {

        public double IdFactura { get; set; }

        public string? NumFact { get; set; }

        public DateTime? FechaHora { get; set; }

        public double? ClienteId { get; set; }
        public string? ClienteNombre { get; set; }

        public string? ProductoNombre { get; set; }

        public string? ModeloNombre { get; set; }

        public string? CategNombre { get; set; }

        public string? MarcaNombre { get; set; }

        public string? SucursalNombre { get; set; }

        public string? CajaNombre { get; set; }
        public double? VendedorId { get; set; }

        public string? VendedorNombre { get; set; }

        public double? Precio { get; set; }

        public double? Unidades { get; set; }

        public int? Estado { get; set; }
    }
}

 