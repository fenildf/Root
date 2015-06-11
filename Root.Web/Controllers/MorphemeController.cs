using System.Linq;
using System.Web.Mvc;
using Hangerd.Mvc;
using Hangerd.Mvc.ViewModels;
using Hangerd.Utility;
using Root.Application.DataObjects;
using Root.Application.Services;
using Root.Web.Models;

namespace Root.Web.Controllers
{
	public class MorphemeController : HangerdController
	{
		private const int MorphemeListSize = 40;

		private readonly ISearchService _searchService;
		private readonly IMaintainService _maintainService;

		public MorphemeController(
			ISearchService searchService,
			IMaintainService maintainService)
		{
			_searchService = searchService;
			_maintainService = maintainService;
		}

		public ActionResult List(int p = 1)
		{
			int totalCount;
			var page = p < 1 ? 1 : p;
			var tasks = _searchService.GetAllMorphemes(page, MorphemeListSize, out totalCount);

			return View(new PagedListModel<MorphemeDto>
			{
				PageIndex = page,
				PageSize = MorphemeListSize,
				TotalNumber = totalCount,
				List = tasks
			});
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

		public ActionResult Detail(string id)
		{
			var morpheme = _searchService.GetMorpheme(id);

			if (morpheme == null)
				return RedirectToAction("New", "Morpheme");

			int totalCount;

			return View(new MorphemeDetailModel
			{
				Morpheme = morpheme,
				RelatedWords = _searchService.GetWordListByMorpheme(id, 20, out totalCount)
			});
		}

		public ActionResult Modify(string id)
		{
			var morpheme = _searchService.GetMorpheme(id);

			if (morpheme == null)
				return RedirectToAction("New", "Morpheme");

			return View(morpheme);
		}

		[HttpPost]
		public ActionResult Save(string id, MorphemeDto morphemeDto)
		{
			var result = _maintainService.ModifyMorpheme(id, morphemeDto);

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
					Value = string.Format("<strong>{0}</strong> {1} [ {2} ]", m.Standard, m.ToVariant(), m.Description)
				});

			return JsonContent(morphemeList);
		}

		[HttpPost]
		public ActionResult GetRelatedWordList(string morphemeId, string excludedWordId)
		{
			int totalCount;
			var words = _searchService.GetWordListByMorpheme(morphemeId, excludedWordId, 20, out totalCount)
				.Select(word => new
				{
					word.Id,
					word.Stem,
					Interpretations = word.Interpretations.OrderBy(i => i.Order).Select(i => new
					{
						i.Interpretation,
						PartOfSpeech = CommonTools.GetEnumDescription(i.PartOfSpeech)
					})
				});

			return JsonContent(words);
		}
	}
}
