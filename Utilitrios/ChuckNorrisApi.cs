using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitrios
{
    public class ChuckNorrisApi
    {
        private ControlError log = new ControlError();
        public async Task<Respuesta> GetChuckNorrisApi(string url)

        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Se consumio correcto";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("CuckNorrisApi", "GetChuckNorrisApi", ex.Message);
            }
            return respuesta;

        }
    }
}
