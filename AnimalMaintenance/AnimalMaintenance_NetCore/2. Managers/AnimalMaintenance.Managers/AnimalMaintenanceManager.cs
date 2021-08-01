namespace AnimalMaintenance.Managers
{
    using System.Collections.Generic;
    using Accessors;
    using AutoMapper;
    using DataTransferObjects;

    public class AnimalMaintenanceManager : IAnimalMaintenanceManager
    {
        public AnimalMaintenanceManager(
            IAnimalMaintenanceAccessor animalMaintenanceAccessor,
            IMapper mapper)
        {
            AnimalMaintenanceAccessor = animalMaintenanceAccessor;
            Mapper = mapper;
        }

        private IAnimalMaintenanceAccessor AnimalMaintenanceAccessor { get; }

        private IMapper Mapper { get; }

        public List<Animal> GetAnimals()
        {
            var animalEntities = AnimalMaintenanceAccessor
                .GetAnimals();

            return Mapper.Map<List<Animal>>(animalEntities);
        }

        public Animal GetAnimal(int id)
        {
            var animalEntity = AnimalMaintenanceAccessor
                .GetAnimal(id);

            return Mapper.Map<Animal>(animalEntity);
        }

        public void AddAnimal(Animal animalToAdd)
        {
            var animalEntity = Mapper.Map<Accessors.Entities.Animal>(animalToAdd);

            AnimalMaintenanceAccessor
                .AddAnimal(animalEntity);
        }

        public void UpdateAnimal(Animal userUpdatedAnimal)
        {
            var animalEntity = Mapper.Map<Accessors.Entities.Animal>(userUpdatedAnimal);

            AnimalMaintenanceAccessor
                .UpdateAnimal(animalEntity);
        }

        public void DeleteAnimal(int id)
        {
            AnimalMaintenanceAccessor
                .DeleteAnimal(id);
        }
    }
}