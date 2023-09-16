using Lab.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.Api.Controllers
{
    public class JPHController : Controller
    {
        private readonly HttpClient httpClient;
        public JPHController()
        {
            httpClient = new HttpClient();
        }
        
        public async Task<ActionResult> Index()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string contenido = await response.Content.ReadAsStringAsync();
                    List<JPHModel> listaModelo = JsonConvert.DeserializeObject<List<JPHModel>>(contenido);

                    return View(listaModelo);
                }
                else
                {
                    ViewBag.Error = "Error " + response.StatusCode;
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