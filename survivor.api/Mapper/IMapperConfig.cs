using AutoMapper;
using survivor.api.Entity;
using survivor.api.Model;

namespace survivor.api.Mapper
{
    public class IMapperConfig : Profile
    {
        public IMapperConfig()
        {
            CreateMap<UserSurvivorModel, UserSurvivor>();
        }
    }
}
