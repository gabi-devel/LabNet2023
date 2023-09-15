using Lab.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class MostrarController : Controller
    {
        private readonly HttpClient httpClient;
        public MostrarController()
        {
            httpClient = new HttpClient();
            // Configura aquí cualquier configuración adicional, como encabezados
        }

        // GET: Mostrar
        public async Task<ActionResult> Index()
        {   
            try
            {
                //string url = "https://jsonplaceholder.typicode.com/todos/1";
                string url = "https://jsonplaceholder.typicode.com/todos";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    //MostrarModel modelo = JsonConvert.DeserializeObject<MostrarModel>(contenido);
                    List<MostrarModel> listaModelos = JsonConvert.DeserializeObject<List<MostrarModel>>(contenido);

                    //return View("index", modelo);
                    return View(listaModelos);
                }
                else
                {
                    ViewBag.Error = "Error "+response.StatusCode;
                    return View("index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error catch " + ex.Message;
                return View("index");
            }
        }
    }
}