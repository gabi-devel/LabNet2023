using EF.Logic;
using EF.Logic.DTOs;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CustomersController : Controller
    {
        readonly CustomersLogic logic = new CustomersLogic();

        // GET: Customers
        public ActionResult Index()
        {
            List<CustomersDto> customer = logic.All();

            List<CustomerView> cust = customer.Select(c => new CustomerView
            { /*Toma los datos de Models/CustomerView para poder leerlos en la Vista*/ 
                Id = c.CustomerID,
                CompanyName = c.CompanyName,
            }).ToList();
            return View(cust);
        }
        public ActionResult AddCustomer()
        {
            return View("Add");
        }

        public ActionResult AddCustomer(CustomerView customerView)
        {
            try
            {
                CustomersDto newCustomer = new CustomersDto { CompanyName = customerView.CompanyName };
                logic.Add(newCustomer);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                //throw;
                //ModelState.AddModelError(string.Empty, "Error al agregar el cliente: " + ex.Message);
                //return View("Add", customerView);
                return RedirectToAction("Index", "Error");
            }
            
        }
        public ActionResult DeleteCustomer(string id)
        { // poner try y catch
            logic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}