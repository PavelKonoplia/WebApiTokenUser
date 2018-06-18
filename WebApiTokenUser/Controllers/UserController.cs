using BusinessLogic.Interfaces;
using System.Web.Http;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{

    public class UserController : ApiController
    {
        IRepository<User> _userContext;

        public UserController(IRepository<User> userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        {
            return Ok(_userContext.GetAll());
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/{login}")]
        public IHttpActionResult Get(string login)
        {            
            return Ok(_userContext.FindBy(u => u.UserName == login));
        }

        [Authorize]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");
        }
        
        [HttpPost]
        [Route("api/user")]
        public void Post([FromBody]User user)
        {
            _userContext.Add(user);
        }
    }
}