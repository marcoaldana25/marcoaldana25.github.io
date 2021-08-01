namespace AnimalMaintenance.Accessors.Database
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class AnimalMaintenanceDatabaseContext : DbContext
    {
        public AnimalMaintenanceDatabaseContext(
            DbContextOptions<AnimalMaintenanceDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}