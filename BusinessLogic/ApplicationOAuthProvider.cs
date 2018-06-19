using BusinessLogic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.BLL
{    
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IdentityUserManager userManager;

        public ApplicationOAuthProvider(IdentityUserManager _userManager)
        {
            userManager = _userManager;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var entry = userManager.FindAsync(context.UserName, context.Password);

            if (entry == null)
            {
                context.SetError("invalid_grant",
                "The user name or password is incorrect.");
                return;
            }

            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }

    }
}