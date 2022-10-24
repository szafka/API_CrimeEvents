using LawEnforcementSqlDB.Entities;

namespace LawEnforcementSqlDB.DAL.Repositories.Interfaces
{
    public interface ILawEnforcementRepository
    {
        Task AddAsync(LawEnforcementModel model);
        Task<IEnumerable<LawEnforcementModel>> GetAllAsync();
    }
}
