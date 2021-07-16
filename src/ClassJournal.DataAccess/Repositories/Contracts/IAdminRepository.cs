using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;

namespace ClassJournal.DataAccess.Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<IReadOnlyCollection<Admin>> GetAll(PagingDto pagingDto);
        Task<Admin> GetById(int id);

        Task<int> Count();

        void AddAdmin(Admin admin);

        Role GetRoleByName(string name);
    }
}