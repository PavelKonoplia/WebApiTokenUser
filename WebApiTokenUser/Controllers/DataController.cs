using BusinessLogic.Interfaces;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DataController : ApiController
    {

        IRepository<Data> dataProvider;

        public DataController(IRepository<Data> dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [Authorize]
        [HttpGet]
        [Route("api/data")]
        public IHttpActionResult Get()
        {
            return Ok(dataProvider.GetAll());
        }
        
        public IHttpActionResult Get(int id)
        {
            return Ok(dataProvider.FindBy(d => d.Id == id));
        }
    }
}