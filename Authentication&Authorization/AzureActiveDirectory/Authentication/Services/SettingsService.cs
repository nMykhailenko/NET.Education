using Authentication.Services.Contract;
using Authentication.Settings;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly AzureAdSettings _azureAdSettings;
        private readonly ICacheService<AzureAdSettings> _cacheService;
        private readonly SqlSettings _sqlSettings;

        public SettingsService(IOptions<AzureAdSettings> options,
            IOptions<SqlSettings> sqlOptions,
            ICacheService<AzureAdSettings> cacheService)
        {
            _azureAdSettings = options.Value;
            _sqlSettings = sqlOptions.Value;
            _cacheService = cacheService;
        }


        public AzureAdSettings GetAzureAdSettings()
        {
            var value = _cacheService.TryGetValue(1);
            if (value == null)
            {
                var settings = GetAzureAdSettingsDb();
                _cacheService.SetValue(1, settings);
                return settings;
            }

            return value;
        }

        public AzureAdSettings GetAzureAdSettingsDb()
        {
            using IDbConnection db = new SqlConnection(_sqlSettings.DefaultConnectionString);
            const string query = "select top 1 * from AzureAdSettings";
            return db.QueryFirst<AzureAdSettings>(query);
        }
    }
}
