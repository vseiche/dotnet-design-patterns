using DesignPatterns.Net.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Net.Console.Hosts
{
    public static class DefaultHostBuilder
    {
        public static IHost GetHost(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            return host;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(System.Console.Out);

                    services.AddTransient<IBasicCommand, BasicCommand>();

                    services.AddDesignPatterns(options =>
                    {
                        options.Assemblies.Add(typeof(Program).Assembly);
                    });
                });
    }
}
