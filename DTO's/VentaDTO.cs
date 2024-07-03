using EjemploEntity2.Model;

namespace EjemploEntity2.DTO_s
{
    public class VentaDTO
    {
        public double? IdFactura { get; set; }

        public string? NumFact { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? ClienteDetalle { get; set; }

        public string? ProductoDetalle { get; set; }

        public string ModeloDetalle { get; set; }

        public string? CategDetalle { get; set; }

        public string? MarcaDetalle { get; set; }

        public string? SucursalDetalle { get; set; }

        public string? Caja { get; set; }

        public string? Vendedor { get; set; }

        public double? Precio { get; set; }

        public double? Unidades { get; set; }

        public int? Estado { get; set; }

        public string? F15 { get; set; }

        public string? F16 { get; set; }

        public string? F17 { get; set; }

        public string? F18 { get; set; }

        public string? F19 { get; set; }

        public string? F20 { get; set; }

        public string? F21 { get; set; }

        public string? F22 { get; set; }

        public string? F23 { get; set; }

        public string? F24 { get; set; }

        public string? F25 { get; set; }

        public string? F26 { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
