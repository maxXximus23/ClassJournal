using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassJournal.DataAccess.Extensions;
using ClassJournal.DataAccess.Repositories.Contracts;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;
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
        
        public async Task<IReadOnlyCollection<Admin>> GetAll(PagingDto pagingDto)
        {
            return await _databaseContext.Admins
                .AsNoTracking()
                .Include(admin => admin.Role)
                .Limit(pagingDto)
                .ToArrayAsync();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _databaseContext.Admins
                .AsNoTracking()
                .Include(admin => admin.Role)
                .FirstOrDefaultAsync(admin => admin.Id == id);
        }

        public void Remove(Admin admin)
        {
            _databaseContext.Admins.Remove(admin);
            _databaseContext.SaveChanges();
        }

        public void AddAdmin(Admin admin)
        {
            _databaseContext.Admins.Add(admin);
            _databaseContext.SaveChanges();
        }

        public async Task<int> Count()
        {
            return await _databaseContext.Admins
                .AsNoTracking()
                .CountAsync();
        }
    }
}