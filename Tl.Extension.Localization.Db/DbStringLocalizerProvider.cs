using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Db
{
    public class DbStringLocalizerProvider : IStringLocalizerProvider
    {
        private  Dictionary<string, string> DBData;
        private StringLocalizerReloadToken _reloadToken = new StringLocalizerReloadToken();

        public IChangeToken GetReloadToken()
        {
            return _reloadToken;
        }


        public void Load()
        {
            DBData = new Dictionary<string, string>
            {
                ["en"] = "hello from db",
                ["zh"] = "ÄãºÃ from db",
            };
        }

        public bool TryGet(string key, out string value)
        {
           return TryGet(CultureInfo.CurrentUICulture, key, out value);
        }

        public bool TryGet(CultureInfo culture, string key, out string value)
        {
            value = GetDataFromDb(culture);
            return !string.IsNullOrWhiteSpace(value);
        }

        private string GetDataFromDb(CultureInfo culture)
        {
            return DBData[culture.Name];

        }
    }
}