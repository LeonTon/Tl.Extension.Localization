using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Db
{
    public static class DbStringLocalizerExtensions
    {
        public static ILocalizationBuilder AddDbSource(
            this ILocalizationBuilder builder, string directory, string filePathPattern)
        {
            var source = new DbStringLocalizerSource();
            
            builder.Services.AddSingleton<IStringLocalizerSource>(source);
            
            return builder;
        }
    }
}