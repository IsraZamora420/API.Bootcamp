using EjemploEntity2.DTO_s;
using EjemploEntity2.Interfaces;
using EjemploEntity2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EjemploEntity2.Services
{
    public class ProductoServices : IProducto
    {
        private readonly VentasContext _context;

        public ProductoServices(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new Respuesta();
            try
            {
                if (productoID == 0 && precio == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A")
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";

                }
                else if (productoID != 0 && precio == 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Estado.Equals("A")).ToListAsync();
                }
                else if (precio != 0 && productoID == 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
                else if (productoID != 0 && precio != 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefault();

                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;


                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento une erro: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            bool valida = false;
            try
            {

                valida = await _context.Categoria.Where(x => x.CategId.Equals(producto.CategId)).AnyAsync();

                if (valida)
                {
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actuaizo correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = $"No Existe categoria";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento une erro: {ex.Message}";
            }
            return respuesta;
        }
    }
}
