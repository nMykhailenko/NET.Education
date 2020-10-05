using Authentication.Services.Contract;
using Authentication.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly AzureAdSettings _azureAdSettings;
        private readonly ICacheService<AzureAdSettings> _cacheService;

        public SettingsService(IOptions<AzureAdSettings> options,
            ICacheService<AzureAdSettings> cacheService)
        {
            _azureAdSettings = options.Value;
            _cacheService = cacheService;
        }


        public AzureAdSettings GetAzureAdSettings()
        {
            var value = _cacheService.TryGetValue(1);
            if (value == null)
            {
                _cacheService.SetValue(1, _azureAdSettings);
                return _azureAdSettings;
            }

            return value;
        }
    }
}
