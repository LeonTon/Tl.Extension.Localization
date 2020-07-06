using System;
using System.Globalization;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.ResouceManager
{
    public class ResourceManagerStringLocalizerProvider : StringLocalizerProvider
    {
        private readonly System.Resources.ResourceManager _resourceManager;

        public ResourceManagerStringLocalizerProvider(System.Resources.ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public override bool TryGet(string key, out string value) =>
            TryGet(CultureInfo.CurrentUICulture, key, out value);

        public override bool TryGet(CultureInfo culture, string key, out string value)
        {
            try
            {
                value = _resourceManager.GetString(key, culture);
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}