using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Dto.Users;
using ClassJournal.Shared.Extensions;

namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IAdminService
    {
        Task<PagedList<AdminDto>> GetAll(AdminParametersDto adminParameters);

        Task<AdminDto> GetById(int id);

        void AddAdmin(RegisterAdminUserDto adminDto);

        int GetRoleIdByName(string name);
    }
}