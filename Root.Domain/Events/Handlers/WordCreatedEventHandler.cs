using System;
using Hangerd.Event;
using Root.Domain.Models;
using Root.Infrastructure.TranlateProxy;

namespace Root.Domain.Events.Handlers
{
	public class WordCreatedEventHandler : IDomainEventHandler<WordCreatedEvent>
	{
		private readonly ITranslateService _translateService;

		public WordCreatedEventHandler(ITranslateService translateService)
		{
			_translateService = translateService;
		}

		public void Handle(WordCreatedEvent @event)
		{
			var word = @event.Word;
			var dictionaryResult = _translateService.GetWordDictionaryResult(word.Stem);

			if (dictionaryResult == null || dictionaryResult.symbols == null || dictionaryResult.symbols.Length == 0)
				return;

			var symbol = dictionaryResult.symbols[0];

			word.ModifyPhonetic(symbol.ph_am);

			if (symbol.parts != null)
			{
				foreach (var part in symbol.parts)
				{
					PartOfSpeech partOfSpeech;

					if (Enum.TryParse(part.part.TrimEnd('.'), true, out partOfSpeech))
						word.AddInterpretation(partOfSpeech, string.Join(";", part.means));
				}
			}
		}
	}
}
