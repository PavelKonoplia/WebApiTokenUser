
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
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
            // Configure validation logic for passwords 

            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
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

