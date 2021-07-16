using System.Collections.Generic;

namespace ClassJournal.Dto.Requests
{
    public class PagingResultDto<TDto>
    {
        public IReadOnlyCollection<TDto> Items { get; init; }
        public int TotalCount { get; init; }
    }
}