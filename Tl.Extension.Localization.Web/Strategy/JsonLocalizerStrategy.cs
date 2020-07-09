using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.Json;

namespace Tl.Extension.Localization.Web.Strategy
{
    public class JsonLocalizerStrategy: LocalizerStrategy
    {
        public override IStringLocalizer GetStringLocalizer()
        {
            var source = new JsonStringLocalizerSource
            {
                Directory = Directory.GetCurrentDirectory() + "/Resource",
                FilePathPattern = $"SharedResource.*.json"
            };
            source.ResolveFileProvider();

            var stringLocalizerFactory = new StringLocalizerFactory();
            stringLocalizerFactory.AddSource(source);
            return stringLocalizerFactory.CreateStringLocalizer();
        }
    }
}
