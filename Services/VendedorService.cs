//using EjemploEntity.DTOs;
//using EjemploEntity.Models;
//using EjemploEntity.Utilitrios;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Linq.Expressions;

//namespace EjemploEntity.Services
//{
//    public class VendedorService
//    {
//        private VentasContext _context;
//        private ControlError log = new ControlError();
//        public VendedorService(VentasContext context)
//        {
//            this._context = context;
//        }
//        public async Task<Respuesta> DeleteVendedor(int id)
//        {
//            var result = new Respuesta();
//            var vendedorDelete = new Vendedor();
//            bool validar = false;
//            try
//            {
//                validar = await _context.Vendedors.Where((x) => x.VendedorId == id).AnyAsync();
//                if (validar)
//                {
//                    vendedorDelete = await _context.Vendedors.Where((x) => x.VendedorId == id).FirstOrDefaultAsync();
//                    vendedorDelete.EstadoId = 2;
//                    _context.Vendedors.Update(vendedorDelete);
//                    await _context.SaveChangesAsync();
//                    result.Cod = "000";
//                    result.Mensaje = "OK";
//                }
//                else
//                {
//                    result.Cod = "111";
//                    result.Mensaje = $"Ninguna vendedor se encontro con la id: '{id}'";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "DeleteVendedor", ex.Message);

//            }
//            return result;
//        }

//        public async Task<Respuesta> GetVendedor(string? opcion, string? data)
//        {
//            var result = new Respuesta();
//            Expression<Func<VendedorDto, bool>> nulls;

//            try
//            {
//                result.Cod = "000";
//                result.Mensaje = "OK";
//                IQueryable<VendedorDto> query = (from v in _context.Vendedors
//                                                 join e in _context.Estados on v.EstadoId equals e.EstadoId
//                                                 select new VendedorDto
//                                                 {
//                                                     VendedorId = v.VendedorId,
//                                                     VendedorDescripcion = v.VendedorDescripcion,
//                                                     FechaHoraReg = v.FechaHoraReg,
//                                                     EstadoId = v.EstadoId,
//                                                     EstadoDescrip = e.EstadoDescripcion
//                                                 });
//                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty()))
//                {
//                    nulls = Vendedor.DictionaryVendedor(opcion, data);
//                    if (nulls != null)
//                    {
//                        result.Data = await query.Where(nulls).ToListAsync();
//                    }

//                }
//                else
//                {
//                    result.Data = await query.Where((x) => x.EstadoId == 1).ToListAsync();
//                }

//                if (DynamicEmpty.IsDynamicEmpty(result.Data))
//                {
//                    result.Cod = "111";
//                    result.Mensaje = $"No se encontro registro de '{opcion}' con similitud a '{data}'";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "GetVendedor", ex.Message);

//            }
//            return result;
//        }

//        public async Task<Respuesta> PostVendedor(Vendedor vendedor)
//        {
//            var result = new Respuesta();
//            try
//            {
//                var query = await _context.Vendedors.OrderByDescending((x) => x.VendedorId).Select((x) => x.VendedorId).FirstOrDefaultAsync() + 1;
//                vendedor.VendedorId = query;
//                vendedor.FechaHoraReg = DateTime.Now;
//                _context.Vendedors.Add(vendedor);
//                await _context.SaveChangesAsync();
//                result.Cod = "000";
//                result.Mensaje = "OK";
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "PostVendedor", ex.Message);

//            }
//            return result;
//        }
                  
//        public async Task<Respuesta> PutVendedor(Vendedor vendedor)
//        {
//            var result = new Respuesta();
//            bool validar = false;
//            try
//            {
//                validar = await _context.Vendedors.Where((x) => x.VendedorId == vendedor.VendedorId).AnyAsync();
//                if (validar)
//                {
//                    result.Cod = "000";
//                    result.Mensaje = "OK";
//                    _context.Vendedors.Update(vendedor);
//                    await _context.SaveChangesAsync();
//                }
//                else
//                {
//                    result.Cod = "111";
//                    result.Mensaje = $"Ninguna vendedor se encontro con la id: '{vendedor.VendedorId}'";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "PutVendedor", ex.Message);

//            }
//            return result;
//        }
//    }
//}