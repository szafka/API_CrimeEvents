﻿using LawEnforcementSqlDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementSqlDB.Context.Seeder.Data
{
    public static class LawEnforcementSeeder
    {
        public static void SeedLawEnforcement(this ModelBuilder modelBuilder)
        {
            List<LawEnforcementModel> lawEnforcementModels = new List<LawEnforcementModel>();
            string[] fileLines = File.ReadAllLines("../LawEnforcementSqlDB/Context/Seeder/Data/LawEnforcementData.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                lawEnforcementModels.Add(item);
            }
            modelBuilder.Entity<LawEnforcementModel>().HasData(lawEnforcementModels);
        }

        private static LawEnforcementModel GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            string id = item[0];
            string rank = item[1];
            return new LawEnforcementModel() { EnforcementId = id, EnforcementRank = rank };
        }
    }
}