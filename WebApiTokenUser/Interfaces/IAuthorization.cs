using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTokenUser.Interfaces
{
    public interface IAuthorization
    {
        string Authorize(string login, string password);
    }
}
