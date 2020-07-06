using System;
using System.Collections.Generic;
using System.Text;

namespace Tl.Extension.Localization.Abstraction
{
    public interface IStringLocalizerSource
    {
        IStringLocalizerProvider Build();
    }
}
