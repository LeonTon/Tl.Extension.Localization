using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tl.Extension.Localization.Web.Strategy
{
    public class LocalizerStrategyFactory
    {
        private static Dictionary<ResourceTypeEnum, LocalizerStrategy> dictionary =
            new Dictionary<ResourceTypeEnum, LocalizerStrategy>
            {
                [ResourceTypeEnum.Db]=new DbLocalizerStrategy(),
                [ResourceTypeEnum.JsonFile] = new JsonLocalizerStrategy(),
                [ResourceTypeEnum.ResourceFile] = new ResourceManageLocalizerStrategy()
            };


        public LocalizerStrategy GetLocalizerStrategyByResourceType(ResourceTypeEnum resourceType)
        {
            return dictionary[resourceType];
        }
    }
}
