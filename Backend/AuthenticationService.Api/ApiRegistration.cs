using System;
using AuthenticationService.Api.Util;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.Api
{
    public static class ApiRegistration
    {
        public static IServiceCollection AddApiTools(this IServiceCollection services)
        {
            services.AddSingleton<IIPAddressTools, IPAddressTools>();

            return services;
        }
    }
}
