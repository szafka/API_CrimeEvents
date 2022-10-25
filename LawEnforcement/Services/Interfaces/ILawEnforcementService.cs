using LawEnforcement.DTO;

namespace LawEnforcement.Services.Interfaces
{
    public interface ILawEnforcementService
    {
        Task<IEnumerable<LawEnforcementReadDTO>> GetAllAsync();
        Task AddNewEnforcement(LawEnforcementCreateDTO createDTO);
        Task DeleteAllAsync();
    }
}
