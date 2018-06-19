using BusinessLogic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTokenUser.BLL;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Controllers
{

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

           // return Ok(_userContext.GetAll());
        }

        [Authorize]
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
        /*
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login([FromBody]User inputUser)
        {
            User user = await UserManager.FindAsync(inputUser.UserName, inputUser.PasswordHash);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ExternalBearer);
                return Ok("Success");
            }

            return Ok(ModelState);
        }*/

        [HttpPost]
        [Route("api/user")]
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            var userData = new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email == null ? "default@gmail.com" : user.Email
            };

            IdentityResult addUserResult = await this.userManager.CreateAsync(userData, user.PasswordHash);

            if (!addUserResult.Succeeded)
            {
                return StatusCode(System.Net.HttpStatusCode.BadRequest);
            }

            return Created("api/user", user);
            
            //_userContext.Add(user);
        }
    }
}