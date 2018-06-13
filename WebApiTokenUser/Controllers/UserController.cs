using BusinessLogic.Interfaces;
using DataAccess.Models;
using System.Web.Http;

namespace WebApiTokenUser.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        IRepository<User> _userContext;

        public UserController() {
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