using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTokenUser.Services
{
    public class AuthorizeException: Exception
    {
        public AuthorizeException() : base("Invalid login or password") { }
    }
}