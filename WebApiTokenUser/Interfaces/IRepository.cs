using System.Collections.Generic;

namespace WebApiTokenUser.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems();

        T GetItemById(int itemId);

        int Create(T item);

        void Update(T item);

        void Delete(int itemId);
    }
}