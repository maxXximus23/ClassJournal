using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ClassJournal.BusinessLogic.Mapping;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.DataAccess.Repositories.Contracts;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;

namespace ClassJournal.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        
        public async Task<PagingResultDto<AdminDto>> GetAll(PagingDto pagingDto)
        {
            IReadOnlyCollection<Admin> admins = await _adminRepository.GetAll(pagingDto);

            return new PagingResultDto<AdminDto>()
            {
                Items = _mapper.MapCollection<Admin, AdminDto>(admins),
                TotalCount = await _adminRepository.Count()
            };
        }

        public async Task<AdminDto> GetById(int id)
        {
            Admin admin = await _adminRepository.GetById(id);
            return _mapper.Map<Admin, AdminDto>(admin);
        }

        public void DeleteById(int id)
        {
            AdminDto adminDto = GetById(id).Result;
            if (adminDto == null)
                throw new KeyNotFoundException($"Admin with id {id} has not found!");
            
            _adminRepository.Remove(_mapper.Map<AdminDto, Admin>(adminDto));
        }

        public void AddAdmin(RegisterAdminUserDto adminDto)
        {
            Role role = _roleRepository.GetRoleByName(adminDto.Role);
            if (role == null)
            {
                throw new ValidationException($"Role '{adminDto.Role}' does not exist!");
            }
            
            Admin admin = _mapper.Map<RegisterAdminUserDto, Admin>(adminDto);
            admin.RoleId = role.Id;
            _adminRepository.AddAdmin(admin);
        }
    }
}