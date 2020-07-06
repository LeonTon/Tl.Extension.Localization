using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.Extensions.Primitives;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization
{
    public abstract class StringLocalizerProvider : IStringLocalizerProvider
    {
        private StringLocalizerReloadToken _reloadToken = new StringLocalizerReloadToken();

        public StringLocalizerProvider()
        {
            Data = new Dictionary<CultureInfo, IDictionary<string, string>>();
        }

        protected IDictionary<CultureInfo, IDictionary<string, string>> Data { get; set; }

        public virtual bool TryGet(string key, out string value) => 
            TryGet(CultureInfo.CurrentUICulture, key, out value);

        public virtual bool TryGet(CultureInfo culture, string key, out string value)
        {
            while (true)
            {
                if (Data.TryGetValue(culture, out var dict))
                {
                    return dict.TryGetValue(key, out value);
                }

                var parentCulture = culture.Parent;
                if (string.IsNullOrEmpty(parentCulture.Name))
                {
                    value = null;
                    return false;
                }

                culture = parentCulture;
            }
        }
        public virtual void Load() { }
        
        protected void OnReload()
        {
            var previousToken = Interlocked.Exchange(ref _reloadToken, new StringLocalizerReloadToken());
            previousToken.OnReload();
        }
        
        public IChangeToken GetReloadToken()
        {
            return _reloadToken;
        }
    }
}