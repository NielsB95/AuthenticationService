using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AuthenticationService.BusinessLayer;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.DataLayer
{
    public static class Registration
    {
        private static IConfigurationRoot configuration;

        static Registration()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        /// <summary>
        /// This function adds all the services we need for the DataLayer.
        /// </summary>
        /// <returns>The data layer.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddDatabaseContext();
            services.AddRepositories();

            return services;
        }

        /// <summary>
        /// Add the database context so we can use it with Dependency Injection.
        /// </summary>
        /// <returns>The database context.</returns>
        /// <param name="services">Services.</param>
        private static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            // Add the database context as a singleton.
            services.AddDbContext<AuthenticationServiceContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectionString")), ServiceLifetime.Scoped);

            return services;
        }

        /// <summary>
        /// Find all repositories in the assembly and register them as scoped
        /// dependencies.
        /// </summary>
        /// <returns>The repositories.</returns>
        /// <param name="services">Services.</param>
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
                services.AddScoped(repoInterface, repository);
            }

            return services;
        }
    }
}
