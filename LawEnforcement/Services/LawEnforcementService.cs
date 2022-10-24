using LawEnforcement.DTO;
using LawEnforcement.Services.Interfaces;

namespace LawEnforcement.Services
{
    public class LawEnforcementService : ILawEnforcementService
    {
        public Task AddNewEnforcement(LawEnforcementCreateDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LawEnforcementReadDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
