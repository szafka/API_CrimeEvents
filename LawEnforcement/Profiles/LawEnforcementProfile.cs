using AutoMapper;
using LawEnforcement.DTO;
using LawEnforcementDB.Entities;

namespace LawEnforcement.Profiles
{
    public class LawEnforcementProfile : Profile
    {
        public LawEnforcementProfile()
        {
            CreateMap<LawEnforcementModel, LawEnforcementReadDTO>()
                .ForMember(x => x.CrimeEventList, opt => opt.MapFrom(e => e.CrimeEventList.Select(c => c.Id)));;
            CreateMap<LawEnforcementCreateDTO, LawEnforcementModel>();
        }
    }
}
