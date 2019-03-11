using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Identity4WebClient.Controllers
{
    public class MyBaseController : Controller
    {
       public string WebRootUrl()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            return baseUrl;
        }
    }
}