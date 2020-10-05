using Authentication.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Authorization.Handlers
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var result = Validation(context, requirement);
            if (result)
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
            return;
        }

        private bool Validation(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            return false;
        }
    }
}
