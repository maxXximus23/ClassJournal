using System.Threading.Tasks;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;

namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IAdminService
    {
        Task<PagingResultDto<AdminDto>> GetAll(PagingDto pagingDto);

        Task<AdminDto> GetById(int id);

        void DeleteById(int id);

        void AddAdmin(RegisterAdminUserDto adminDto);
    }
}