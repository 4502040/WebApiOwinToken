using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Auth
{    

    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            IFormCollection parameters = await context.Request.ReadFormAsync();
                        
            var puId = parameters.Get("PuId");            

            //AppDb db = new AppDb();

            //var user = db.Users.FirstOrDefault( q=> q.name == context.UserName && q.pas ==  context.Password);

            if (context.UserName == "Test" && context.Password == "Test")
            {
                string dateNow = DateTime.Now.ToString();

                identity.AddClaim(new Claim(ClaimTypes.Name, "Test"));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));                
                identity.AddClaim(new Claim("CompanyId", "12"));
                identity.AddClaim(new Claim("PuId", puId));
                identity.AddClaim(new Claim("TokenDate", dateNow));

                //var roles = user.UserPermissions.ToList();

                //foreach (var role in roles)
                //{
                //    identity.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
                //}

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                
                context.Rejected();
            }
        }

    }
}