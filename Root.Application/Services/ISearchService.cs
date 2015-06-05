using System.Collections.Generic;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface ISearchService
	{
		WordDto GetWord(string id);

		IEnumerable<WordDto> GetWordListFuzzily(string word, int maxCount, out int totalCount);
	}
}
