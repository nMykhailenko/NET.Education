using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" },
                             AzureADDefaults.AuthenticationScheme);
        }
    }
}
