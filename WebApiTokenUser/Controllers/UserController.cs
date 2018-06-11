using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTokenUser.Models;
using WebApiTokenUser.Models.Context;

namespace WebApiTokenUser.Controllers
{
    public class UserController : ApiController
    {
        UserContext _userContext;

        public UserController() {
            _userContext = new UserContext();
        }

        public IEnumerable<User> Get()
        {
            return _userContext.Users;
        }

        public User Get(string loggin)
        {
            
            return (User)_userContext.Users.Where(u => u.Loggin == loggin);
        }

        public void Post([FromBody]User user)
        {

            _userContext.Users.Add(user);
        }
        
        public void Delete(int id)
        {
            _userContext.Users.Remove((User)_userContext.Users.Where(u => u.Id == id));
        }
    }
}