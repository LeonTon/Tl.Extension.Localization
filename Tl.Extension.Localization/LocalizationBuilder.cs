using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization
{
    public class LocalizationBuilder : ILocalizationBuilder
    {

        public LocalizationBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
