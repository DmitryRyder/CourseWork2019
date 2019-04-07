using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.UI;

namespace Common.Extensions
{
    public static class DataSourceResultExtensions
    {
        public static List<T> GetData<T>(this DataSourceResult result)
        {
            return result.Data.OfType<T>()
                         .ToList();
        }
    }
}
