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
        private readonly IHttpClientFactory _httpFactory;
        private readonly IMapper _mapper;
        private readonly Random _random = new Random();
        public CrimeEventsService(ICrimeEventRepository repository, IMapper mapper, IHttpClientFactory httpFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _httpFactory = httpFactory;
        }

        public async Task AddNewEvent(CrimeEventCreateDTO createDTO)
        {
            var newCrimeEvent = _mapper.Map<CrimeEventModel>(createDTO);
            await _repository.AddItemAsync(newCrimeEvent);
        }

        public async Task Assigning(CrimeEventCreateDTO createDTO)
        {
            Task.Delay(4000);
            var client = _httpFactory.CreateClient("Gateway");
            var enforcementsList = await client.GetFromJsonAsync<IEnumerable<LawEnforcementReadDTO>>($"api/LawEnforcementController/");
            var rnd = _random.Next(enforcementsList.Count());
            string enforcementToAssign = enforcementsList.ElementAt(rnd).LawEnforcementID.ToString();
            
            var assignedCrimeEvent = new CrimeEventUpdateDTO
            {
                Description = createDTO.Description,
                Email = createDTO.Email,
                PlaceOfEvent = createDTO.PlaceOfEvent,
                TypeOfEvent = createDTO.TypeOfEvent,
                DateOfReport = createDTO.DateOfReport,
                LawEnforcementID = enforcementToAssign
            };
            var newModel = _mapper.Map<CrimeEventModel>(assignedCrimeEvent);
            await _repository.UpdateItemAsync(newModel);
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
