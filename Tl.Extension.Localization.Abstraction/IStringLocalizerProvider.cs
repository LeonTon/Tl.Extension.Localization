using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tl.Extension.Localization.Abstraction
{
    public interface IStringLocalizerProvider
    {
        bool TryGet(string key, out string value);

        bool TryGet(CultureInfo culture, string key, out string value);

        void Load();

        IChangeToken GetReloadToken();
    }
}
