using Linq.Entities;
using System.Collections.Generic;

namespace Linq.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public IEnumerable<Categories> GetAll()
        {
            return context.Categories;
        }
    }
}
