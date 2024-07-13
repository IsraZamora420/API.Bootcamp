//using EjemploEntity.DTOs;
//using EjemploEntity.Interfaces;
//using EjemploEntity.Models;
//using EjemploEntity.Utilitrios;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Linq.Expressions;

//namespace EjemploEntity.Services
//{
//    public class CajaService : ICaja, IRepository<Caja>
//    {
//        private VentasContext _context;
//        private ControlError log = new ControlError();
//        public CajaService(VentasContext context)
//        {
//            this._context = context;
//        }
//        public async Task<Respuesta> DeleteCaja(int id)
//        {
//            var result = new Respuesta();
//            var cajaDelete = new Caja();
//            bool validar = false;
//            try
//            {
//                validar = await _context.Cajas.Where((x) => x.CajaId == id).AnyAsync();
//                if (validar)
//                {
//                    cajaDelete = await _context.Cajas.Where((x) => x.CajaId == id).FirstOrDefaultAsync();
//                    cajaDelete.EstadoId = 2;
//                    _context.Cajas.Update(cajaDelete);
//                    await _context.SaveChangesAsync();
//                    result.Cod = "000";
//                    result.Mensaje = "OK";
//                }
//                else
//                {
//                    result.Cod = "111";
//                    result.Mensaje = $"Ninguna caja se encontro con la id: '{id}'";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "DeleteCaja", ex.Message);

//            }
//            return result;
//        }

//        public async Task<Respuesta> GetCaja(string? opcion, string? data)
//        {
//            var result = new Respuesta();
//            Expression<Func<CajaDto, bool>> nulls;

//            try
//            {
//                result.Cod = "000";
//                result.Mensaje = "OK";
//                IQueryable<CajaDto> query = (from c in _context.Cajas
//                                             join e in _context.Estados on c.EstadoId equals e.EstadoId
//                                             select new CajaDto
//                                             {
//                                                 CajaId = c.CajaId,
//                                                 CajaDescripcion = c.CajaDescripcion,
//                                                 FechaHoraReg = c.FechaHoraReg,
//                                                 EstadoId = c.EstadoId,
//                                                 EstadoDescrip = e.EstadoDescripcion
//                                             });
//                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty()))
//                {
//                    nulls = Caja.DictionaryCaja(opcion, data);
//                    if (nulls != null)
//                    {
//                        result.Data = await query.Where(nulls).ToListAsync();
//                    }

//                }
//                else
//                {
//                    result.Data= await query.Where((x) => x.EstadoId == 1).ToListAsync();
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
//                log.LogErrorMetodos(this.GetType().Name, "GetCaja", ex.Message);

//            }
//            return result;
//        }

//        public async Task<Respuesta> PostCaja(Caja caja)
//        {
//            var result = new Respuesta();
//            try
//            {
//                var query = await _context.Cajas.OrderByDescending((x) => x.CajaId).Select((x) => x.CajaId).FirstOrDefaultAsync() + 1;
//                caja.CajaId = query;
//                caja.FechaHoraReg = DateTime.Now;
//                _context.Cajas.Add(caja);
//                await _context.SaveChangesAsync();
//                result.Cod = "000";
//                result.Mensaje = "OK";
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "PostCaja", ex.Message);

//            }
//            return result;
//        }

//        public async Task<Respuesta> PutCaja(Caja caja)
//        {
//            var result = new Respuesta();
//            bool validar = false;
//            try
//            {
//                validar = await _context.Cajas.Where((x) => x.CajaId == caja.CajaId).AnyAsync();
//                if (validar)
//                {
//                    result.Cod = "000";
//                    result.Mensaje = "OK";
//                    _context.Cajas.Update(caja);
//                    await _context.SaveChangesAsync();
//                }
//                else
//                {
//                    result.Cod = "111";
//                    result.Mensaje = $"Ninguna caja se encontro con la id: '{caja.CajaId}'";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.Cod = "999";
//                result.Mensaje = $"Exception: {ex.Message}";
//                log.LogErrorMetodos(this.GetType().Name, "PutCaja", ex.Message);

//            }
//            return result;
//        }
//    }
//}