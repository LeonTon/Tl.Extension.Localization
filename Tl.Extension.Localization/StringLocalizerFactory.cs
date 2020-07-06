using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization
{
    public class StringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ConcurrentDictionary<CultureInfo, StringLocalizer> _localizers
            = new ConcurrentDictionary<CultureInfo, StringLocalizer>();

        public IList<IStringLocalizerSource> Sources { get; } = new List<IStringLocalizerSource>();

        public StringLocalizerFactory() : this(Enumerable.Empty<IStringLocalizerSource>())
        {
        }

        public StringLocalizerFactory(IEnumerable<IStringLocalizerSource> sources)
        {
            foreach (var source in sources)
            {
                AddSource(source);
            }
        }

        public IStringLocalizerFactory AddSource(IStringLocalizerSource source)
        {
            Sources.Add(source);
            return this;
        }

        public IStringLocalizer CreateStringLocalizer() =>
            CreateStringLocalizer(CultureInfo.CurrentUICulture);

        public IStringLocalizer CreateStringLocalizer(CultureInfo culture)
        {
            return _localizers.GetOrAdd(culture, c =>
            {
                var providers = Sources.Select(source => source.Build()).ToList();

                return new StringLocalizer(c, providers);
            });
        }
    }
}