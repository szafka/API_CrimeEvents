using LawEnforcementSqlDB.Context.Seeder.Data;
using LawEnforcementSqlDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementSqlDB.Context
{
    public class LawEnforcementContext : DbContext
    {
        public DbSet<LawEnforcementModel> LawEnforcementModels { get; set; } = null!;
        public LawEnforcementContext(DbContextOptions<LawEnforcementContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.SeedLawEnforcement();
    }
}
