using Microsoft.Extensions.DependencyInjection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Json
{
    public static class JsonStringLocalizerExtensions
    {
        public static ILocalizationBuilder AddJsonFiles(this ILocalizationBuilder builder, string directory, string filePathPattern)
        {

            var source = new JsonStringLocalizerSource
            {
                Directory = directory,
                FilePathPattern = filePathPattern
            };
            source.ResolveFileProvider();
            builder.Services.AddSingleton<IStringLocalizerSource>(source);
            return builder;
        }
    }
}