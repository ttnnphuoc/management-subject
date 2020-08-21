using System.Web.Mvc;
using System.Web.Routing;

namespace ElearningSubject_v3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "test",
              url: "{Authorize}",
              defaults: new { controller = "Subjects", action = "Authorize", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Accounts", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
