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
                ["en"] = "hello from db,current culture is en ,current time is @time ",
                ["zh"] = "你好 from db ,当前culture zh,当前时间 @time",
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