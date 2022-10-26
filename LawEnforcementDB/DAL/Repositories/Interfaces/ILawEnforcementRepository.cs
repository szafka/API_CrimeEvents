using LawEnforcementDB.Entities;

namespace LawEnforcementDB.DAL.Repositories.Interfaces
{
    public interface ILawEnforcementRepository
    {
        Task AddEnforcementAsync(LawEnforcementModel model);
        Task AddCrimeEventAsync(CrimeEvent model);
        Task<IEnumerable<LawEnforcementModel>> GetAllEnforcementsAsync();
        Task DeleteAllAsync();
    }
}
