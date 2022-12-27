using System;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Net
{
    public class MainService : IMainService
    {
        private readonly IServiceProvider serviceProvider;

        public MainService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ITestService GetTest()
        {
            var instance = serviceProvider.GetService<ITestService>();
            return instance;
        }
    }
}
