using DataAccess.Models.Context;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiTokenUser.Services
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var db = new DatabaseContext())
            {
                var entry = db.Users.Where(record => record.Login == context.UserName &&
                record.Password == context.Password).FirstOrDefault();
                if (entry == null)
                {
                    context.SetError("invalid_grant",
                    "The user name or password is incorrect.");
                    return;
                }
            }

            context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }

    }
}