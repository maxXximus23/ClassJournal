using System.Collections.Generic;

namespace ClassJournal.Api.Models.Requests
{
    public class PagingResultModel<TApiModel>
    {
        public IReadOnlyCollection<TApiModel> Items { get; init; }
        public int TotalCount { get; init; }
    }
}