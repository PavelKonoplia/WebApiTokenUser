using System;

namespace WebApiTokenUser.BLL
{
    public class AuthorizeException: Exception
    {
        public AuthorizeException() : base("Invalid login or password")
        {
        }
    }
}