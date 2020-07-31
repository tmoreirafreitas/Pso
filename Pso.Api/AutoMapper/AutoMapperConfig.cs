using AutoMapper;

namespace Pso.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToInputModelMappingProfile());
                cfg.AddProfile(new InputModelToCommandMappingProfile());
                cfg.AddProfile(new DomainToViewModelMappingProfile());
            });
        }
    }
}
