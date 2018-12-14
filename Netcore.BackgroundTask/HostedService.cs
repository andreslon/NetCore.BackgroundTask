using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Netcore.BackgroundTask.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Netcore.BackgroundTask
{ 
    internal class HostedService : IHostedService, IDisposable
    {
        private Timer Timer { get; set; }
        private IConfiguration Configuration { get; set; }
        private ICustomerService CustomerService { get; set; }
        public HostedService(IConfiguration configuration, ICustomerService customerService)
        {
            Configuration = configuration;
            CustomerService = customerService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is starting.");

            Timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(double.Parse(Configuration["Settings:ExecutionTimeSeconds"])));

            return Task.CompletedTask;
        } 

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");

            Timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            Timer?.Dispose();
        }

        private void DoWork(object state)
        {
            Console.WriteLine("Timed Background Service is working.");

            CustomerService.Process();
        }
    }
}
