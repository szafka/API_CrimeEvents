using LawEnforcementDB.Entities;

namespace LawEnforcement.DTO
{
    public class LawEnforcementReadDTO
    {
        public string LawEnforcementID { get; set; } = null!;
        public string EnforcementRank { get; set; } = null!;
        public ICollection<string> CrimeEventList { get; set; } = null!;
    }
}
