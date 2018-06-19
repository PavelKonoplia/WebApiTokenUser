using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{
    public class CustomUserStore : UserStore<User, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(DbContext context)
            : base(context)
        {
        }
    }
}
