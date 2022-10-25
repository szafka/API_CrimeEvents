
using LawEnforcementDB.Entities;
using System.ComponentModel.DataAnnotations;

namespace LawEnforcementDB.Entities
{
    public record LawEnforcementModel
    {
        [Key]
        [StringLength(8, MinimumLength = 7)]
        public string LawEnforcementID { get; set; } = null!;
        [StringLength(25, MinimumLength = 1)]
        public string EnforcementRank { get; set; } = null!;
        public ICollection<CrimeEventModel> CrimeEventList { get; set; } = null!;
    }
}
