using BusinessLogic.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiTokenUser.DAL;
using WebApiTokenUser.Entity.Models;

namespace WebApiTokenUser.Services
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IRepository<User> _userContext;

        public ApplicationOAuthProvider(IRepository<User> userContext)
        {
            _userContext = userContext;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var entry = _userContext.FindBy(record => record.Login == context.UserName &&
            record.Password == context.Password).FirstOrDefault();
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