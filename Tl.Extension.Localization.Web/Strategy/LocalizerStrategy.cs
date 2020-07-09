using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Web.Strategy
{
    public abstract class LocalizerStrategy
    {
        public abstract IStringLocalizer GetStringLocalizer();
    }
}
