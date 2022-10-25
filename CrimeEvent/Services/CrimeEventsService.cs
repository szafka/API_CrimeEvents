using AutoMapper;
using CrimeEvent.DTO;
using CrimeEvent.Services.Interfaces;
using CrimeEventsMongoDB.DAL.Repositories.Interfaces;
using CrimeEventsMongoDB.Entities;

namespace CrimeEvent.Services
{
    public class CrimeEventsService : ICrimeEventsService
    {
        private readonly ICrimeEventRepository _repository;
        private readonly IMapper _mapper;
        public CrimeEventsService(ICrimeEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddNewEvent(CrimeEventCreateDTO createDTO)
        {
            var newCrimeEvent = _mapper.Map<CrimeEventModel>(createDTO);
            await _repository.AddItemAsync(newCrimeEvent);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }

        public async Task<IEnumerable<CrimeEventReadDTO>> GetAllAsync()
        {
            var crimeEvents = await _repository.GetItemsAsync();
            return _mapper.Map<IEnumerable<CrimeEventReadDTO>>(crimeEvents);
        }
    }
}
