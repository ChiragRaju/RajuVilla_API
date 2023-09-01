using AutoMapper;
using Raju_VillaAPI.Models.DTO;
using Raju_VillaAPI.Models;

namespace Raju_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villas, VillaDTO>();
            CreateMap<VillaDTO, Villas>();

            CreateMap<Villas, VillaCreateDTO>().ReverseMap();
            CreateMap<Villas, VillaUpdateDTO>().ReverseMap();


        }
    }
}
