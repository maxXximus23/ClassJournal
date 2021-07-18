using AutoMapper;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.DataAccess.Repositories.Contracts;

namespace ClassJournal.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _roleRepository = repository;
            _mapper = mapper;
        }
        
        public int GetRoleIdByName(string name)
        {
            return _roleRepository.GetRoleByName(name).Id;
        }
    }
}