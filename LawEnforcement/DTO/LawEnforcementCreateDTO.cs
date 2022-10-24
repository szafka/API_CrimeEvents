using System.ComponentModel.DataAnnotations;

namespace LawEnforcement.DTO
{
    public class LawEnforcementCreateDTO
    {
        [StringLength(15, MinimumLength = 1)]
        public string EnforcementRank { get; set; } = null!;
    }
}
