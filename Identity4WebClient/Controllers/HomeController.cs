using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity4WebClient.Models;
using Identity4WebClient.Microsoft;
using Microsoft.Extensions.Options;

namespace Identity4WebClient.Controllers
{
    public class HomeController : MyBaseController
    {
        Microsoft.MyMsConfig _msConfig;

        public HomeController(IOptions<MyMsConfig> myMsConfig)
        {
            _msConfig = myMsConfig.Value;
        }

        public IActionResult Index()
        {
            var xxx = "Outside CallBack";
            var param = "Param";

            var mslogin = new MsLogin()
            {
                OauthUrl = _msConfig.BuildOauthUrl(WebRootUrl()),

            };

            mslogin.InnerFunc = CallBackUrl(param);

            return View(mslogin);

            string CallBackUrl(string p)
            {
                var xxx1= param + "<br>Inner: " + mslogin.OauthUrl + "<br>" + xxx + "<br>" + p;
                param = param + "sdfsd";
                return xxx1;
            }

        }

        public IActionResult Privacy()
        {
            return View(WebRootUrl());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class MsLogin
    {
        public string OauthUrl { get; set; }

        public string InnerFunc { get; set; }
    }
}
