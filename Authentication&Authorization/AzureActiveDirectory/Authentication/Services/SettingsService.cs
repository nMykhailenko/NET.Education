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
        public SettingsService(IOptions<AzureAdSettings> options)
        {
            _azureAdSettings = options.Value;
        }
        public AzureAdSettings GetAzureAdSettings()
        {
            return _azureAdSettings;
        }
    }
}
