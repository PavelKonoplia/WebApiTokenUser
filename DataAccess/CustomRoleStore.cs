using Microsoft.AspNet.Identity.EntityFramework;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{
    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(IdentityDatabaseContext context)
            : base(context)
        {
        }
    }

}
