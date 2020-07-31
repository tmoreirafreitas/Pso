using AutoMapper;

namespace Pso.Domain.Core.AutoMapper
{
    public class AutoMapperMediatRConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToDomainMappingProfile());
                cfg.AddProfile(new DomainToCommandMappingProfile());
            });
        }
    }
}
