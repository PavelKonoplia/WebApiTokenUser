using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace WebApiTokenUser.Controllers
{
    public class DataController : ApiController
    {
        DataBaseContext _dbContext;

        public DataController()
        {
            _dbContext = new DataBaseContext();
        }

        public IEnumerable<Data> Get()
        {
            return _dbContext.Data;
        }

        public Data Get(int id)
        {
            return (Data)_dbContext.Data.Where(u => u.Id == id);
        }
    }
}