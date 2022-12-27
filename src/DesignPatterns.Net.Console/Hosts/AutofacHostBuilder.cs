using Autofac;
using Autofac.Extensions.DependencyInjection;
using DesignPatterns.Net.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Net.Console.Hosts
{
    public static class AutofacHostBuilder
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
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(System.Console.Out);

                    services.AddTransient<IBasicCommand, BasicCommand>();

                    services.AddDesignPatterns(options =>
                    {
                        options.Assemblies.Add(typeof(Program).Assembly);
                    });
                })
                .ConfigureContainer<ContainerBuilder>(ConfigureContainer);

        private static void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Add any Autofac modules or registrations. This is called AFTER
            // ConfigureServices so things you register here OVERRIDE things
            // registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.
        }
    }
}
