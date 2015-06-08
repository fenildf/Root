﻿using System.Collections.Generic;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface ISearchService
	{
		WordDto GetWord(string id);

		IEnumerable<WordDto> GetWordListWithInterpretation(string fuzzyWord, int maxCount, out int totalCount);

		IEnumerable<MorphemeDto> GetMorphemeList(string fuzzyMorpheme, int maxCount, out int totalCount);
	}
}