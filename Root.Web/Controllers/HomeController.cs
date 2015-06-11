using System.Web.Mvc;
using Hangerd.Mvc;
using Root.Application.Services;

namespace Root.Web.Controllers
{
	public class HomeController : HangerdController
	{
		private readonly ISearchService _searchService;

		public HomeController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		public ActionResult Index()
		{
			ViewBag.TotalNumber = _searchService.GetTotalNumberOfWords();

			return View();
		}
	}
}
