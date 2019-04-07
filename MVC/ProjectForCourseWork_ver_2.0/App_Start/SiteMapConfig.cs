using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectForCourseWork_ver_2._0.App_Start
{
    public static class SiteMapConfig
    {
        /// <summary>
        /// Инициализирует SiteMap и добавляет его в коллекцию карт сайта
        /// </summary>
        /// <param name="siteMap">Экземпляр карты сайта(меню)</param>
        /// <param name="needSortMenuItems">Нужно ли отсортировать элементы меню</param>
        public static void ConfigureSiteMap(XmlSiteMap siteMap, bool needSortMenuItems = true)
        {
            if (needSortMenuItems)
                SortMenuItems(siteMap.RootNode);
            if (!SiteMapManager.SiteMaps.ContainsKey("menu"))
                SiteMapManager.SiteMaps.Add("menu", siteMap);
        }

        /// <summary>
        /// Инициализирует SiteMap и добавляет его в коллекцию карт сайта
        /// </summary>
        /// <param name="siteMapPath">Путь до карты сайта(меню)</param>
        /// <param name="needSortMenuItems">Нужно ли отсортировать элементы меню</param>
        public static void ConfigureSiteMap(string siteMapPath, bool needSortMenuItems = true)
        {
            var map = new XmlSiteMap();
            map.LoadFrom(siteMapPath);
            ConfigureSiteMap(map, needSortMenuItems);
        }

        /// <summary>
        /// Рекурсивный метод для сортировки элементов меню
        /// </summary>
        /// <param name="node">Элемент меню</param>
        private static void SortMenuItems(SiteMapNode node)
        {
            foreach (var item in node.ChildNodes)
            {
                SortMenuItems(item);
                var temp = new List<SiteMapNode>(item.ChildNodes.OrderBy(i => i.Title));
                item.ChildNodes.Clear();
                item.ChildNodes.AddRange(temp);
            }
        }
    }
}