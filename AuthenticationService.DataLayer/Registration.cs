using System;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.DataLayer
{
    public static class Registration
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
