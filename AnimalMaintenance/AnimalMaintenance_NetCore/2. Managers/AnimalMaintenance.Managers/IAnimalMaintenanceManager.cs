namespace AnimalMaintenance.Managers
{
    using System.Collections.Generic;
    using DataTransferObjects;

    public interface IAnimalMaintenanceManager
    {
        /// <summary>
        /// Responsible for returning a list of all present animals within the AnimalMaintenance database.
        /// </summary>
        List<Animal> GetAnimals();

        /// <summary>
        /// Responsible for returning a single animal from the AnimalMaintenance database with the corresponding Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Animal GetAnimal(int id);

        /// <summary>
        /// Responsible for adding a new animal record into the AnimalMaintenance database.
        /// </summary>
        /// <param name="animalToAdd"></param>
        void AddAnimal(Animal animalToAdd);

        /// <summary>
        /// Responsible for updating an existing animal record in the Animal Maintenance database.
        /// </summary>
        /// <param name="userUpdatedAnimal"></param>
        void UpdateAnimal(Animal userUpdatedAnimal);

        /// <summary>
        /// Responsible for removing an existing animal record in the Animal Maintenance database.
        /// </summary>
        /// <param name="id"></param>
        void DeleteAnimal(int id);
    }
}