using LawEnforcementDB.Context;
using LawEnforcementDB.DAL.Repositories.Interfaces;
using LawEnforcementDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcementDB.DAL.Repositories
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
            var newModel = model with { LawEnforcementID = id };
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
                var numberFromBase = await _context.LawEnforcementModels.FirstOrDefaultAsync(c => c.LawEnforcementID == numberToBase);
                if (numberFromBase == null)
                    return numberToBase;
            }while (false);
            return numberToBase;
        }
    }
}
