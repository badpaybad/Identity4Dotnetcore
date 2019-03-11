using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Identity4WebClient.Controllers
{
    public class PrivacyController : MyBaseController
    {
        public IActionResult Index()
        {
            return View(WebRootUrl());
        }
    }
}