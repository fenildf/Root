using AutoMapper;
using Hangerd;
using Hangerd.Validation;
using Root.Application.DataObjects;
using Root.Domain.Models;
using Root.Domain.Repositories;
using Root.Infrastructure;

namespace Root.Application.Services.Implementation
{
	public class InputService : ApplicationServiceBase, IInputService
	{
		#region Constructors

		public InputService(IRootDbContextFactory dbContextFactory)
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
					var repository = unitOfWork.GetRepository<IMorphemeRepository>();
					var morpheme = new Morpheme(
						morphemeDto.Standard,
						morphemeDto.Variant,
						morphemeDto.Description,
						(MorphemeType) morphemeDto.Type);

					repository.Add(morpheme);

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
					var repository = unitOfWork.GetRepository<IWordRepository>();
					var word = repository.Get(wordId, true, w => w.Interpretations);

					Requires.NotNull(word, "单词信息不存在");

					word.AddInterpretation((PartOfSpeech)interpretationDto.PartOfSpeech, interpretationDto.Interpretation);

					repository.Update(word);

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
					var repository = unitOfWork.GetRepository<IWordRepository>();
					var word = repository.Get(wordId, true, w => w.Interpretations);

					Requires.NotNull(word, "单词信息不存在");

					word.RemoveInterpretation(interpretationId);

					repository.Update(word);

					unitOfWork.Commit();
				}
			});
		}

		#endregion
	}
}
