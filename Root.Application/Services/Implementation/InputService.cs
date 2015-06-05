using AutoMapper;
using Hangerd;
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

		public HangerdResult<bool> AddWord(string stem, WordInterpretationDto interpretationDto)
		{
			return TryOperate(() =>
			{
				using (var unitOfWork = DbContextFactory.CreateContext())
				{
					var repository = unitOfWork.GetRepository<IWordRepository>();
					var word = new Word(
						stem,
						new WordInterpretation((PartOfSpeech) interpretationDto.PartOfSpeech, interpretationDto.Interpretation));

					repository.Add(word);

					unitOfWork.Commit();
				}
			});
		}

		#endregion
	}
}
