using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Dto.Users;

namespace ClassJournal.BusinessLogic.Services.Contracts
{
    public interface IAdminService
    {
        Task<IReadOnlyCollection<AdminDto>> GetAll();

        Task<AdminDto> GetById(int id);
    }
}