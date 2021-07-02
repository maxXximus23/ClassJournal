using System.Collections.Generic;
using AutoMapper;

namespace ClassJournal.Shared.Extensions
{
    public static class MappingExtensions
    {
        public static IReadOnlyCollection<TTarget> MapCollection<TSource, TTarget>(this IMapper mapper, 
            IReadOnlyCollection<TSource> items)
        {
            return mapper.Map<IReadOnlyCollection<TSource>, IReadOnlyCollection<TTarget>>(items);
        }
    }
}