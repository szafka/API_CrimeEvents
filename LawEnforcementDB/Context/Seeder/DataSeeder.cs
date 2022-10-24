using LawEnforcementSqlDB.Context.Seeder.Data;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementSqlDB.Context.Seeder
{
    public static class DataSeeder
    {
        public static void SeedDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedLawEnforcement();
        }
    }
}
