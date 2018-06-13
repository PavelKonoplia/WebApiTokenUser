using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.Interfaces;

namespace WebApiTokenUser.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _userDataContext;
        DbSet<T> _dbSet;

        public Repository(DbContext dataContext)
        {
            _userDataContext = dataContext;
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