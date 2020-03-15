using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Modal;

namespace MM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped<Authorizer>();
            builder.Services.AddScoped<AuthenticationStateProvider, Authorizer>(
                provider => provider.GetRequiredService<Authorizer>());
            builder.Services.AddScoped<ILoginService, Authorizer>(
                provider => provider.GetRequiredService<Authorizer>());
            
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
