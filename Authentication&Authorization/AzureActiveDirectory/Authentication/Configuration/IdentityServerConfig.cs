using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Configuration
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis() => new List<ApiResource> { new ApiResource("api", "IdentityServer", new[] { JwtClaimTypes.Email, "firstname" }) };

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
               new Client
               {
                    ClientId = "sp",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedScopes = { }
               }
        };
    }
}
