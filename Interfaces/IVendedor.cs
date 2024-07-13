using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVendedor
    {
        Task<Respuesta> GetVendedor(string? opcion, string? data);
        Task<Respuesta> PostVendedor(Vendedor vendedor);
        Task<Respuesta> PutVendedor(Vendedor vendedor);
        Task<Respuesta> DeleteVendedor(int id);
    }
}
