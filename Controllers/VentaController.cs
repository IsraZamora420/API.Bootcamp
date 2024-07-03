using EjemploEntity2.Interfaces;
using EjemploEntity2.Model;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity2.Controllers
{
    [ApiController]
    [Route ("[Controller]")]
    public class VentaController : Controller
    {
        private readonly IVentas _venta;
        public VentaController(IVentas venta)
        {
            this._venta = venta;
        }

        [HttpGet]
        [Route ("GetVentas")]
        public async Task<Respuesta> GetVentas(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVentas(numFactura);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
