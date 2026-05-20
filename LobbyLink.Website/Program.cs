using LobbyLink.APIClient;
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

            //Registrering af Api Client
            var apiSettings = builder.Configuration.GetSection("ApiSettings");

            builder.Services.AddScoped<ItemInstanceApiClient>(sp =>
                new ItemInstanceApiClient(apiSettings["ItemInstancesUrl"]));

            builder.Services.AddScoped<ListingApiClient>(sp =>
                new ListingApiClient(apiSettings["ListingsUrl"]));

            builder.Services.AddScoped<AccountApiClient>(sp =>
                new AccountApiClient(apiSettings["AccountsUrl"]));

            builder.Services.AddScoped<GameApiClient>(sp =>
                new GameApiClient(apiSettings["GamesUrl"]));

            builder.Services.AddScoped<ItemDefinitionApiClient>(sp =>
            new ItemDefinitionApiClient(apiSettings["ItemDefinitionsUrl"]));

            var app = builder.Build();

            // Configure for OpenID
            oidcConfig.ConfigureApp(app);

            app.Run();
        }
    }

}
