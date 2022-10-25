using LawEnforcement.Profiles;
using LawEnforcement.Services;
using LawEnforcement.Services.Interfaces;
using LawEnforcementSqlDB.DAL.Repositories;
using LawEnforcementSqlDB.DAL.Repositories.Interfaces;

namespace LawEnforcement
{
    public static class Configuration
    {
        public static void AddProfilesCollection(this IServiceCollection services)
        {
            var mapConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new LawEnforcementProfile());
            });
            var mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddScopedConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILawEnforcementRepository, LawEnforcementRepository>();
            services.AddScoped<ILawEnforcementService, LawEnforcementService>();
        }
    }
}
