using AutoMapper;
using LawEnforcement.DTO;
using LawEnforcement.Services.Interfaces;
using LawEnforcementDB.DAL.Repositories.Interfaces;
using LawEnforcementDB.Entities;

namespace LawEnforcement.Services
{
    public class LawEnforcementService : ILawEnforcementService
    {
        private readonly ILawEnforcementRepository _repository;
        private readonly IMapper _mapper;
        public LawEnforcementService(ILawEnforcementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddNewEnforcement(LawEnforcementCreateDTO createDTO)
        {
            var newEnforcement = _mapper.Map<LawEnforcementModel>(createDTO);
            await _repository.AddEnforcementAsync(newEnforcement);
        }

        public async Task AssignEventAsync(LawEnforcementUpdateDTO updateDTO)
        {
            var crimeEvent = new CrimeEvent { Id = updateDTO.Id, LawEnforcementModelLawEnforcementID = updateDTO.LawEnforcementID };
            await _repository.AddCrimeEventAsync(crimeEvent);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }

        public async Task<IEnumerable<LawEnforcementReadDTO>> GetAllAsync()
        {
            var enforcementList = await _repository.GetAllEnforcementsAsync();
            return _mapper.Map<IEnumerable<LawEnforcementReadDTO>>(enforcementList);
        }
    }
}
