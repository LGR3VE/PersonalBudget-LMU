using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MudBlazor.Services;
using PersonalBudget.Services;

namespace PersonalBudget
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Adding useful UI Components
            builder.Services.AddMudServices();
            
            //Register the TransactionService for DependencyInjections
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            
            //Build and runs Webservice
            await builder.Build().RunAsync();
        }

        
    }
}
