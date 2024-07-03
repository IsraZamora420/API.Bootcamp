using EjemploEntity2.Model;

namespace EjemploEntity2.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVentas(string? numFactura);
    }
}
