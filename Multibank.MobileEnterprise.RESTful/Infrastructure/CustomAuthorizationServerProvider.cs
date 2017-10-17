using Microsoft.Owin.Security.OAuth;
using System;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Multibank.MobileEnterprise.RESTful.Services;

namespace Multibank.MobileEnterprise.RESTful
{
    public class CustomAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IDataService ds = new MockDataService();

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var response = await ds.Authentication(context.UserName.ToLower(), context.Password);
                var user = response.Item2;
                var error = response.Item1;

                if (user != null)
                {
                    identity.AddClaim(new Claim("IdUser", user.UserId.ToString()));
                    identity.AddClaim(new Claim("UserName", user.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "default"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", error);
                    return;
                }
            }
            catch (SqlException e)
            {
                context.SetError("Sql Error", e.Message);
                return;
            }
            catch (Exception e)
            {
                context.SetError("Error", e.Message);
                return;
            }

        }
    }
}