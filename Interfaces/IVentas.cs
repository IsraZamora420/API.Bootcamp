using EjemploEntity2.Model;
using System.Threading.Tasks;

namespace EjemploEntity2.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId);
        Task<Respuesta> PostVentas(Venta venta);
        Task<Respuesta> GetVentaReporte();

    }
}
