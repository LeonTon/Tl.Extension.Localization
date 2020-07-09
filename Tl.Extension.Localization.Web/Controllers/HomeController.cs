using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.VisualBasic;
using Tl.Extension.Localization;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.Db;
using Tl.Extension.Localization.Json;
using Tl.Extension.Localization.ResouceManager;
using Tl.Extension.Localization.Web;
using Tl.Extension.Localization.Web.Strategy;

namespace Localization.Controllers
{
    public class HomeController : Controller
    {
        private readonly string baseName = "Tl.Extension.Localization.Web.Resource";

        public HomeController()
        {
        }

        // GET: /<controller>/
        public IActionResult Index(string cultures)
        {
            if (!string.IsNullOrWhiteSpace(cultures))
            {
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo(cultures);

            }
            else
            {
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo("en");
            }


            var stringLocalizer = new LocalizerStrategyFactory()
                .GetLocalizerStrategyByResourceType(ResourceTypeEnum.ResourceFile)
                .GetStringLocalizer();

            //var result = stringLocalizer["Greeting"];

            var mapper = new StringLocalizerParamMapper("@", new Dictionary<string, string>()
            {
                ["time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
            var result = stringLocalizer["Greeting", mapper, Map];
            return Content(result);
        }

        private string Map(StringLocalizerParamMapper mapper)
        {
            
            if (string.IsNullOrWhiteSpace(mapper.Template))
                return "";

            foreach (var param in mapper.ReplaceParam)
            {
                mapper.Template = mapper.Template.Replace($"{mapper.Placeholder}{param.Key}", param.Value);
            }

            return mapper.Template;
        }

    }
}
