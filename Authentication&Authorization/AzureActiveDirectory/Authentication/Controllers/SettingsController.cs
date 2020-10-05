using Authentication.Services.Contract;
using Authentication.Settings;
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
        private readonly ICacheService<AzureAdSettings> _cacheService;
        
        public SettingsController(
            ISettingsService settingsService,
            ICacheService<AzureAdSettings> cacheService)
        {
            _settingsService = settingsService;
            _cacheService = cacheService;
        }

        /// <summary>
        /// Controller action for getting settings.
        /// </summary>
        /// <returns></returns>
        [HttpGet("settings/active-directory")]
        public IActionResult Get() 
        {
            return Ok(_settingsService.GetAzureAdSettings());
        }
    }
}
