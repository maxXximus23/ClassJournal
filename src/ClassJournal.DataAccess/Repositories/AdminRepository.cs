using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassJournal.DataAccess.Repositories.Contracts;
using ClassJournal.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace ClassJournal.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AdminRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<IReadOnlyCollection<Admin>> GetAll(AdminParameters adminParameters)
        {
            return await _databaseContext.Admins.AsNoTracking()
                .Include(admin => admin.Role)
                .Skip((adminParameters.PageNumber - 1) * adminParameters.PageSize)
                .Take(adminParameters.PageSize)
                .ToArrayAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _databaseContext.Admins.AsNoTracking()
                .Include(admin => admin.Role)
                .FirstOrDefaultAsync(admin => admin.Id == id);
        }

        public void AddAdmin(Admin admin)
        {
            _databaseContext.Admins.Add(admin);
            _databaseContext.SaveChanges();
        }

        public Role GetRoleByName(string name)
        {
            return _databaseContext.Roles.AsNoTracking()
                .FirstOrDefault(role => role.Name == name);
        }
    }
}