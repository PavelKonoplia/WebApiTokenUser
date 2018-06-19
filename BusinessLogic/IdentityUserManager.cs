using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.BLL
{
    public class IdentityUserManager : UserManager<User, long>
    {

        public IdentityUserManager(IUserStore<User, long> store, IdentityFactoryOptions<IdentityUserManager> options)
            : base(store)
        {
            this.UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider =
                    new DataProtectorTokenProvider<User, long>(
                        dataProtectionProvider.Create("Identity"));
            }
        }     
       
    }
}

