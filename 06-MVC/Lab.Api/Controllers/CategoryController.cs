using Lab.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.Api.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient httpClient;

        public CategoryController()
        {
            httpClient = new HttpClient();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                string url = "https://localhost:44393/api/CategoriesApi";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                string contenido = await response.Content.ReadAsStringAsync();
                List<CategoryApiModel> listaModelo = JsonConvert.DeserializeObject<List<CategoryApiModel>>(contenido);

                return View(listaModelo);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error catch " + ex.Message;
                return View("index");
            }
        }
    }
}