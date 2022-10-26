using LawEnforcementDB.Entities;

namespace LawEnforcement.DTO
{
    public class CrimeEventReadDTO
    {
        public ICollection<CrimeEventReadDTO> CrimeEventList { get; set; } = null!;
    }
}
