using System.Threading.Tasks;
using AutoMapper;
using ClassJournal.Api.Models.Requests;
using ClassJournal.Api.Models.Users;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<PagingResultModel<AdminModel>> GetAllAdmins([FromQuery] PagingModel pagingModel)
        {
            var pagingDto = _mapper.Map<PagingModel, PagingDto>(pagingModel);

            PagingResultDto<AdminDto> pagingResultDto = await _adminService.GetAll(pagingDto);
            
            return _mapper.Map<PagingResultDto<AdminDto>, PagingResultModel<AdminModel>>(pagingResultDto);
        }
        
        [HttpGet("{id}")]
        public async Task<AdminModel> GetAdminById([FromRoute] int id)
        {
            return _mapper.Map<AdminDto, AdminModel>(await _adminService.GetById(id));
        }
        
        [HttpPost]
        public void AddAdmin([FromBody] RegisterAdminUserModel adminUser)
        {
            RegisterAdminUserDto adminDto = _mapper.Map<RegisterAdminUserModel, RegisterAdminUserDto>(adminUser);
            _adminService.AddAdmin(adminDto);
        }
    }
}