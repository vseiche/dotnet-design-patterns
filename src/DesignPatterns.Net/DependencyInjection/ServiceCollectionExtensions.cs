using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Net.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDesignPatterns(this IServiceCollection services, Action<DesignPatternsConfigurationOptions> configurationOptionsAction)
        {
            var configurationOptions = new DesignPatternsConfigurationOptions();

            configurationOptionsAction?.Invoke(configurationOptions);

            var assembliesToScan = configurationOptions.Assemblies.Distinct().ToArray();

            AddRequiredServices(services);
            AddDesignPatternsClasses(services, assembliesToScan);

            return services;
        }

        public static void AddRequiredServices(IServiceCollection services)
        {
            services.AddSingleton<IMainService, MainService>();
        }

        public static void AddDesignPatternsClasses(IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            services.Scan(scan => scan.FromAssemblies(assembliesToScan)
                .AddClasses(classes => classes.AssignableTo<ITestService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }
    }
}
