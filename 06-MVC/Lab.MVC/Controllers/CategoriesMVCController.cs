using EF.Logic;
using EF.Logic.DTOs;
using Lab.MVC.Models;
using System;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
<<<<<<< HEAD:06-MVC/Lab.MVC/Controllers/CategoriesController.cs
    public class Cat_Controller : Controller
=======
    public class CategoriesMVCController : Controller
>>>>>>> labNetPractica7:06-MVC/Lab.MVC/Controllers/CategoriesMVCController.cs
    {
        private readonly CategoriesLogic logic = new CategoriesLogic();

        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }
    
        public ActionResult Add(CategoriesModel cModel)
        {
            try
            {
                CategoriesDto newC = new CategoriesDto
                {
                    CategoryID = cModel.Id,
                    CategoryName = cModel.CategoryName,
                    Description = cModel.Description
                };
                logic.Add(newC);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}