using System.ComponentModel.DataAnnotations;

namespace LawEnforcement.DTO
{
    public class LawEnforcementCreateDTO
    {
        [StringLength(8, MinimumLength = 7)]
        public string EnforcementRank { get; set; } = null!;
    }
}
