using ClassJournal.Domain.Auth;

namespace ClassJournal.DataAccess.Repositories.Contracts
{
    public interface IRoleRepository
    {
        Role GetRoleByName(string name);
    }
}