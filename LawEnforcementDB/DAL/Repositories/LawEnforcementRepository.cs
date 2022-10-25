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
        public async Task AddEnforcementAsync(LawEnforcementModel model)
        {
            string id = await IdGenerator();
            var newModel = model with { EnforcementId = id };
            await _context.AddAsync(newModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            foreach(var data in _context.LawEnforcementModels)
            {
                _context.Remove(data);
            }
            _context.SaveChanges();
        }
        public async Task<IEnumerable<LawEnforcementModel>> GetAllEnforcementsAsync()
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
                numberToBase = randomId.Substring(0, 8);
                var numberFromBase = await _context.LawEnforcementModels.FirstOrDefaultAsync(c => c.EnforcementId == numberToBase);
                if (numberFromBase == null)
                    return numberToBase;
            }while (false);
            return numberToBase;
        }
    }
}
