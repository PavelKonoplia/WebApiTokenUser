using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApiTokenUser.Entity.Models
{
    public class User : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim> 
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, long> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ExternalBearer);

            return userIdentity;
        }
    }
}