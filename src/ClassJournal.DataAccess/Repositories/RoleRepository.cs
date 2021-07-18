using System.Linq;
using ClassJournal.DataAccess.Repositories.Contracts;
using ClassJournal.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace ClassJournal.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RoleRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public Role GetRoleByName(string name)
        {
            return _databaseContext.Roles
                .AsNoTracking()
                .FirstOrDefault(role => role.Name == name);
        }
    }
}