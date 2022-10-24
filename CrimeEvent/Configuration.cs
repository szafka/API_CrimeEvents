using CrimeEvent.Profiles;
using CrimeEvent.Services;
using CrimeEvent.Services.Interfaces;
using CrimeEventsMongoDB.DAL.Repositories;
using CrimeEventsMongoDB.DAL.Repositories.Interfaces;

namespace CrimeEvent
{
    public static class Configuration
    {
        public static void AddProfilesCollection(this IServiceCollection services)
        {
            var mapConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new CrimeEventProfile());
            });
            var mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddScopedConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICrimeEventRepository, CrimeEventRepository>();
            services.AddScoped<ICrimeEventsService, CrimeEventsService>();
        }
    }
}
