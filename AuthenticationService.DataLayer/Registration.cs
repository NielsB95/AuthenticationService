using AuthenticationService.BusinessLayer;
using AuthenticationService.DataLayer.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace AuthenticationService.DataLayer
{
    public static class Registration
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            // Add the database context as a singleton.
            services.AddDbContext<AuthenticationServiceContext>(ServiceLifetime.Singleton);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Get all the repository types.
            var repositories = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .Where(x => x.IsClass && !x.IsAbstract)
                        .Where(x => typeof(IRepository).IsAssignableFrom(x));

            foreach (Type repository in repositories)
            {
                // Find the corresponding interface type.
                var repoInterfaces = repository.GetInterfaces()
                    .Where(x => typeof(IRepository).IsAssignableFrom(x))
                    .Where(x => x.Name != typeof(IRepository).Name)
                    .Where(x => !x.IsGenericType);

                // There should only be one repository interface implemented by this repo. 
                //`Single` will throw an exception if there are implemented more
                // than one.
                var repoInterface = repoInterfaces.Single();

                // Register the repository and its interface to the service.
                services.AddSingleton(repoInterface, repository);
            }

            return services;
        }

    }
}
