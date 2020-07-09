using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.Db;

namespace Tl.Extension.Localization.Web.Strategy
{
    public class DbLocalizerStrategy: LocalizerStrategy
    {
        public override IStringLocalizer GetStringLocalizer()
        {
            var source = new DbStringLocalizerSource();
            var stringLocalizerFactory = new StringLocalizerFactory();
            stringLocalizerFactory.AddSource(source);
            return stringLocalizerFactory.CreateStringLocalizer();
        }
    }
}
