using EF.Entities;
using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF.Logic
{
    public class EmployeesLogic : AbstractClassLogic, IABMLogic<EmployeesDto>
    {
        private DbSet<Employees> tableEmployees => context.Employees;
        

        public EmployeesDto GetId(int id)
        {
            var employeeById = tableEmployees.Select(e => new EmployeesDto {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).
                FirstOrDefault(e => e.EmployeeID == id);
            return employeeById;
        }
        public List<EmployeesDto> GetAll()
        {
            var employeesDto = tableEmployees.Select(e => new EmployeesDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList();
            return employeesDto;
        }

        public void Add(EmployeesDto elementAdd)
        {
            context.Employees.Add(new Employees
            {
                FirstName = elementAdd.FirstName,
                LastName = elementAdd.LastName
            });

            context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var findId = tableEmployees.FirstOrDefault(e => e.EmployeeID == employeeId);
            context.Employees.Remove(findId);
            context.SaveChanges();
        }

        public void Update(EmployeesDto elementUpdate)
        {
            //throw new System.NotImplementedException();
            var employeeToUpdate = tableEmployees.FirstOrDefault(e => e.EmployeeID == elementUpdate.EmployeeID);
            if (employeeToUpdate != null)
            {
                // Actualiza las propiedades del empleado con los valores de elementUpdate
                employeeToUpdate.FirstName = elementUpdate.FirstName;
                employeeToUpdate.LastName = elementUpdate.LastName;
                // Actualiza otros campos según sea necesario

                context.SaveChanges();
            }
            //else
            //{
            //    // Maneja el caso de empleado no encontrado según tu lógica
            //    throw new InvalidOperationException($"Empleado con ID {elementUpdate.EmployeeID} no encontrado.");
            //}
        }
    }
}
