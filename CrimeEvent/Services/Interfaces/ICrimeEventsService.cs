using CrimeEvent.DTO;

namespace CrimeEvent.Services.Interfaces
{
    public interface ICrimeEventsService
    {
        Task AddNewEvent(CrimeEventCreateDTO createDTO);
        Task<IEnumerable<CrimeEventReadDTO>> GetAllAsync();
    }
}
