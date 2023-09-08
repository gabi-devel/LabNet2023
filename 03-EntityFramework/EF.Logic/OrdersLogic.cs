using EF.Logic.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace EF.Logic
{
    public class OrdersLogic : AbstractClassLogic
    {
        public List<OrdersDto> GetAll()
        {
            var ordersDto = context.Orders.Select(o => new OrdersDto
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
            return ordersDto;
        }
    }
}
