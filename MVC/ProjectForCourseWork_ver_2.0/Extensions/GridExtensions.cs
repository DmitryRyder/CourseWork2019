using Kendo.Mvc.UI.Fluent;
using System;
using Common.Extensions;
using Kendo.Mvc.UI;

namespace ProjectForCourseWork_ver_2._0.Extensions
{
    public static class GridExtensions
    {
        public static GridBuilder<T> BackGrid<T>(this GridBuilder<T> grid) where T : class
        {
            return grid
                  .ColumnMenu(m => m.Enabled(true)
                                    .Sortable(true))
                  .Resizable(r => r.Columns(true))
                  .Selectable(s => s.Enabled(false))
                  .Sortable()
                  .Pageable(p => p
                                .PageSizes(new[]
                                 {
                                     10, 20, 50, 100, 200,
                                     500, 1000
                                 })
                                .Refresh(true)
                                .Messages(m =>
                                {
                                    m.Display("{0} - {1} из {2} элементов");
                                    m.ItemsPerPage("элементов на странице");
                                    m.Empty("Нет элементов для отображения");
                                }));
        }
    }
}