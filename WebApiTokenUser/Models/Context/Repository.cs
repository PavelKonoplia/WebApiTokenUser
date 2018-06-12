using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApiTokenUser.Interfaces;

namespace WebApiTokenUser.Models.Context
{
    public class UserDataContext : DbContext
    {
        public UserDataContext() : base("DbConnection") { }
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _userDataContext;
        DbSet<T> _dbSet;

        public Repository()
        {
            _userDataContext = new UserDataContext();
            _dbSet = _userDataContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            _userDataContext.SaveChanges();
        }
    }
}