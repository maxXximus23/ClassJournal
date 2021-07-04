using System.Text.Json;
using System.Threading.Tasks;
using ClassJournal.Api.Users;
using ClassJournal.BusinessLogic.Services.Contracts;
using ClassJournal.BusinessLogic.Services.Contracts.Models;
using ClassJournal.Dto.Users;
using Microsoft.AspNetCore.Mvc;

namespace ClassJournal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserInfoService _userInfo;

        public IdentityController(IIdentityService identityService, IUserInfoService userInfo)
        {
            _identityService = identityService;
            _userInfo = userInfo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel registerModel)
        {
            var registerDto = new RegisterUserDto()
            {
                Password = registerModel.Password,
                RoleId = registerModel.RoleId,
                UserName = registerModel.UserName
            };
            
            AuthResult result = await _identityService.Register(registerDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
        {
            var loginUserDto = new LoginUserDto()
            {
                Password = loginUserModel.Password,
                Username = loginUserModel.Username
            };
            
            AuthResult result = await _identityService.Login(loginUserDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
        
        
        [HttpGet("info")]
        public IUserInfoService UserInfo()
        {
            return _userInfo;
        }
    }
}