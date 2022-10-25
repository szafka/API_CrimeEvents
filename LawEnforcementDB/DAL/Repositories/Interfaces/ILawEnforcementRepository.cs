using LawEnforcementDB.Entities;

namespace LawEnforcementDB.DAL.Repositories.Interfaces
{
    public interface ILawEnforcementRepository
    {
        Task AddEnforcementAsync(LawEnforcementModel model);
        Task<IEnumerable<LawEnforcementModel>> GetAllEnforcementsAsync();
        Task DeleteAllAsync();
    }
}
