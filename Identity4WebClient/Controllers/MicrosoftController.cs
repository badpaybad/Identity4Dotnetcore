using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Identity4WebClient.Controllers
{
    public class MicrosoftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Redirect()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}