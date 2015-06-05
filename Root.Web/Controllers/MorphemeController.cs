using System.Web.Mvc;
using Hangerd.Mvc;
using Root.Application.DataObjects;
using Root.Application.Services;

namespace Root.Web.Controllers
{
    public class MorphemeController : HangerdController
    {
		private readonly IInputService _inputService;

		public MorphemeController(
			IInputService inputService)
		{
			_inputService = inputService;
		}

		public ActionResult New(string morpheme)
		{
			return View(morpheme as object);
        }

		[HttpPost]
		public ActionResult Add(MorphemeDto morphemeDto)
		{
			var result = _inputService.AddMorpheme(morphemeDto);

			return OperationJsonResult(result);
		}
    }
}