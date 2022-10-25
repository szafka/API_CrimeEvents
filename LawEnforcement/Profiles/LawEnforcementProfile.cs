using AutoMapper;
using LawEnforcement.DTO;
using LawEnforcementSqlDB.Entities;

namespace LawEnforcement.Profiles
{
    public class LawEnforcementProfile : Profile
    {
        public LawEnforcementProfile()
        {
            CreateMap<LawEnforcementModel, LawEnforcementReadDTO>();
            CreateMap<LawEnforcementCreateDTO, LawEnforcementModel>();
            CreateMap<LawEnforcementModel, LawEnforcementEventsReadDTO>()
                .ForMember(x => x.CrimeEventList, opt => opt.MapFrom(e => e.CrimeEventList.Select(c => c.Id)));
        }
    }
}
