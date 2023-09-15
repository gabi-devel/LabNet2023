using EF.Entities;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CategoriesMVC_ApiController : Controller
    {
        private readonly HttpClient client;
        public CategoriesMVC_ApiController()
        {
            client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44380/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
            //GET: CategoriesApi
        public async Task<List<CategoriesDto>> GetMyDatasAsync()
        {
                HttpResponseMessage response = await client.GetAsync("api/categories");

                if (response.IsSuccessStatusCode)
                {
                return await response.Content.ReadAsAsync<List<CategoriesDto>>();
                //var categories = await response.Content.<List<Categories>>();
                //return View(categories);
            }
            else
            {
                // Manejo de errores aquí
                throw new Exception("Error al obtener datos de la API");
            }
        }
          //  return View(new List<CategoriesDto>());
        //}
    }
}