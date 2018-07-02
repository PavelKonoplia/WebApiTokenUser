using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiTokenUser.BLL;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IdentityUserManager userManager;

        public UserController(IdentityUserManager _userManager)
        {
            userManager = _userManager;
        }
        
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        {
            return Ok(this.userManager.Users);
        }
        
        [HttpGet]
        [Route("api/user/{login}")]
        public async Task<IHttpActionResult> Get(string login)
        {
            var user = await this.userManager.FindByNameAsync(login);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [Authorize]
        public IHttpActionResult Authorize()
        {
            return Ok("Authorized");
        }

        [HttpPost]
        [Route("api/user")]
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            var userData = new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email == null ? $"{user.UserName} {user.Id}@gmail.com" : user.Email
            };

            IdentityResult addUserResult = await this.userManager.CreateAsync(userData, user.PasswordHash);

            if (!addUserResult.Succeeded)
            {
                return StatusCode(System.Net.HttpStatusCode.BadRequest);
            }

            return Created("api/user", user);
        }
    }
}