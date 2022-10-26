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
        private readonly IHttpClientFactory _httpFactory;
        private readonly Random _random = new();
        public CrimeEventsService(ICrimeEventRepository repository, IMapper mapper, IHttpClientFactory httpFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _httpFactory = httpFactory;
        }

        public async Task AddNewEvent(CrimeEventCreateDTO createDTO)
        {
            var client = _httpFactory.CreateClient("Gateway");
            var enforcementsList = await client.GetFromJsonAsync<IEnumerable<LawEnforcementReadDTO>>($"api/LawEnforcementController/");
            var rnd = _random.Next(enforcementsList.Count());
            string enforcementToAssign = enforcementsList.ElementAt(rnd).LawEnforcementID.ToString();

            var assignedCrimeEvent = new CrimeEventWithEnforcementCreateDTO
            {
                Description = createDTO.Description,
                Email = createDTO.Email,
                PlaceOfEvent = createDTO.PlaceOfEvent,
                TypeOfEvent = createDTO.TypeOfEvent,
                DateOfReport = createDTO.DateOfReport,
                LawEnforcementID = enforcementToAssign
            };
            var newCrimeEvent = _mapper.Map<CrimeEventModel>(assignedCrimeEvent);
            await _repository.AddItemAsync(newCrimeEvent);

            var officerUpdate = new LawEnforcementUpdateDTO { LawEnforcementID = enforcementToAssign, Id = newCrimeEvent.Id };

            await client.PutAsJsonAsync($"api/LawEnforcementController/assignEvent", officerUpdate);

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
