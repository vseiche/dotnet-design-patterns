using DesignPatterns.Net.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace DesignPatterns.Net.Console.Hosts
{
    public static class SimpleInjectorHostBuilder
    {
        private static readonly Container container = new Container();

        public static IHost GetHost(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            host.UseSimpleInjector(container);

            return host;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(System.Console.Out);

                    services.AddSimpleInjector(container);

                    services.AddTransient<IBasicCommand, BasicCommand>();

                    services.AddDesignPatterns(options =>
                    {
                        options.Assemblies.Add(typeof(Program).Assembly);
                    });
                });
    }
}
