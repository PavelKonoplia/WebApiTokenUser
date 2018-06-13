using System;

namespace WebApiTokenUser.Services
{
    public class AuthorizeException: Exception
    {
        public AuthorizeException() : base("Invalid login or password") { }
    }
}