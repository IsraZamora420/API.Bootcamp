﻿using EjemploEntity2.Model;
using System.Threading.Tasks;

namespace EjemploEntity2.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> GetMarca();
        Task<Respuesta> GetModelo();
        Task<Respuesta> GetSucursal();
    }
}
