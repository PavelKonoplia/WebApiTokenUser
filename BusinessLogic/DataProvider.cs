using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLogic.Interfaces;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.BLL
{
    public class DataProvider
    {
        IRepository<Data> repository;

        public DataProvider(IRepository<Data> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Data> GetAll()
        {
            return this.repository.GetAll() as IEnumerable<Data>;
        }

        public Data GetBy(Expression<Func<Data, bool>> predicate)
        {
            return this.repository.FindBy(predicate) as Data;
        }

        public void Add(Data data)
        {
            this.repository.Add(data);
        }
    }
}
