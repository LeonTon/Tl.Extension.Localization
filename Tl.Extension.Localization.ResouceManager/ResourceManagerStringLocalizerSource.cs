using System.Reflection;
using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.ResouceManager
{
    public class ResourceManagerStringLocalizerSource : IStringLocalizerSource
    {
        private System.Resources.ResourceManager _resourceManager;

        public ResourceManagerStringLocalizerSource(string baseName, Assembly assembly)
        {
            _resourceManager = new System.Resources.ResourceManager(baseName, assembly);
        }

        public IStringLocalizerProvider Build()
        {
           return new ResourceManagerStringLocalizerProvider(_resourceManager);
        }
    }
}