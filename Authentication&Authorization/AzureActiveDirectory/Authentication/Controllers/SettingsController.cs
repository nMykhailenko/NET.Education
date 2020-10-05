using Authentication.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    /// <summary>
    /// Settings Controller.
    /// </summary>
    public class SettingsController : Controller
    {
        /// <summary>
        /// Our DI for settings service.
        /// </summary>
        private readonly ISettingsService _settingsService;
        
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        /// <summary>
        /// Controller action for getting settings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("settings/active-directory")]
        public IActionResult Get() => Ok(_settingsService.GetAzureAdSettings());
    }
}
