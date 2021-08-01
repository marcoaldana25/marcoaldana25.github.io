namespace AnimalMaintenance.Managers.Tests.Mapping
{
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

        [Fact]
        public void AnimalMappingProfile_AssertConfigurationIsValid()
        {

        }
    }
}