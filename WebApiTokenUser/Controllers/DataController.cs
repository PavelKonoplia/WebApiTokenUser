using System.Web.Http;
using WebApiTokenUser.BLL;

namespace WebApiTokenUser.Controllers
{
    public class DataController : ApiController
    {
        DataProvider dataProvider;

        public DataController(DataProvider dataProvider)
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
            return Ok(dataProvider.GetBy(d => d.Id == id));
        }
    }
}