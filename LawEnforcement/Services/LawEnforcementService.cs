using AutoMapper;
using LawEnforcement.DTO;
using LawEnforcement.Services.Interfaces;
using LawEnforcementSqlDB.DAL.Repositories.Interfaces;
using LawEnforcementSqlDB.Entities;

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
