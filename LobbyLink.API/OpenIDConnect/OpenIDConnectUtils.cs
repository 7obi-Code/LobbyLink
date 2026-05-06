using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// Required NuGet Packages
// Microsoft.AspNetCore.Authentication.JwtBearer
// Microsoft.AspNetCore.Authentication.OpenIdConnect
// Microsoft.IdentityModel.Protocols.OpenIdConnect
// Microsoft.AspNet.WebApi.Core

namespace LobbyLink.API.OpenIDConnect;

public class OpenIDConnectUtils
{
    // Configuration priority from highest to lowest
    // Highest: Command line arguments
    //        : Non-prefixed environment variables
    //        : User secrets from the .NET User Secrets Manager
    //        : Any appsettings.{ ENVIRONMENT_NAME }.json files
    //        : The appsettings.json file
    // Lowest : Fallback to the host configuration

    /// <summary>
    /// Setting up OpenIDConnect authentication (Program.cs)
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>

    public void ConfigureBuild(WebApplicationBuilder builder)
    {
        MyConfiguration.Set(builder.Configuration);
        builder.Services.AddControllers();

        // >>> This adds the authentication service
        builder.Services
               .AddAuthentication()
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   // OpenIDRealmURI coud be "https://auth.a.ucnit.eu/realms/xOIDCx"
                   options.Authority = builder.Configuration["OpenIDRealmURI"];
                   options.Audience = "account";
                   options.MapInboundClaims = false;
                   options.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = msg =>
                       {
                           var token = msg?.Request.Headers.Authorization.ToString();
                           string path = msg?.Request.Path ?? "";
                           if (!string.IsNullOrEmpty(token))

                           {
                               Console.WriteLine("Access token");
                               Console.WriteLine($"URL: {path}");
                               Console.WriteLine($"Token: {token}\r\n");
                           }
                           else
                           {
                               Console.WriteLine("Access token");
                               Console.WriteLine("URL: " + path);
                               Console.WriteLine("Token: No access token provided\r\n");
                           }
                           return Task.CompletedTask;
                       }
                   };
                   options.Events = new JwtBearerEvents()
                   {
                       //...

                       OnTokenValidated = ctx =>
                       {
                           Console.WriteLine();
                           Console.WriteLine("Claims from the access token");
                           if (ctx?.Principal != null)
                           {
                               foreach (var claim in ctx.Principal.Claims)
                               {
                                   Console.WriteLine($"{claim.Type} - {claim.Value}");
                               }
                           }
                           Console.WriteLine();
                           return Task.CompletedTask;
                       }
                   };

               });
        // <<<

        // >>> This adds the authorization service
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });

    }

    /// <summary>
    /// Map synthetic endpoints for authentication
    /// </summary>
    /// <param name="app">WebApplication</param>
    public void ConfigureApp(WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

    }

    public JwtSecurityToken GetJwtPayload(HttpContext myContext)
    {
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(myContext.GetTokenAsync("access_token").Result);
    }

    public string GetJwtClaim(HttpContext myContext, string theClaim)
    {
        JwtSecurityToken jwtPayload = GetJwtPayload(myContext);
        return jwtPayload.Claims.FirstOrDefault(claim => claim.Type == theClaim).Value;
    }

}

static public class MyConfiguration
{
    static ConfigurationManager _config;
    static public void Set(ConfigurationManager config)
    {
        _config = config;
    }

    static public ConfigurationManager Get()
    {
        return _config;
    }

}
