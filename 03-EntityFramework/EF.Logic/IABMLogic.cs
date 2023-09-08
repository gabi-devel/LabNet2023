using System.Collections.Generic;

namespace EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T elementAdd);
        void Update(T elementUpdate);
        void Delete(int id);
    }
}
