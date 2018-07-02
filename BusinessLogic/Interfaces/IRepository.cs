using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T FindBy(Expression<Func<T, bool>> predicate);

        void Add(T item);
    }
}