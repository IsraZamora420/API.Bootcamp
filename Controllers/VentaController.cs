using EjemploEntity2.Interfaces;
using EjemploEntity2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteID)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVentas(numFactura, precio, vendedor, clienteID);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
        [HttpPut]
        [Route("")]
        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PostVentas(venta);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
