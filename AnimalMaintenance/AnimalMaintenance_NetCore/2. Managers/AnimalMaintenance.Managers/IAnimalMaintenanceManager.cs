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

        Animal GetAnimal(int id);

        void AddAnimal(Animal animalToAdd);

        void UpdateAnimal(Animal userUpdatedAnimal);

        void DeleteAnimal(int id);
    }
}