using EF.Entities;
using EF.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF.Logic
{
    public class EmployeesLogic : AbstractClassLogic, IABMLogic<EmployeesDto>
    {
        private DbSet<Employees> TableEmployees => context.Employees;

        public EmployeesDto GetId(int id)
        {
            var employeeById = TableEmployees.Select(e => new EmployeesDto {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).FirstOrDefault(e => e.EmployeeID == id);

            return employeeById;
        }
        public List<EmployeesDto> GetAll()
        {
            var employeesDto = TableEmployees.Select(e => new EmployeesDto
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
            var findId = TableEmployees.FirstOrDefault(e => e.EmployeeID == employeeId);
            context.Employees.Remove(findId);
            context.SaveChanges();
        }

        public void Update(EmployeesDto elementUpdate)
        {
            var employeeToUpdate = TableEmployees.FirstOrDefault(e => e.EmployeeID == elementUpdate.EmployeeID);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = elementUpdate.FirstName;
                employeeToUpdate.LastName = elementUpdate.LastName;

                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"Empleado con ID {elementUpdate.EmployeeID} no encontrado.");
            }
        }
    }
}
