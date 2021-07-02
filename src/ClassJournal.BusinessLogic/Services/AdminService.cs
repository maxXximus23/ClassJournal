using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassJournal.BusinessLogic.Mapping;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.DataAccess.Repositories.Contracts;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;

namespace ClassJournal.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository repository, IMapper mapper)
        {
            _adminRepository = repository;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<AdminDto>> GetAll()
        {
            IReadOnlyCollection<Admin> admins = await _adminRepository.GetAll();
            return _mapper.MapCollection<Admin, AdminDto>(admins);
        }

        public async Task<AdminDto> GetById(int id)
        {
            Admin admin = await _adminRepository.GetById(id);
            return _mapper.Map<Admin, AdminDto>(admin);
        }
    }
}