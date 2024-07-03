using EjemploEntity2.Model;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity2.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetListaProductos(int productoID, float precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
    }
}

