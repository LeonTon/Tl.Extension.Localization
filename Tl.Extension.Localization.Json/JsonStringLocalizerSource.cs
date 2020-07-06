using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.File;

namespace Tl.Extension.Localization.Json
{
    public class JsonStringLocalizerSource : FileStringLocalizerSource
    {
        public override IStringLocalizerProvider Build()
        {
            return new JsonStringLocalizerProvider(this);
        }
    }
}