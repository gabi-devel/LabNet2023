using EF.Entities;
using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace EF.Logic
{
    public class CustomersLogic : AbstractClassLogic
    {
        public void Add(CustomersDto elementAdd)
        {
            context.Customers.Add(new Customers
            {
                CustomerID = elementAdd.CustomerID,
                CompanyName = elementAdd.CompanyName
            });

            context.SaveChanges();
        }

        public List<CustomersDto> All()
        {

            var customersDto = context.Customers.Select(c => new CustomersDto
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                Country = c.Country,
                Phone = c.Phone
            }).ToList();
            return customersDto;
        }

        public void Delete(string id)
        {
            var findId = context.Customers.FirstOrDefault(c => c.CustomerID == id);
            context.Customers.Remove(findId);
            context.SaveChanges();
        }

        public void Update(Customers elementUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
