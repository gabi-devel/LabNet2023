using Linq.Entities;
using System.Collections.Generic;

namespace Linq.Logic
{
    public class OrdersLogic : BaseLogic, ILogic<Orders>
    {
        public IEnumerable<Orders> GetAll()
        {
            return context.Orders;
        }
    }
}
