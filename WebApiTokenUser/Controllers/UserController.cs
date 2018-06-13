using BusinessLogic.Interfaces;
using System.Web.Http;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        IRepository<User> _userContext;

        public UserController(IRepository<User> userContext)
        {
            _userContext = userContext;
        }

        [Authorize]
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
            
            return Ok(_userContext.FindBy(u => u.Login == login));
        }

        [Authorize]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");
        }

        public void Post([FromBody]User user)
        {
            _userContext.Add(user);
        }
    }
}