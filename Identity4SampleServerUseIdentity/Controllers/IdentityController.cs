using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity4SampleServerUseIdentity.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("Identity")]
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            //you will get 401 Error, which means the API is protected by our IdentityServer4.

            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
