namespace AnimalMaintenance.Managers.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Accessors;
    using AutoMapper;
    using DataTransferObjects;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AnimalMaintenanceManagerTests
    {
        [Fact]
        public void GetAnimals_ShouldReturnListOfAllAnimals()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<List<Animal>>(It.IsAny<List<Accessors.Entities.Animal>>()))
                .Returns(new List<Animal>());

            var mockAnimalMaintenanceAccessor = new Mock<IAnimalMaintenanceAccessor>(MockBehavior.Strict);
            mockAnimalMaintenanceAccessor
                .Setup(accessor => accessor.GetAnimals())
                .Returns(new List<Accessors.Entities.Animal>());

            var animalMaintenanceManager = new AnimalMaintenanceManager(
                mockAnimalMaintenanceAccessor.Object,
                mockMapper.Object);

            // Act
            var allAnimals = animalMaintenanceManager
                .GetAnimals();

            // Since no values are mocked to return, verify allAnimals is simply not null and verify calls made.
            // Assert
            Assert.NotNull(allAnimals);

            mockMapper
                .Verify(
                    mapper => mapper.Map<List<Animal>>(It.IsAny<List<Accessors.Entities.Animal>>()),
                    Times.Once);

            mockAnimalMaintenanceAccessor
                .Verify(
                    accessor => accessor.GetAnimals(),
                    Times.Once);
        }

        [Fact]
        public void GetAnimal_ShouldReturnAnimalDataTransferObject()
        {
            // Arrange
            var mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockMapper
                .Setup(mapper => mapper.Map<Animal>(It.IsAny<Accessors.Entities.Animal>()))
                .Returns(new Animal());

            var mockAnimalMaintenanceAccessor = new Mock<IAnimalMaintenanceAccessor>(MockBehavior.Strict);
            mockAnimalMaintenanceAccessor
                .Setup(accessor => accessor.GetAnimal(It.IsAny<int>()))
                .Returns(new Accessors.Entities.Animal());

            var animalMaintenanceManager = new AnimalMaintenanceManager(
                mockAnimalMaintenanceAccessor.Object,
                mockMapper.Object);

            // Act
            var animal = animalMaintenanceManager
                .GetAnimal(1);

            // Assert
            Assert.NotNull(animal);

            mockMapper
                .Verify(
                    mapper => mapper.Map<Animal>(It.IsAny<Accessors.Entities.Animal>()),
                    Times.Once);

            mockAnimalMaintenanceAccessor
                .Verify(
                    accessor => accessor.GetAnimal(It.IsAny<int>()),
                    Times.Once);
        }
    }
}