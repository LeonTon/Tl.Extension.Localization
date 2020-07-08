using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using Tl.Extension.Localization;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.Db;
using Tl.Extension.Localization.Json;
using Tl.Extension.Localization.ResouceManager;

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


            var stringLocalizer = GetIStringLocalizerByDb();
            return Content(stringLocalizer["Greeting"]);
        }

        private IStringLocalizer GetIStringLocalizerByResourceManager()
        {
            var source = new ResourceManagerStringLocalizerSource(
                $"{baseName}.SharedResource",
                Assembly.GetExecutingAssembly());

            var stringLocalizerFactory = new StringLocalizerFactory();

            stringLocalizerFactory.AddSource(source);

           return  stringLocalizerFactory.CreateStringLocalizer();
        }

        private IStringLocalizer GetIStringLocalizerByJson()
        {
            var source = new JsonStringLocalizerSource
            {
                Directory = Directory.GetCurrentDirectory()+ "/Resource",
                FilePathPattern = $"SharedResource.*.json"
            };
            source.ResolveFileProvider();

            var stringLocalizerFactory = new StringLocalizerFactory();
            stringLocalizerFactory.AddSource(source);
            return stringLocalizerFactory.CreateStringLocalizer();
        }

        private IStringLocalizer GetIStringLocalizerByDb()
        {
            var source = new DbStringLocalizerSource();
            var stringLocalizerFactory = new StringLocalizerFactory();
            stringLocalizerFactory.AddSource(source);
            return stringLocalizerFactory.CreateStringLocalizer();
        }

    }
}
