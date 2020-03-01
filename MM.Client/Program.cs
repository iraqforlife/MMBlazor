using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;

namespace MM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<Authorizer>();
            builder.Services.AddScoped<AuthenticationStateProvider, Authorizer>(
                provider => provider.GetRequiredService<Authorizer>());
            builder.Services.AddScoped<ILoginService, Authorizer>(
                provider => provider.GetRequiredService<Authorizer>());

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.RootComponents.Add<App>("app");
            await builder.Build().RunAsync();
        }
    }
}
