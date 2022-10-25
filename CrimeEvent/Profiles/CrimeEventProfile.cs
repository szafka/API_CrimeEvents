using AutoMapper;
using CrimeEvent.DTO;
using CrimeEventsMongoDB.Entities;

namespace CrimeEvent.Profiles
{
    public class CrimeEventProfile : Profile
    {
        public CrimeEventProfile()
        {
            CreateMap<CrimeEventModel, CrimeEventReadDTO>();
            CreateMap<CrimeEventCreateDTO, CrimeEventModel>();
            CreateMap<CrimeEventUpdateDTO, CrimeEventModel>();
        }
    }
}
