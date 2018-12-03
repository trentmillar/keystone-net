using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Keystone.Core.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Mvc.Sample.Models;

namespace Mvc.Sample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("~/")]
        public ActionResult Index([FromServices] IOptions<KeystoneCoreOptions> options)
        {
            ViewData["Environment"] = options.Value.Environment;
            var model = new HomeViewModel {Environment = options.Value.Environment};
            return View("Home", model);
        }

    }
}