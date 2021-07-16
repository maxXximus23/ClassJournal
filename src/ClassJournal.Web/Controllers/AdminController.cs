using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;
using ClassJournal.Web.Models.Requests;
using ClassJournal.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClassJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminsController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<PagingResultModel<Admin>> GetAllAdmins([FromQuery] PagingModel pagingModel)
        {
            var pagingDto = _mapper.Map<PagingModel, PagingDto>(pagingModel);

            PagingResultDto<AdminDto> pagingResultDto =
                await _adminService.GetAll(pagingDto);
            
            return _mapper.Map<PagingResultDto<AdminDto>, PagingResultModel<Admin>>(pagingResultDto);
        }
        
        [HttpGet("{id}")]
        public async Task<AdminModel> GetAdminById([FromRoute] int id)
        {
            return _mapper.Map<AdminDto, AdminModel>(await _adminService.GetById(id));
        }
        
        [HttpPost("addadmin")]
        public void AddAdmin([FromBody] RegisterAdminUserModel adminUser)
        {
            RegisterAdminUserDto adminDto = _mapper.Map<RegisterAdminUserModel, RegisterAdminUserDto>(adminUser);
            _adminService.AddAdmin(adminDto);
        }
    }
}