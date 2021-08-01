namespace AnimalMaintenance.Managers.Mapping
{
    using AutoMapper;

    public class AnimalMappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile responsible for converting Animal Entity to an Animal Data Transfer Object.
        /// Mapping profile also handles conversion from Animal Data Transfer Object to Animal Enity
        /// per ReverseMap()
        /// </summary>
        public AnimalMappingProfile()
        {
            CreateMap<Accessors.Entities.Animal, DataTransferObjects.Animal>()
                .ReverseMap();
        }
    }
}