using System;
using System.Linq;
using WebApiTokenUser.Interfaces;
using WebApiTokenUser.Models;

namespace WebApiTokenUser.Services
{
    public class Authorization: IAuthorization
    {
        IRepository<User> _userContext;

        public Authorization(IRepository<User> userContext)
        {
            _userContext = userContext;
        }

        public string Authorize(string login, string password)
        {
            if (_userContext.GetAll().Where(u => u.Login == login && u.Password == password) != null)
            {
                return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            }

            throw new AuthorizeException();
        }
    }
}