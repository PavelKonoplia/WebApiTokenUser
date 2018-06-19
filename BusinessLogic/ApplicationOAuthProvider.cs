using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace WebApiTokenUser.BLL
{    
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IdentityUserManager userManager;

        public ApplicationOAuthProvider(IdentityUserManager userManager)
        {
            this.userManager = userManager;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var entry = await userManager.FindAsync(context.UserName, context.Password);

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