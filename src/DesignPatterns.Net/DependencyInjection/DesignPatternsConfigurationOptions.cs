using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Net.DependencyInjection
{
    public class DesignPatternsConfigurationOptions
    {
        public ICollection<Assembly> Assemblies { get; set; } = new List<Assembly>();
    }
}
