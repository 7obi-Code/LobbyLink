using LobbyLink.Website.OpenIDConnect;

namespace LobbyLink.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure for OpenID
            OpenIDConnectUtils oidcConfig = new();
            oidcConfig.ConfigureBuild(builder);

            var app = builder.Build();

            // Configure for OpenID
            oidcConfig.ConfigureApp(app);

            app.Run();
        }
    }

}
