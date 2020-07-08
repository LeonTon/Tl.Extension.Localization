using Tl.Extension.Localization.Abstraction;

namespace Tl.Extension.Localization.Db
{
    public class DbStringLocalizerSource : IStringLocalizerSource
    {
        public  IStringLocalizerProvider Build()
        {
            return new DbStringLocalizerProvider();
        }
    }
}