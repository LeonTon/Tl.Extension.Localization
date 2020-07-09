using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Tl.Extension.Localization.Web
{
    public enum ResourceTypeEnum
    {
        [Description("ResourceFile")]
        ResourceFile,

        [Description("JsonFile")]
        JsonFile,

        [Description("Db")]
        Db,
    }
}
