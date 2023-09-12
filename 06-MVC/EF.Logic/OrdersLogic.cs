using EF.Entities;
using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace EF.Logic
{
    public class OrdersLogic : AbstractClassLogic
    {
        public IEnumerable<OrdersDto> GetAll() 
        {
            IEnumerable<Orders> ord = context.Orders.AsEnumerable();

            IEnumerable<OrdersDto> oDTO = ord.Select(o => new OrdersDto
            {
                OrderID = o.OrderID,
                CustomerID = o.CustomerID,
                EmployeeID = o.EmployeeID,
                OrderDate = o.OrderDate,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            }).ToList();

            return oDTO;
        }
    }
}
