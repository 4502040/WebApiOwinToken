using System;
using System.Web.Http;
using Auth;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using OWINWebAPI;

[assembly: OwinStartup(typeof(Auth.Startup))]

namespace Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new MyAuthProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(200),
                Provider = myProvider,
                RefreshTokenProvider = new TokenRefreshProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
