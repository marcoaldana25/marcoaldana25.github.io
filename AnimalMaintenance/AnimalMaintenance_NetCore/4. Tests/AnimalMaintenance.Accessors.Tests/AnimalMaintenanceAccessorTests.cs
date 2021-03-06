namespace AnimalMaintenance.Accessors.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Database;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AnimalMaintenanceAccessorTests
    {
        // Instantiate new In-Memory version of Animals database.
        private DbContextOptions<AnimalMaintenanceDatabaseContext> DbContextOptions =>
            new DbContextOptionsBuilder<AnimalMaintenanceDatabaseContext>()
                .UseInMemoryDatabase("Animals")
                .Options;


        [Fact]
        public void GetAnimals_ShouldReturnListOfAllAvailableAnimals()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                // Add one record and save in memory db.
                animalMaintenanceDatabaseContext
                    .Animals
                    .Add(new Animal
                    {
                        AnimalType = "Cat"
                    });

                animalMaintenanceDatabaseContext
                    .SaveChanges();

                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act
                var allAnimals = animalMaintenanceAccessor
                    .GetAnimals();

                // Assert
                Assert.True(allAnimals.Count > 0);
            }
        }

        [Fact]
        public void GetAnimal_ShouldReturnSingleAnimalEntity()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                // Add one record and save in memory db.
                animalMaintenanceDatabaseContext
                    .Animals
                    .Add(new Animal
                    {
                        AnimalType = "Cat"
                    });

                animalMaintenanceDatabaseContext
                    .SaveChanges();

                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act
                var animalEntity = animalMaintenanceAccessor
                    .GetAnimal(1);

                // Assert
                Assert.NotNull(animalEntity);
            }
        }

        [Fact]
        public void GetAnimal_NoAnimalWithMatchingId_ShouldReturnNull()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                // Add one record and save in memory db.
                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act
                var animalEntity = animalMaintenanceAccessor
                    .GetAnimal(10);

                // Assert
                Assert.Null(animalEntity);
            }
        }

        [Fact]
        public void AddAnimal_NullAnimalPassedIn_ShouldThrowArgumentNullException()
        {
            // Arrange
            var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => animalMaintenanceAccessor.AddAnimal(null));
        }

        [Fact]
        public void AddAnimal_ValidAnimalEntity_ShouldAdd()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                const string animalName = "Guillermo";

                var animalToAdd = new Animal
                {
                    AnimalType = "Frog",
                    Breed = "African Dwarf",
                    Color = "Grey",
                    DateOfBirth = new DateTime(2020, 12, 25),
                    IncomeType = "Newborn",
                    OutcomeType = "Adoption",
                    SexUponIncome = "Intact Male",
                    SexUponOutcome = "Intact Male",
                    Name = animalName
                };

                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act
                animalMaintenanceAccessor
                    .AddAnimal(animalToAdd);

                // Assert
                Assert.NotNull(animalMaintenanceDatabaseContext
                    .Animals
                    .FirstOrDefault(animal => animal.Name.Equals(animalName)));
            }
        }

        [Fact]
        public void UpdateAnimal_NoAnimalToUpdate_ShouldThrowDbUpdateException()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act & Assert
                Assert.Throws<DbUpdateException>(() => animalMaintenanceAccessor
                    .UpdateAnimal(new Animal{Id = 1000}));
            }
        }

        [Fact]
        public void UpdateAnimal_ValidAnimalFound_ShouldUpdateWithNewProperties()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                const string animalName = "Leroy";

                var animalToAdd = new Animal
                {
                    AnimalType = "Frog",
                    Breed = "African Dwarf",
                    Color = "Grey",
                    DateOfBirth = new DateTime(2020, 12, 25),
                    IncomeType = "Newborn",
                    OutcomeType = "Adoption",
                    SexUponIncome = "Intact Male",
                    SexUponOutcome = "Intact Male",
                    Name = animalName
                };

                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                animalMaintenanceAccessor
                    .AddAnimal(animalToAdd);

                // Get added entity from in memory db and update properties
                var addedEntity = animalMaintenanceDatabaseContext
                    .Animals
                    .FirstOrDefault(animal => animal.Name.Equals(animalName));

                Assert.NotNull(addedEntity);

                // Update properties
                addedEntity
                    .Color = "Green";

                // Act: Perform update
                animalMaintenanceAccessor
                    .UpdateAnimal(addedEntity);

                // Assert
                Assert.NotNull(
                    animalMaintenanceDatabaseContext
                        .Animals
                        .FirstOrDefault(animal => animal.Color.Equals("Green")));
            }
        }

        [Fact]
        public void DeleteAnimal_NoAnimalToDelete_ShouldThrowDbUpdateException()
        {
            // Arrange
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                // Act & Assert
                Assert.Throws<DbUpdateException>(() => animalMaintenanceAccessor
                    .DeleteAnimal(5000));
            }
        }

        [Fact]
        public void DeleteAnimal_ValidEntityFound_ShouldRemoveFromDatabase()
        {
            using (var animalMaintenanceDatabaseContext = new AnimalMaintenanceDatabaseContext(DbContextOptions))
            {
                const string animalName = "Dixon";

                var animalToAdd = new Animal
                {
                    AnimalType = "Frog",
                    Breed = "African Dwarf",
                    Color = "Grey",
                    DateOfBirth = new DateTime(2020, 12, 25),
                    IncomeType = "Newborn",
                    OutcomeType = "Adoption",
                    SexUponIncome = "Intact Male",
                    SexUponOutcome = "Intact Male",
                    Name = animalName
                };

                var animalMaintenanceAccessor = new AnimalMaintenanceAccessor(
                    animalMaintenanceDatabaseContext);

                animalMaintenanceAccessor
                    .AddAnimal(animalToAdd);

                var addedAnimalId = animalMaintenanceDatabaseContext
                    .Animals
                    .FirstOrDefault(animal => animal.Name.Equals(animalName))?
                    .Id;

                Assert.NotNull(addedAnimalId);

                // Act
                animalMaintenanceAccessor
                    .DeleteAnimal(addedAnimalId.Value);

                // Assert
                Assert.Null(
                    animalMaintenanceDatabaseContext
                        .Animals
                        .FirstOrDefault(animal => animal.Id.Equals(addedAnimalId)));
            }
        }
    }
}