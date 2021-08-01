namespace AnimalMaintenance.Accessors
{
    using System.Collections.Generic;
    using Database;
    using Entities;

    public interface IAnimalMaintenanceAccessor
    {
        /// <summary>
        /// Retrieves a list of all available <see cref="Animal"/> entities.
        /// </summary>
        /// <returns></returns>
        List<Animal> GetAnimals();

        /// <summary>
        /// Returns a single <see cref="Animal"/> based on the id provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Animal GetAnimal(int id);

        /// <summary>
        /// Responsible for adding a single Animal into the <see cref="AnimalMaintenanceDatabaseContext.Animals"/> Database.
        /// </summary>
        /// <param name="animalToAdd"></param>
        void AddAnimal(Animal animalToAdd);

        /// <summary>
        /// Responsible for updating an existing <see cref="Animal"/> entity with the specified information.
        /// </summary>
        /// <param name="userUpdatedAnimal"></param>
        void UpdateAnimal(Animal userUpdatedAnimal);
    
        /// <summary>
        /// Responsible for deleting an existing <see cref="Animal"/> from the database
        /// </summary>
        /// <param name="id"></param>
        void DeleteAnimal(int id);
    }
}