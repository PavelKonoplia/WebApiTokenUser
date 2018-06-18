using Microsoft.AspNet.Identity.EntityFramework;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{
    public class CustomUserStore : UserStore<User, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(IdentityDatabaseContext context)
            : base(context)
        {
        }
    }
}
