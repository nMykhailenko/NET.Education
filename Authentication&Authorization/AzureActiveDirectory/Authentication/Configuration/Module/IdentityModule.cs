using Authentication.Configuration.Injection.Contract;
using Authentication.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Configuration.Module
{
    public class IdentityModule : IInjectModule
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityServerModule"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance to access config data.</param>
        public IdentityModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public IServiceCollection Load(IServiceCollection services)
        {
            var azureAdSettings = _configuration.GetSection(nameof(AzureAdSettings)).Get<AzureAdSettings>();
            services.Configure<AzureAdSettings>(x => _configuration.GetSection(nameof(AzureAdSettings)).Bind(x));

            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;

            });
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                 .AddAzureAD(options => _configuration.Bind(nameof(AzureAdSettings), options));

            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                options.Authority = $"{azureAdSettings.Instance}{azureAdSettings.TenantId}/v2.0";
                options.TokenValidationParameters.ValidateIssuer = false;
            });

            return services;
        }
    }
}
