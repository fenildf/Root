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

		#region Morpheme

		public IEnumerable<MorphemeDto> GetAllMorphemes(int pageIndex, int pageSize, out int totalCount)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
				var morphemes = morphemeRepository.GetAll(false)
					.OrderBy(m => m.Standard)
					.Paging(pageIndex, pageSize, out totalCount);

				return Mapper.Map<IEnumerable<Morpheme>, IEnumerable<MorphemeDto>>(morphemes);
			}
		}

		public MorphemeDto GetMorpheme(string id)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
				var spec = MorphemeSpecifications.IdEquals(id);

				return Mapper.Map<Morpheme, MorphemeDto>(
					morphemeRepository.Get(spec, false));
			}
		}

		public IEnumerable<MorphemeDto> GetMorphemeList(string fuzzyMorpheme, int maxCount, out int totalCount)
		{
			if (string.IsNullOrWhiteSpace(fuzzyMorpheme))
			{
				totalCount = 0;
				return new MorphemeDto[0];
			}

			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
				var morphemeList = morphemeRepository
					.GetAll(MorphemeSpecifications.StandardLike(fuzzyMorpheme.Trim()), false)
					.OrderBy(m => m.Standard)
					.Paging(1, maxCount, out totalCount);

				return Mapper.Map<IEnumerable<Morpheme>, IEnumerable<MorphemeDto>>(morphemeList);
			}
		}

		#endregion

		#region Word

		public WordDto GetWord(string wordStem)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var wordRepository = unitOfWork.GetRepository<IWordRepository>();
				var word = wordRepository.Get(WordSpecifications.StemEquals(wordStem), false, w => w.Morphemes, w => w.Interpretations);

				return Mapper.Map<Word, WordDto>(word);
			}
		}

		public IEnumerable<WordDto> GetWordListWithInterpretation(string fuzzyWord, int maxCount, out int totalCount)
		{
			if (string.IsNullOrWhiteSpace(fuzzyWord))
			{
				totalCount = 0;
				return new WordDto[0];
			}

			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var wordRepository = unitOfWork.GetRepository<IWordRepository>();
				var wordList = wordRepository
					.GetAll(WordSpecifications.StemLike(fuzzyWord.Trim()), false, w => w.Interpretations)
					.OrderBy(w => w.Stem)
					.Paging(1, maxCount, out totalCount);

				return Mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(wordList);
			}
		}

		public IEnumerable<WordDto> GetWordListByMorpheme(string morphemeId, int maxCount, out int totalCount)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var wordRepository = unitOfWork.GetRepository<IWordRepository>();
				var wordList = wordRepository
					.GetAll(WordSpecifications.ContainsMorphemeId(morphemeId), false, w => w.Interpretations)
					.OrderBy(w => w.Stem)
					.Paging(1, maxCount, out totalCount);

				return Mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(wordList);
			}
		}

		public IEnumerable<WordDto> GetWordListByMorpheme(string morphemeId, string excludedWordId, int maxCount, out int totalCount)
		{
			using (var unitOfWork = DbContextFactory.CreateContext())
			{
				var spec = WordSpecifications.ContainsMorphemeId(morphemeId) & !WordSpecifications.IdEquals(excludedWordId);
				var wordRepository = unitOfWork.GetRepository<IWordRepository>();
				var wordList = wordRepository
					.GetAll(spec, false, w => w.Interpretations)
					.OrderBy(w => w.Stem)
					.Paging(1, maxCount, out totalCount);

				return Mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(wordList);
			}
		}

		#endregion
	}
}
