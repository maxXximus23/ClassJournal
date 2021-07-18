using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassJournal.Domain.Auth;
using ClassJournal.Dto.Requests;

namespace ClassJournal.DataAccess.Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<IReadOnlyCollection<Admin>> GetAll(PagingDto pagingDto);
        Task<Admin> GetById(int id);

        void Remove(Admin admin);

        Task<int> Count();

        void AddAdmin(Admin admin);
    }
}