using System.Collections.Generic;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface ISearchService
	{
		WordDto GetWordAccurately(string word);

		IEnumerable<WordDto> GetWordListFuzzily(string word, int maxCount, out int totalCount);
	}
}
