using Linq.Entities;
using System.Collections.Generic;

namespace Linq.Logic
{
    public class CustomersLogic : BaseLogic, ILogic<Customers>
    {
        public IEnumerable<Customers> GetAll()
        {
            return context.Customers;
        }
    }
}
