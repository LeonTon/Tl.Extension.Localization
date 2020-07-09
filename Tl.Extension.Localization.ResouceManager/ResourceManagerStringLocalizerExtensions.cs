using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.ResouceManager
{
    public static class ResourceManagerStringLocalizerExtensions
    {
        public static IServiceCollection AddResourceFiles(
            this IServiceCollection services, string baseName, Assembly assembly)
        {
            var source = new ResourceManagerStringLocalizerSource(baseName, assembly);
            
            services.AddSingleton<IStringLocalizerSource>(source);
            
            return services;
        }
    }
}