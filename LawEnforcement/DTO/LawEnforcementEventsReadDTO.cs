using LawEnforcementDB.Entities;

namespace LawEnforcement.DTO
{
    public class LawEnforcementEventsReadDTO
    {
        public ICollection<CrimeEventModel> CrimeEventList { get; set; } = null!;
    }
}
