using ProjectForCourseWork_ver_2._0.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectForCourseWork_ver_2._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("", "Main/Buildings/{id}", new
            {
                controller = "Main",
                action = nameof(MainController.Buildings)
            });

            routes.MapRoute("", "Main/Rooms/{id}", new
            {
                controller = "Main",
                action = nameof(MainController.Rooms)
            });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Buildings", id = UrlParameter.Optional }
            );
        }
    }
}
