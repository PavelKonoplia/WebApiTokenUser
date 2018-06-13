using System;
using BusinessLogic.Interfaces;
using WebApiTokenUser.Entity.Models;

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
            if (_userContext.FindBy(u => u.Login == login && u.Password == password) != null)
            {
                return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            }

            throw new AuthorizeException();
        }
    }
}