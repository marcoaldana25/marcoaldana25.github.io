namespace AnimalMaintenance.Accessors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Database;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class AnimalMaintenanceAccessor : IAnimalMaintenanceAccessor
    {
        public AnimalMaintenanceAccessor(AnimalMaintenanceDatabaseContext animalMaintenanceDatabaseContext)
        {
            AnimalMaintenanceDatabaseContext = animalMaintenanceDatabaseContext;
        }

        private AnimalMaintenanceDatabaseContext AnimalMaintenanceDatabaseContext { get; }

        public List<Animal> GetAnimals()
        {
            var allAnimalEntities = AnimalMaintenanceDatabaseContext
                .Animals
                .ToList();

            return allAnimalEntities;
        }

        public Animal GetAnimal(int id)
        {
            return GetAnimalEntity(id);
        }

        public void AddAnimal(Animal animalToAdd)
        {
            if (animalToAdd is null)
            {
                throw new ArgumentNullException(
                    $"{nameof(animalToAdd)} cannot be null when attempting to add a new record.");
            }

            AnimalMaintenanceDatabaseContext
                .Animals
                .Add(animalToAdd);

            AnimalMaintenanceDatabaseContext
                .SaveChanges();
        }

        public void UpdateAnimal(Animal userUpdatedAnimal)
        {
            var animalToUpdate = GetAnimalEntity(userUpdatedAnimal.Id);

            if (animalToUpdate is null)
            {
                throw new DbUpdateException(
                    $"{nameof(animalToUpdate)} cannot be null when attempting to update a record.");
            }

            AnimalMaintenanceDatabaseContext
                .Entry(animalToUpdate)
                .CurrentValues
                .SetValues(userUpdatedAnimal);

            AnimalMaintenanceDatabaseContext
                .SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animalToDelete = GetAnimalEntity(id);

            if (animalToDelete is null)
            {
                throw new DbUpdateException("No valid Animal entity to delete.");
            }

            AnimalMaintenanceDatabaseContext
                .Animals
                .Remove(animalToDelete);

            AnimalMaintenanceDatabaseContext
                .SaveChanges();
        }

        private Animal GetAnimalEntity(int id)
        {
            return AnimalMaintenanceDatabaseContext
                .Animals
                .FirstOrDefault(animal => animal.Id == id);
        }
    }
}