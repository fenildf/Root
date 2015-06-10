using Hangerd.Event;
using Root.Domain.Models;

namespace Root.Domain.Events
{
	public class WordCreatedEvent: DomainEvent
	{
		#region Public Properties

		public Word Word { get; private set; }

		#endregion

		public WordCreatedEvent(Word word)
		{
			Word = word;
		}
	}
}
