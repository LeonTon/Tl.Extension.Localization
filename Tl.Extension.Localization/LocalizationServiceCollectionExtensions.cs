using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tl.Extension.Localization;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization
{
    public static class LocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalization(
            this IServiceCollection services,
            Action<ILocalizationBuilder> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            AddLocalizationServices(services);
            
            configure(new LocalizationBuilder(services));

            return services;
        }

        private static void AddLocalizationServices(IServiceCollection services)
        {
            services.TryAddSingleton<IStringLocalizerFactory, StringLocalizerFactory>();
        }
    }
}