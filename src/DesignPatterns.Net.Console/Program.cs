using System.Threading.Tasks;
using DesignPatterns.Net.Console.Hosts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesignPatterns.Net.Console
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            using (var host = DefaultHostBuilder.GetHost(args))
            {
                await host.StartAsync();
                var lifetime = host.Services.GetService<IHostApplicationLifetime>();

                var command = host.Services.GetService<IBasicCommand>();
                command.Execute();

                System.Console.WriteLine("...that's all folks!");

                lifetime.StopApplication();
                await host.WaitForShutdownAsync();
            }
        }
    }
}
