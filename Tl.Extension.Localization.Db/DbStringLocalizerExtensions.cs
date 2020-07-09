using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Db
{
    public static class DbStringLocalizerExtensions
    {
        public static IServiceCollection AddDbSource(
            this IServiceCollection services)
        {
            var source = new DbStringLocalizerSource();
            
            services.AddSingleton<IStringLocalizerSource>(source);
            
            return services;
        }
    }
}