using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Authorization.Requirement
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRequirement"/> class.
        /// </summary>
        /// <param name="role">User role/</param>
        public RoleRequirement(string[] role)
        {
            Role = role;
        }

        /// <summary>
        /// Gets or sets a role.
        /// </summary>
        public string[] Role { get; set; }
    }
}
