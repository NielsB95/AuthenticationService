using System;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Roles;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationService.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class IsSuperAdminAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Role superAdmin;
        public IRoleRepository RoleRepository { get; set; }

        public IsSuperAdminAttribute()
        {
            superAdmin = RoleRepository.GetSuperAdmin();
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User;



        }
    }
}
