namespace AnimalMaintenance.Managers.Tests.Mapping
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using Managers.Mapping;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class AnimalMappingProfileTests
    {
        // Setup local instance of AutoMapper for Unit Testing.
        private IMapper Mapper
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(
                    config => config.AddProfile<AnimalMappingProfile>());

                return mapperConfiguration
                    .CreateMapper();
            }
        }

        /// <summary>
        /// This unit test is responsible for asserting that AutoMapper's mapping configuration is properly setup.
        /// This will also catch any unmapped properties and fail if something is not explicitly mapped.
        /// </summary>
        [Fact]
        public void AnimalMappingProfile_AssertConfigurationIsValid()
        {
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void Animal_Entity_To_DataTransferObject_ShouldMap()
        {
            // Arrange
            var animalEntity = new Accessors.Entities.Animal
            {
                Id = 1,
                Name = "Yoshi",
                Color = "White and Black",
                AnimalType = "Cat",
                Breed = "Domestic Longhair",
                DateOfBirth = new DateTime(2016, 04, 20),
                IncomeType = "Stray",
                OutcomeType = "Adoption",
                SexUponIncome = "Intact Male",
                SexUponOutcome = "Neutered Male"
            };

            // Act
            var animalDto = Mapper.Map<Managers.DataTransferObjects.Animal>(animalEntity);

            // Assert
            Assert.Equal(animalEntity.Id, animalDto.Id);
            Assert.Equal(animalEntity.Name, animalDto.Name);
            Assert.Equal(animalEntity.Color, animalDto.Color);
            Assert.Equal(animalEntity.AnimalType, animalDto.AnimalType);
            Assert.Equal(animalEntity.Breed, animalDto.Breed);
            Assert.Equal(animalEntity.DateOfBirth, animalDto.DateOfBirth);
            Assert.Equal(animalEntity.IncomeType, animalDto.IncomeType);
            Assert.Equal(animalEntity.OutcomeType, animalDto.OutcomeType);
            Assert.Equal(animalEntity.SexUponIncome, animalDto.SexUponIncome);
            Assert.Equal(animalEntity.SexUponOutcome, animalDto.SexUponOutcome);
        }
    }
}