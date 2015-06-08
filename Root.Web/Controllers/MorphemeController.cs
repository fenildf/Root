using System.Linq;
using System.Web.Mvc;
using Hangerd.Mvc;
using Root.Application.DataObjects;
using Root.Application.Services;

namespace Root.Web.Controllers
{
	public class MorphemeController : HangerdController
	{
		private readonly ISearchService _searchService;
		private readonly IMaintainService _maintainService;

		public MorphemeController(
			ISearchService searchService,
			IMaintainService maintainService)
		{
			_searchService = searchService;
			_maintainService = maintainService;
		}

		public ActionResult New(string morpheme)
		{
			return View(morpheme as object);
		}

		[HttpPost]
		public ActionResult Add(MorphemeDto morphemeDto)
		{
			var result = _maintainService.AddMorpheme(morphemeDto);

			return OperationJsonResult(result);
		}

		[HttpPost]
		public ActionResult GetMorphemeList(string morpheme)
		{
			int totalCount;
			var morphemeList = _searchService.GetMorphemeList(morpheme, 10, out totalCount)
				.Select(m => new
				{
					m.Id,
					Value = m.ToString()
				});

			return JsonContent(morphemeList);
		}
	}
}
