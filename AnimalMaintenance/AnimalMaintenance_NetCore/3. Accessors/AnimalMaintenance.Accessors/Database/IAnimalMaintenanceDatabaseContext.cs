namespace AnimalMaintenance.Accessors.Database
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IAnimalMaintenanceDatabaseContext
    {
        DbSet<Animal> Animals { get; set; }
    }
}