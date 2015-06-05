using System.Web.Mvc;
using Hangerd.Mvc;
using Root.Application.DataObjects;
using Root.Application.Services;

namespace Root.Web.Controllers
{
    public class WordController : HangerdController
    {
		private readonly ISearchService _searchService;
		private readonly IInputService _inputService;

		public WordController(
			ISearchService searchService,
			IInputService inputService)
		{
			_searchService = searchService;
			_inputService = inputService;
		}

		public ActionResult New(string word)
		{
			return View(word as object);
        }

		[HttpPost]
		public ActionResult Add(string stem, WordInterpretationDto interpretationDto)
		{
			var result = _inputService.AddWord(stem, interpretationDto);

			return OperationJsonResult(result);
		}

		public ActionResult Edit(string word)
		{
			var searchedWord = _searchService.GetWordAccurately(word);

			if (searchedWord == null)
				return RedirectToAction("New", "Word", new { word });

			return View(searchedWord);
		}

		public ActionResult Search(string word)
		{
			int totalCount;
			var wordList = _searchService.GetWordListFuzzily(word, 10, out totalCount);

			ViewBag.QueryWord = word;

			return View(wordList);
		}
    }
}