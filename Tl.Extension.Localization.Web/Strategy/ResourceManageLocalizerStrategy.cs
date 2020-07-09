using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.ResouceManager;

namespace Tl.Extension.Localization.Web.Strategy
{
    public class ResourceManageLocalizerStrategy : LocalizerStrategy
    {
        private readonly string baseName = "Tl.Extension.Localization.Web.Resource";

        public override IStringLocalizer GetStringLocalizer()
        {
            var source = new ResourceManagerStringLocalizerSource(
                $"{baseName}.SharedResource",
                Assembly.GetExecutingAssembly());

            var stringLocalizerFactory = new StringLocalizerFactory();

            stringLocalizerFactory.AddSource(source);

            return stringLocalizerFactory.CreateStringLocalizer();
        }
    }
}
