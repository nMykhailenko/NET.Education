using Authentication.Authorization.Filter;
using Authentication.Authorization.Requirement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Authorization.Attributes
{
    public class RoleAttribute : TypeFilterAttribute
    {
        public RoleAttribute(string[] roles)
            : base(typeof(RoleFilter))
        {
            Arguments = new[] { new RoleRequirement(roles) };
            Order = int.MinValue;
        }
    }
}
