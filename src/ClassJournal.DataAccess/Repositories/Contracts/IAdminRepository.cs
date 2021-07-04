using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Domain.Auth;

namespace ClassJournal.DataAccess.Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<IReadOnlyCollection<Admin>> GetAll();
        Task<Admin> GetById(int id);

        void AddAdmin(Admin admin);

        Role GetRoleByName(string name);
    }
}