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
        
        public async Task<IReadOnlyCollection<Admin>> GetAll()
        {
            return await _databaseContext.Admins.AsNoTracking()
                .Include(admin => admin.Role)
                .ToArrayAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _databaseContext.Admins.AsNoTracking()
                .Include(admin => admin.Role)
                .FirstOrDefaultAsync(admin => admin.Id == id);
        }
    }
}