
using LawEnforcementDB.Entities;
using System.ComponentModel.DataAnnotations;

namespace LawEnforcementSqlDB.Entities
{
    public record LawEnforcementModel
    {
        [Key]
        [StringLength(8, MinimumLength = 7)]
        public string EnforcementId { get; set; } = null!;
        [StringLength(15, MinimumLength = 1)]
        public string EnforcementRank { get; set; } = null!;
        public ICollection<CrimeEventModel> CrimeEventList { get; set; } = null!;
    }
}
