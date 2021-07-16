using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;

namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IAdminService
    {
        Task<PagingResultDto<AdminDto>> GetAll(PagingDto pagingDto);

        Task<AdminDto> GetById(int id);

        void AddAdmin(RegisterAdminUserDto adminDto);

        int GetRoleIdByName(string name);
    }
}