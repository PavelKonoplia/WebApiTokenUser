using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.Interfaces;

namespace WebApiTokenUser.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext userDataContext;
        private DbSet<T> dbSet;

        public Repository(DbContext dataContext)
        {
            this.userDataContext = dataContext;
            this.dbSet = userDataContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.dbSet.AsNoTracking();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            this.dbSet.Add(entity);
            this.userDataContext.SaveChanges();
        }
    }
}