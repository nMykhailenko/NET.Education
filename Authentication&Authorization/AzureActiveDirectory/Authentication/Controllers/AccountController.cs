using Authentication.Models.RequestModels;
using Authentication.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly AzureAdSettings _azureAdSettings;
        public AccountController(IOptions<AzureAdSettings> azureAdOptions)
        {
            _azureAdSettings = azureAdOptions.Value;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" },
                             AzureADDefaults.AuthenticationScheme);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel loginRequest)
        {
            var url = $"{_azureAdSettings.Instance}{_azureAdSettings.TenantId}/oauth2/v2.0/token";
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(url, CreateClientCredentialsGrantContent());

            return Ok(await result.Content.ReadAsStringAsync());
        }

        private HttpContent CreateClientCredentialsGrantContent()
        {
            var authenticationForm = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"},
                {"client_id", _azureAdSettings.ClientId},
                {"client_secret", _azureAdSettings.ClientSecret},
                {"scope", "https://graph.microsoft.com/.default" }
            };

            return new FormUrlEncodedContent(authenticationForm);
        }
    }
}
