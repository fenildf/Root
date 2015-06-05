using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hangerd.Extensions;
using Root.Application.DataObjects;
using Root.Domain.Models;
using Root.Domain.Repositories;
using Root.Domain.Specifications;
using Root.Infrastructure;

namespace Root.Application.Services.Implementation
{
	public class SearchService : ApplicationServiceBase, ISearchService
	{
		#region Constructors

		public SearchService(IRootDbContextFactory dbContextFactory)
			: base(dbContextFactory)
		{
		}

		#endregion

		#region Word

		public WordDto GetWord(string id)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var repository = unitOfWork.GetRepository<IWordRepository>();
				var spec = WordSpecifications.IdEquals(id);

				return Mapper.Map<Word, WordDto>(
					repository.Get(spec, false, w => w.Morphemes, w => w.Interpretations));
			}
		}

		public IEnumerable<WordDto> GetWordListFuzzily(string word, int maxCount, out int totalCount)
		{
			if (string.IsNullOrWhiteSpace(word))
			{
				totalCount = 0;
				return new WordDto[0];
			}

			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var repository = unitOfWork.GetRepository<IWordRepository>();
				var spec = WordSpecifications.StemLike(word.Trim());
				var wordList = repository.GetAll(spec, false, w => w.Morphemes, w => w.Interpretations)
					.OrderBy(w => w.Stem)
					.Paging(1, maxCount, out totalCount);

				return Mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(wordList);
			}
		}

		#endregion
	}
}
