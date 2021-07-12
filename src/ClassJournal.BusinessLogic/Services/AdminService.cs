using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        public async Task<IReadOnlyCollection<AdminDto>> GetAll(AdminParametersDto adminParametersDto)
        {
            IReadOnlyCollection<Admin> admins = await _adminRepository.GetAll(
                _mapper.Map<AdminParametersDto, AdminParameters>(adminParametersDto));
            return _mapper.MapCollection<Admin, AdminDto>(admins);
        }

        public async Task<AdminDto> GetById(int id)
        {
            Admin admin = await _adminRepository.GetById(id);
            return _mapper.Map<Admin, AdminDto>(admin);
        }

        public void AddAdmin(RegisterAdminUserDto adminDto)
        {
            Role role = _adminRepository.GetRoleByName(adminDto.Role);
            if (role == null)
            {
                throw new ValidationException($"Role '{adminDto.Role}' does not exist!");
            }
            
            Admin admin = _mapper.Map<RegisterAdminUserDto, Admin>(adminDto);
            admin.RoleId = role.Id;
            _adminRepository.AddAdmin(admin);
        }

        //TODO: Move to RoleService
        public int GetRoleIdByName(string name)
        {
            return _adminRepository.GetRoleByName(name).Id;
        }
    }
}