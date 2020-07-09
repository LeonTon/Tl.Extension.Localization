using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Json
{
    public static class JsonStringLocalizerExtensions
    {
        public static IServiceCollection AddJsonFiles(
            this IServiceCollection services, string directory, string filePathPattern)
        {
            var source = new JsonStringLocalizerSource
            {
                Directory = directory,
                FilePathPattern = filePathPattern
            };
            
            source.ResolveFileProvider();
            
            services.AddSingleton<IStringLocalizerSource>(source);
            
            return services;
        }
    }
}