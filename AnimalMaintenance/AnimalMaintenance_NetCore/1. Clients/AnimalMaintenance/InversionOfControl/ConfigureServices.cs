namespace AnimalMaintenance.InversionOfControl
{
    using Accessors;
    using Accessors.Database;
    using Managers;
    using Managers.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigureServices
    {
        public static void ConfigureDependencies(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services
                .AddScoped<IAnimalMaintenanceManager, AnimalMaintenanceManager>()
                .AddScoped<IAnimalMaintenanceAccessor, AnimalMaintenanceAccessor>();

            services
                .AddDbContext<AnimalMaintenanceDatabaseContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("AnimalMaintenanceConnectionString")));

            // Adds any Mapping profile from the Manager level assembly.
            services.AddAutoMapper(typeof(AnimalMappingProfile).Assembly);
        }
    }
}