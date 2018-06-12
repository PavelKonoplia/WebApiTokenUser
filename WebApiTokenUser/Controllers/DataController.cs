using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace WebApiTokenUser.Controllers
{
    public class DataController : ApiController
    {
        DatabaseContext _dbContext;

        public DataController()
        {
            _dbContext = new DatabaseContext();
        }

        [HttpGet]
        [Route("api/data")]
        public IHttpActionResult Get()
        {
            return Ok(_dbContext.Data);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_dbContext.Data.Where(u => u.Id == id));
        }
    }
}