using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    
        [Route("[controller]")]
        [ApiController]
        public class VendedorController : ControllerBase
        {

            private readonly IVendedor _vendedor;
            private ControlError log = new ControlError();
            public VendedorController(IVendedor vendedor)
            {
                this._vendedor = vendedor;
            }
            [HttpGet]
            [Route("GetVendedor")]
            public async Task<Respuesta> GetVendedor(string? opcion, string? data)
            {
                var result = new Respuesta();
                try
                {
                    result = await _vendedor.GetVendedor(opcion, data);
                }
                catch (Exception ex)
                {

                    log.LogErrorMetodos(this.GetType().Name, "GetVendedor", ex.Message);

                }
                return result;
            }
            [HttpPost]
            [Route("PostVendedor")]
            public async Task<Respuesta> PostVendedor([FromBody] Vendedor vendedor)
            {
                var result = new Respuesta();
                try
                {
                    result = await _vendedor.PostVendedor(vendedor);
                }
                catch (Exception ex)
                {

                    log.LogErrorMetodos(this.GetType().Name, "PostVendedor", ex.Message);
                }
                return result;
            }
            [HttpPut]
            [Route("PutVendedor")]
            public async Task<Respuesta> PutVendedor([FromBody] Vendedor vendedor)
            {
                var result = new Respuesta();
                try
                {
                    result = await _vendedor.PutVendedor(vendedor);
                }
                catch (Exception ex)
                {

                    log.LogErrorMetodos(this.GetType().Name, "PutVendedor", ex.Message);

                }
                return result;
            }
            [HttpPut]
            [Route("DeleteVendedor")]
            public async Task<Respuesta> DeleteVendedor(int id)
            {
                var result = new Respuesta();
                try
                {
                    result = await _vendedor.DeleteVendedor(id);
                }
                catch (Exception ex)
                {

                    log.LogErrorMetodos(this.GetType().Name, "DeleteVendedor", ex.Message);
                }
                return result;
            }
        }
    }
