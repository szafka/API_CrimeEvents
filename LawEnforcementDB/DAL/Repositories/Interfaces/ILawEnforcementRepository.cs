using LawEnforcementSqlDB.Entities;

namespace LawEnforcementSqlDB.DAL.Repositories.Interfaces
{
    public interface ILawEnforcementRepository
    {
        Task AddEnforcementAsync(LawEnforcementModel model);
        Task<IEnumerable<LawEnforcementModel>> GetAllEnforcementsAsync();
        Task DeleteAllAsync();
    }
}
