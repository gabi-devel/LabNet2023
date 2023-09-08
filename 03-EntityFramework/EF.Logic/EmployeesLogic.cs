using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace EF.Logic
{
    public class EmployeesLogic : AbstractClassLogic
    {
        public List<EmployeesDto> GetAll()
        {
            var employeesDto = context.Employees.Select(e => new EmployeesDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HireDate = e.HireDate,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country
            }).ToList();
            return employeesDto;
        }
    }
}
