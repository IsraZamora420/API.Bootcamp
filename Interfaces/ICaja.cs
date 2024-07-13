using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICaja
    {
        Task<Respuesta> GetCaja(string? opcion, string? data);
        Task<Respuesta> PostCaja(Caja caja);
        Task<Respuesta> PutCaja(Caja caja);
        Task<Respuesta> DeleteCaja(int id);
    }
}