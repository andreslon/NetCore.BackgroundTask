using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netcore.BackgroundTask.Core.Interfaces;
using Netcore.BackgroundTask.Core.Services;
using Netcore.BackgroundTask.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Netcore.BackgroundTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddEnvironmentVariables();
                    config.AddJsonFile($"appsettings.{environment}.json",
                        optional: true, reloadOnChange: true);
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<HostedService>();
                    #region Core services
                    services.AddScoped<ICustomerService, CustomerService>();
                    #endregion

                    #region Repositories
                    services.AddScoped<ICustomerRepository, CustomerRepository>();
                    #endregion
                });
            await builder.RunConsoleAsync();
        }
    }
}
