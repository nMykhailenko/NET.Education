using Authentication.Authorization.Requirement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Authentication.Authorization.Filter
{
    public class RoleFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly RoleRequirement _requirement;

        public RoleFilter(RoleRequirement requirement)
        {
            _requirement = requirement;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizationResult = true;

            if (authorizationResult) context.Result = new ChallengeResult();
        }
    }
}
