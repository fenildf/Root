using System.Web.Mvc;
using System.Web.Routing;

namespace Root.Web
{
	public static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"WordDetail",
				"word/detail/{word}",
				new { controller = "Word", action = "Detail", word = string.Empty }
				);

			routes.MapRoute(
				"WordModify",
				"word/modify/{word}",
				new { controller = "Word", action = "Modify", word = string.Empty }
				);

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = string.Empty }
				);
		}
	}
}
