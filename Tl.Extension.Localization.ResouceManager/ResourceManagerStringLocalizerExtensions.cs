using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.ResouceManager
{
    public static class ResourceManagerStringLocalizerExtensions
    {
        public static ILocalizationBuilder AddResourceFiles(
            this ILocalizationBuilder builder, string baseName, Assembly assembly)
        {
            var source = new ResourceManagerStringLocalizerSource(baseName, assembly);

            builder.Services.AddSingleton<IStringLocalizerSource>(source);

            return builder;
        }
    }
}