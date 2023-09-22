using EF.Data;

namespace EF.Logic
{
    public abstract class AbstractClassLogic
    {
        protected readonly NorthwindContext context;

        public AbstractClassLogic()
        {
            context = new NorthwindContext();
        }
    }
}
