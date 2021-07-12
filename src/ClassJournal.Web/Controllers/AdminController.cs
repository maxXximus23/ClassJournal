using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;
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
        public async Task<IActionResult> GetAllAdmins([FromQuery] AdminParametersModel adminParameters)
        {
            var adminsdata =
                await _adminService.GetAll(_mapper.Map<AdminParametersModel, AdminParametersDto>(adminParameters));
            
            var admins = _mapper.MapCollection<AdminDto, AdminModel>(adminsdata);
            
            var metadata = new
            {
                adminsdata.TotalCount,
                adminsdata.PageSize,
                adminsdata.CurrentPage,
                adminsdata.TotalPages,
                adminsdata.HasNext,
                adminsdata.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            
            return Ok(admins);
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