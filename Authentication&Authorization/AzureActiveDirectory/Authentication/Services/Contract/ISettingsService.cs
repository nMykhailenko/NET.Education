using Authentication.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Services.Contract
{
    /// <summary>
    /// Settings service contract.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Get Azure AD settings.
        /// </summary>
        /// <returns>Azure active directory configuration.</returns>
        AzureAdSettings GetAzureAdSettings();
    }
}
