
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.DAL
{
    public class IdentityUserManager : UserManager<User, long>
    {

        public IdentityUserManager(IUserStore<User, long> store)
            : base(store)
        {
        }

        
        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options,
        IOwinContext context)
        {
            IdentityDatabaseContext db = context.Get<IdentityDatabaseContext>();
            IdentityUserManager manager = new IdentityUserManager(new CustomUserStore(db));
            // Configure validation logic for usernames 
            manager.UserValidator = new UserValidator<User, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords 
            manager.PasswordValidator = new PasswordValidator
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
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, long>(
                        dataProtectionProvider.Create("Identity"));
            }

            return manager;
        }
        

        /*
        IdentityDatabaseContext db = context.Get<IdentityDatabaseContext>();
        IdentityUserManager manager = new IdentityUserManager(new CustomUserStore(db));
         return manager;   
         

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options,
       IOwinContext context)
        {
            IdentityDatabaseContext db = context.Get<IdentityDatabaseContext>();
            IdentityUserManager manager = new IdentityUserManager(new CustomUserStore(db));
            // Configure validation logic for usernames 
            manager.UserValidator = new UserValidator<User, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords 
            manager.PasswordValidator = new PasswordValidator
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
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, long>(
                        dataProtectionProvider.Create("Identity"));
            }

            return manager;
        }*/
    }
}

