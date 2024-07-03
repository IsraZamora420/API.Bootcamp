using EjemploEntity2.DTO_s;
using EjemploEntity2.Interfaces;
using EjemploEntity2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using System.Threading.RateLimiting;

namespace EjemploEntity2.Services
{
    public class VentasServicio : IVentas
    {

        private readonly VentasContext _context;

        public VentasServicio(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVentas(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {

                if (numFactura != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                           join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                           join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                           join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                           join ct in _context.Categoria on v.CategId equals ct.CategId
                                           join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                           join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                           join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                           where v.IdFactura.Equals(numFactura)
                                           select new VentaDTO
                                           {
                                               IdFactura = v.IdFactura,
                                               NumFact = v.NumFact,
                                               FechaHora = v.FechaHora,
                                               ClienteDetalle = cl.ClienteNombre,
                                               ProductoDetalle = pr.ProductoDescrip,
                                               ModeloDetalle = mo.ModeloDescripción,
                                               CategDetalle = ct.CategNombre,
                                               SucursalDetalle = sc.SucursalNombre,
                                               Caja = ca.CajaDescripcion,
                                               Vendedor = ve.VendedorDescripcion,
                                               Precio = v.Precio,
                                               Unidades = v.Unidades,
                                               Estado = v.Estado
                                           }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            where v.Estado == 2
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Cod = "OK";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
