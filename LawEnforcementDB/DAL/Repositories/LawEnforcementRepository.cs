using LawEnforcementSqlDB.Context;
using LawEnforcementSqlDB.DAL.Repositories.Interfaces;
using LawEnforcementSqlDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementSqlDB.DAL.Repositories
{
    public class LawEnforcementRepository : ILawEnforcementRepository
    {
        private readonly LawEnforcementContext _context;
        public LawEnforcementRepository(LawEnforcementContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LawEnforcementModel model)
        {
            string id = await IdGenerator();
        }
        public async Task<IEnumerable<LawEnforcementModel>> GetAllAsync()
        {
            var events = from entry in _context.LawEnforcementModels select entry;
            return events;
        }
        private async Task<string> IdGenerator()
        {
            string numberToBase;
            do
            {
                string randomId = Guid.NewGuid().ToString();
                numberToBase = randomId.Substring(0, 7);
                var numberFromBase = await _context.LawEnforcementModels.FirstOrDefaultAsync(c => c.EnforcementId == numberToBase);
                if (numberFromBase == null)
                    return numberToBase;
            }while (false);
            return numberToBase;
        }
    }
}
