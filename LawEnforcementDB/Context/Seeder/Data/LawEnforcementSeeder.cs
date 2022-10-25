using LawEnforcementDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementDB.Context.Seeder.Data
{
    public static class LawEnforcementSeeder
    {
        public static void SeedLawEnforcement(this ModelBuilder modelBuilder)
        {
            List<LawEnforcementModel> lawEnforcementModels = new List<LawEnforcementModel>();

            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "AAS11421", EnforcementRank = "SERGEANT" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "AGF66633", EnforcementRank = "LIEUTENANT" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "ANC66431", EnforcementRank = "CAPTAIN" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "AZZ33405", EnforcementRank = "CORPORAL" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "GDS11643", EnforcementRank = "PATROL OFFICER" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "HJS18891", EnforcementRank = "POLICE DETECTIVE" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "LUS33721", EnforcementRank = "SERGEANT" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "EES11521", EnforcementRank = "LIEUTENANT" });
            lawEnforcementModels.Add(new LawEnforcementModel() { LawEnforcementID = "XVS16321", EnforcementRank = "LIEUTENANT" });

            modelBuilder.Entity<LawEnforcementModel>().HasData(lawEnforcementModels);
        }
    }
}
