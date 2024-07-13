using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly ICaja _caja;
        private ControlError log = new ControlError();
        public CajaController(ICaja caja)
        {
            this._caja = caja;
        }
        [HttpGet]
        [Route("GetCaja")]
        public async Task<Respuesta> GetCaja(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result = await _caja.GetCaja(opcion, data);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "GetCaja", ex.Message);

            }
            return result;
        }
        [HttpPost]
        [Route("PostCaja")]
        public async Task<Respuesta> PostVendedor([FromBody] Caja caja)
        {
            var result = new Respuesta();
            try
            {
                result = await _caja.PostCaja(caja);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "PostCaja", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutCaja")]
        public async Task<Respuesta> PutCaja([FromBody] Caja caja)
        {
            var result = new Respuesta();
            try
            {
                result = await _caja.PutCaja(caja);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "PutCaja", ex.Message);

            }
            return result;
        }
        [HttpPut]
        [Route("DeleteCaja")]
        public async Task<Respuesta> DeleteVendedor(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _caja.DeleteCaja(id);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "DeleteCaja", ex.Message);
            }
            return result;
        }
    }
}

