using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Logic
{
    public interface ILogic<T>
    {
        IEnumerable<T> GetAll();
    }
}
