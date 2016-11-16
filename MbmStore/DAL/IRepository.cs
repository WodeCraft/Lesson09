using System.Collections.Generic;

namespace MbmStore.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
        T GetById(int id);
        void SaveItem(T item);
        T DeleteItem(int id);

    }
}
