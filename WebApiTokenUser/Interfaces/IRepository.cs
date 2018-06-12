using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiTokenUser.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T item);
    }
}