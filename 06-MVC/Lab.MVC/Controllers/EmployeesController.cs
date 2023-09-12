using EF.Logic;
using EF.Logic.DTOs;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        readonly EmployeesLogic logic = new EmployeesLogic();

        // GET: Employees
        public ActionResult Index()
        {
            List<EmployeesDto> employeesAll = logic.GetAll();

            List<EmployeesView> emp = employeesAll.Select(e => new EmployeesView
            { // Toma los datos de Models/EmployeesView para poder leerlos en la Vista
                Id = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();
            return View(emp);
        }
        public ActionResult AddEmployee()
        {
            return View("Add");
        }

        // El nombre de la vista debe coincidir con el nombre del método en el controlador que la llama para no dar error.
        public ActionResult AddEmployee(EmployeesView employeeView)
        {
            try
            {
                EmployeesDto newEmployee = new EmployeesDto {
                    FirstName = employeeView.FirstName,
                    LastName = employeeView.LastName
                };
                logic.Add(newEmployee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult DeleteEmployee(int employeeId)
        { // poner try y catch
            logic.Delete(employeeId);
            return RedirectToAction("Index");
        }

        
        public ActionResult EditEmployee(int employeeId)
        { // Lee datos desde EmployeesDto y los mapea al modelo EmployeesView
            EmployeesDto getIdByLogic = logic.GetId(employeeId);

            EmployeesView dataModel = new EmployeesView
            {
                Id = employeeId,
                FirstName = getIdByLogic.FirstName,
                LastName = getIdByLogic.LastName
            };

            return View("edit", dataModel);
        }

        public ActionResult UpdateEmployee(EmployeesView eModel)
        { // Desde el modelo hacia el DTO
            EmployeesDto existEmployeeDTO = logic.GetId(eModel.Id);

            if (existEmployeeDTO.FirstName != eModel.FirstName) { existEmployeeDTO.FirstName = eModel.FirstName; }
            if (existEmployeeDTO.LastName != eModel.LastName) { existEmployeeDTO.LastName = eModel.LastName; }


            logic.Update(existEmployeeDTO);

            TempData["SweetAlertUpdated"] = "Su registro ha sido actualizado!";
            return RedirectToAction("Index");
        }
    }
}