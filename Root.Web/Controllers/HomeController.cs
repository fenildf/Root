using System.Web.Mvc;
using Hangerd.Mvc;

namespace Root.Web.Controllers
{
	public class HomeController : HangerdController
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
