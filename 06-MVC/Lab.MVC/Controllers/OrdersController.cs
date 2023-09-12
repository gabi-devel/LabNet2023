using EF.Logic;
using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            OrdersLogic logic = new OrdersLogic();
            List<OrdersDto> ordenes = logic.GetAll();
            return View(ordenes);
        }


    }
}