using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {
        private ControlError log = new ControlError();
        private readonly IConfiguration _configuration;
        private PokeApi pokeApi = new PokeApi();
        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value!;
             
               respuesta.Cod = "000";
               respuesta.Data = await pokeApi.GetPokeApi(url);
               respuesta.Mensaje = "OK";
            }
            catch (Exception Ex)
            {

                log.LogErrorMetodos("ExtrasController", "GetPokeApi", Ex.Message);
            }
            return respuesta;
        }
    }
}


