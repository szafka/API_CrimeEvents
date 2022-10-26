using LawEnforcementDB.Context.Seeder.Data;
using LawEnforcementDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementDB.Context
{
    public class LawEnforcementContext : DbContext
    {
        public DbSet<LawEnforcementModel> LawEnforcementModels { get; set; } = null!;
        public DbSet<CrimeEvent> CrimeEvents { get; set; } = null!;
        public LawEnforcementContext(DbContextOptions<LawEnforcementContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.SeedLawEnforcement();
    }
}
