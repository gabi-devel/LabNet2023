using Linq.Entities;
using System.Collections.Generic;

namespace Linq.Logic
{
    public class ProductsLogic : BaseLogic, ILogic<Products>
    {
        public IEnumerable<Products> GetAll()
        {
            return context.Products;
        }
    }
}
