using EjemploEntity2.DTO_s;
using EjemploEntity2.Interfaces;
using EjemploEntity2.Model;
using EjemploEntity2.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace EjemploEntity2.Services
{
    public class VentasServicio : IVentas
    {

        private readonly VentasContext _context;
        private ControlError log = new ControlError();

        public VentasServicio(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteID)
        {
            var respuesta = new Respuesta();
            try
            {
                {
                    respuesta.Cod = "000";
                    IQueryable<VentaDTO> query = (from v in _context.Ventas
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
                                                      ClienteId = v.ClienteId,
                                                      ClienteNombre = cl.ClienteNombre,
                                                      ProductoNombre = pr.ProductoDescrip,
                                                      ModeloNombre = mo.ModeloDescripción,
                                                      CategNombre = ct.CategNombre,
                                                      MarcaNombre = sc.MarcaNombre,
                                                      SucursalNombre = sc.SucursalNombre,
                                                      CajaNombre = ca.CajaDescripcion,
                                                      VendedorId = v.VendedorId,
                                                      VendedorNombre = ve.VendedorDescripcion,
                                                      Precio = v.Precio,
                                                      Unidades = v.Unidades,
                                                      Estado = v.Estado
                                                  });
                    if (!string.IsNullOrEmpty(numFactura) && numFactura != "0")
                    {
                        query = query.Where(n => n.NumFact == numFactura);
                    }


                    if (!string.IsNullOrEmpty(numFactura) && numFactura != "0" && precio != 0)
                    {
                        query = query.Where(n => n.NumFact == numFactura && n.Precio == precio);
                    }

                    if (precio != 0)
                    {
                        query = query.Where(n => n.Precio == precio);
                    }

                    if (vendedor != 0)
                    {
                        query = query.Where(n => n.VendedorId == vendedor);
                    }

                    if (clienteID != 0)
                    {
                        query = query.Where(n => n.ClienteId == clienteID);
                    }


                    respuesta.Data = await query.TolistAsync();
                    respuesta.Mensaje = "Ok";
                    log.LogErrorMetodos("GetVentas", "prueba");
                }
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó un error: {ee.Message}";
                log.LogErrorMetodos(respuesta.Mensaje, ee.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";

                respuesta.Data = await _context.Ventas
                    .Where(v => v.Precio > 100)
                    .GroupBy(v => v.Precio)
                    .Select(g => new
                    {
                        CantidadRegistro = g.Count(),
                        ValorConsultado = g.Key
                    }).ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return respuesta;
        }
        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura)
                    .FirstOrDefault();

                venta.IdFactura = Convert.ToInt32(query) + 1;

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "999";
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se ha generado una novedad , error {ex.Message}";
            }

            return respuesta;
        }
    }
}