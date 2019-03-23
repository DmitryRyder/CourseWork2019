using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace API
{
    public class RouteConfig
    {
        /// <summary>
        /// Route Builder
        /// </summary>
        /// <param name="routes"></param>
        public static void Configure(IRouteBuilder routes)
        {
            routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
        }
    }
}
