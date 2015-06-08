﻿using System.Web.Mvc;
using Hangerd.Mvc;
using Root.Application.DataObjects;
using Root.Application.Services;

namespace Root.Web.Controllers
{
    public class WordController : HangerdController
    {
		private readonly ISearchService _searchService;
		private readonly IMaintainService _maintainService;

		public WordController(
			ISearchService searchService,
			IMaintainService maintainService)
		{
			_searchService = searchService;
			_maintainService = maintainService;
		}

		public ActionResult New(string word)
		{
			return View(word as object);
        }

		[HttpPost]
		public ActionResult Add(string stem, WordInterpretationDto interpretationDto)
		{
			var result = _maintainService.AddWord(stem, interpretationDto);

			return JsonContent(new { result.Message, Word = result.Value });
		}

		public ActionResult Edit(string id)
		{
			var word = _searchService.GetWord(id);

			if (word == null)
				return RedirectToAction("New", "Word");

			return View(word);
		}

		[HttpPost]
		public ActionResult AddInterpretation(string wordId, WordInterpretationDto interpretationDto)
		{
			var result = _maintainService.AddWordInterpretation(wordId, interpretationDto);

			return OperationJsonResult(result);
		}

		[HttpPost]
		public ActionResult RemoveInterpretation(string wordId, string interpretationId)
		{
			var result = _maintainService.RemoveWordInterpretation(wordId, interpretationId);

			return OperationJsonResult(result);
		}

		[HttpPost]
		public ActionResult AddMorphemeForWord(string wordId, string morphemeId)
		{
			var result = _maintainService.AddMorphemeForWord(wordId, morphemeId);

			return OperationJsonResult(result);
		}

		[HttpPost]
		public ActionResult RemoveMorphemeForWord(string wordId, string morphemeId)
		{
			var result = _maintainService.RemoveMorphemeForWord(wordId, morphemeId);

			return OperationJsonResult(result);
		}

		public ActionResult Search(string word)
		{
			int totalCount;
			var wordList = _searchService.GetWordListWithInterpretation(word, 10, out totalCount);

			ViewBag.QueryWord = word;

			return View(wordList);
		}

		public ActionResult Detail(string id)
		{
			var word = _searchService.GetWord(id);

			if (word == null)
				return RedirectToAction("New", "Word");

			return View(word);
		}
    }
}