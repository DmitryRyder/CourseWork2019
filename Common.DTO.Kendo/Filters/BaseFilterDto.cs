using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.DTO;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;

namespace Common.Filters
{
    public class BaseFilterDto : BaseDto
    {
        public DataSourceRequest Request { get; set; } = new DataSourceRequest
        {
            Sorts = new List<SortDescriptor>(),
            Page = 1,
            PageSize = 50
        };

        public (IEnumerable, IEnumerable<AggregateResult>) ApplyGroupingAndAggregates<T>(IEnumerable<T> data)
        {
            Request.Page = default;
            Request.Sorts = default;
            Request.PageSize = int.MaxValue;
            var result = data?.AsQueryable()
                             .ToDataSourceResult(Request);
            return (result?.Data, result?.AggregateResults);
        }
    }
}
