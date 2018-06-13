using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTokenUser.Interfaces;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace WebApiTokenUser.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        IRepository<User> _userContext;

        public UserController() {
            _userContext = new Repository<User>();
        }

        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        {
            return Ok(_userContext.GetAll());
        }

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