using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.DataLayer
{
    public static class Registration
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Get all the repositories
            var repositories = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .Where(x => x.IsClass)
                        .Where(x => typeof(IRepository).IsAssignableFrom(x));

            foreach (Type repository in repositories)
                services.AddSingleton(repository);

            return services;
        }

    }
}
