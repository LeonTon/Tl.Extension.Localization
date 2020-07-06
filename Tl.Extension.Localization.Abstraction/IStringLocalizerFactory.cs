using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tl.Extension.Localization.Abstraction
{
    public interface IStringLocalizerFactory
    {
        IList<IStringLocalizerSource> Sources { get; }
        IStringLocalizerFactory AddSource(IStringLocalizerSource source);
        IStringLocalizer CreateStringLocalizer();
        IStringLocalizer CreateStringLocalizer(CultureInfo culture);
    }
}
