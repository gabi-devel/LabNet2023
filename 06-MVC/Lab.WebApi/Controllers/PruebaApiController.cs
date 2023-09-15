using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{
    public class PruebaApiController : ApiController
    {
        private readonly HttpClient httpClient;
        public PruebaApiController()
        {
            httpClient = new HttpClient();
            // Configura aquí cualquier configuración adicional, como encabezados
        }

        public async Task<IHttpActionResult> GetAllApi()
        {
            string uri = "http://jsonplaceholder.typicode.com/posts/1";

            try
            {
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(content);
                    return Ok(data);
                }
                else
                {
                    return BadRequest($"Error al realizar la solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
} 
