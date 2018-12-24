using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationService.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class IsSuperAdminAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string superAdminID = "9ecab798-868b-4bc5-ad8b-003657e2a1e2";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User;

            // No need to do something when don't recoginize the user.
            if (claims.Identity.IsAuthenticated)
                return;

            // Check if the user has the 'Super admin' role
            if (!claims.HasClaim("RoleID", superAdminID))
                context.Result = new UnauthorizedResult();
        }
    }
}
