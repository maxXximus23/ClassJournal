using System.Linq;
using ClassJournal.Dto.Requests;
using ClassJournal.Dto.Users;

namespace ClassJournal.Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Limit<TEntity>(this IQueryable<TEntity> items, PagingDto pagingDto)
        {
            return items.Skip(pagingDto.Offset).Take(pagingDto.Take);
        }
    }
}