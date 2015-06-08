using AutoMapper;
using Hangerd;
using Hangerd.Validation;
using Root.Application.DataObjects;
using Root.Domain.Models;
using Root.Domain.Repositories;
using Root.Infrastructure;

namespace Root.Application.Services.Implementation
{
	public class MaintainService : ApplicationServiceBase, IMaintainService
	{
		#region Constructors

		public MaintainService(IRootDbContextFactory dbContextFactory)
			: base(dbContextFactory)
		{
		}

		#endregion

		#region Morpheme

		public HangerdResult<bool> AddMorpheme(MorphemeDto morphemeDto)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
					var morpheme = new Morpheme(
						morphemeDto.Standard,
						morphemeDto.Variant,
						morphemeDto.Description,
						(MorphemeType) morphemeDto.Type);

					morphemeRepository.Add(morpheme);

					unitOfWork.Commit();
				}
			});
		}

		public HangerdResult<bool> ModifyMorpheme(string morphemeId, MorphemeDto morphemeDto)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
					var morpheme = morphemeRepository.Get(morphemeId, true);

					morpheme.Modify(morphemeDto.Variant, morphemeDto.Description);

					morphemeRepository.Update(morpheme);

					unitOfWork.Commit();
				}
			});
		}

		#endregion

		#region Word

		public HangerdResult<WordDto> AddWord(string stem, WordInterpretationDto interpretationDto)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					//todo: morphemes
					var wordRepository = unitOfWork.GetRepository<IWordRepository>();
					var word = new Word(
						stem,
						null,
						new WordInterpretation((PartOfSpeech) interpretationDto.PartOfSpeech, interpretationDto.Interpretation));

					wordRepository.Add(word);

					unitOfWork.Commit();

					return Mapper.Map<Word, WordDto>(word);
				}
			});
		}

		public HangerdResult<bool> AddWordInterpretation(string wordId, WordInterpretationDto interpretationDto) 
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var wordRepository = unitOfWork.GetRepository<IWordRepository>();
					var word = wordRepository.Get(wordId, true, w => w.Interpretations);

					Requires.NotNull(word, "单词信息不存在");

					word.AddInterpretation((PartOfSpeech)interpretationDto.PartOfSpeech, interpretationDto.Interpretation);

					wordRepository.Update(word);

					unitOfWork.Commit();
				}
			});
		}

		public HangerdResult<bool> RemoveWordInterpretation(string wordId, string interpretationId) 
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var wordRepository = unitOfWork.GetRepository<IWordRepository>();
					var word = wordRepository.Get(wordId, true, w => w.Interpretations);

					Requires.NotNull(word, "单词信息不存在");

					word.RemoveInterpretation(interpretationId);

					wordRepository.Update(word);

					unitOfWork.Commit();
				}
			});
		}

		public HangerdResult<bool> AddMorphemeForWord(string wordId, string morphemeId)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var wordRepository = unitOfWork.GetRepository<IWordRepository>();
					var word = wordRepository.Get(wordId, true, w => w.Morphemes);

					Requires.NotNull(word, "单词信息不存在");

					var morphemeRepository = unitOfWork.GetRepository<IMorphemeRepository>();
					var morpheme = morphemeRepository.Get(morphemeId, true);

					Requires.NotNull(morpheme, "词素信息不存在");

					word.AddMorpheme(morpheme);

					unitOfWork.Commit();
				}
			});
		}

		public HangerdResult<bool> RemoveMorphemeForWord(string wordId, string morphemeId)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var wordRepository = unitOfWork.GetRepository<IWordRepository>();
					var word = wordRepository.Get(wordId, true, w => w.Morphemes);

					Requires.NotNull(word, "单词信息不存在");

					word.RemoveMorpheme(morphemeId);

					unitOfWork.Commit();
				}
			});
		}

		#endregion
	}
}
