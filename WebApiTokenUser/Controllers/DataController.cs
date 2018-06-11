using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace WebApiTokenUser.Controllers
{
    public class DataController : ApiController
    {
        DataContext _dataContext;

        public DataController()
        {
            _dataContext = new DataContext();
        }

        public IEnumerable<Data> Get()
        {
            return _dataContext.Data;
        }

        public Data Get(int id)
        {
            return (Data)_dataContext.Data.Where(u => u.Id == id);
        }
    }
}