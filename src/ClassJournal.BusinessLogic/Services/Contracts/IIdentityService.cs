using System.Threading.Tasks;
using ClassJournal.BusinessLogic.Services.Contracts.Models;
using ClassJournal.Dto.Users;

namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IIdentityService
    {
        Task<AuthResult> Register(RegisterUserDto registerUserDto);
        Task<AuthResult> Login(LoginUserDto loginUserDto);
    }
}