using LawEnforcementSqlDB.Context;
using LawEnforcementSqlDB.DAL.Repositories.Interfaces;
using LawEnforcementSqlDB.Entities;

namespace LawEnforcementSqlDB.DAL.Repositories
{
    public class LawEnforcementRepository : ILawEnforcementRepository
    {
        private readonly LawEnforcementContext _context;
        public LawEnforcementRepository(LawEnforcementContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LawEnforcementModel model) => await _context.AddRangeAsync(model);

        public async Task<IEnumerable<LawEnforcementModel>> GetAllAsync()
        {
            var events = from entry in _context.LawEnforcementModels select entry;
            return events;
        }
    }
}
