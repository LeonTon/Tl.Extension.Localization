using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tl.Extension.Localization.Abstraction;
using Tl.Extension.Localization.Web.Strategy;

namespace Tl.Extension.Localization.Web.Controllers
{
    public class StartController : Controller
    {

        private readonly IStringLocalizer _localizer;


        public StartController(IStringLocalizerFactory localizerFactory)
        {
            _localizer = localizerFactory.CreateStringLocalizer();
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

            var result = _localizer["Greeting"];
            return Content(result);
        }
    }
}