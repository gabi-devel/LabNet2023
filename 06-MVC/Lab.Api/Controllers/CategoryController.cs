using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.Api.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public async Task<ActionResult> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:44393/api/Categories";

                try
                {
                    HttpResponseMessage resp = await httpClient.GetAsync(url);

                    if (resp.IsSuccessStatusCode)
                    {
                        string content = await resp.Content.ReadAsStringAsync();

                        return View();
                    } else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
        }
    }
}