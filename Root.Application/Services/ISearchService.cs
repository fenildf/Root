using System.Collections.Generic;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface ISearchService
	{
		#region Morpheme

		IEnumerable<MorphemeDto> GetAllMorphemes(int pageIndex, int pageSize, out int totalCount);

		MorphemeDto GetMorpheme(string id);

		IEnumerable<MorphemeDto> GetMorphemeList(string fuzzyMorpheme, int maxCount, out int totalCount);

		#endregion

		#region Word

		int GetTotalNumberOfWords();

		WordDto GetWord(string wordStem);

		IEnumerable<WordDto> GetWordListWithInterpretation(string fuzzyWord, int maxCount, out int totalCount);

		IEnumerable<WordDto> GetWordListByMorpheme(string morphemeId, int maxCount, out int totalCount);

		IEnumerable<WordDto> GetWordListByMorpheme(string morphemeId, string excludedWordId, int maxCount, out int totalCount);

		#endregion
	}
}
