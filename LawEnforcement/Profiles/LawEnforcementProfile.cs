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
        }
    }
}
