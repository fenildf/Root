using AutoMapper;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;
using Root.Application.DataObjects;
using Root.Domain.Models;

namespace Root.Application.Bootstrapper
{
	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			ConfigureAutoMapper();
		}

		private static void ConfigureAutoMapper()
		{
			Mapper.CreateMap<Morpheme, MorphemeDto>()
				.ForMember(dto => dto.Type, mce => mce.ResolveUsing(e => (MorphemeTypeDto)e.Type));
			Mapper.CreateMap<Word, WordDto>();
			Mapper.CreateMap<WordMorpheme, WordMorphemeDto>();
			Mapper.CreateMap<WordInterpretation, WordInterpretationDto>()
				.ForMember(dto => dto.PartOfSpeech, mce => mce.ResolveUsing(e => (PartOfSpeechDto)e.PartOfSpeech));

			#region Dto to Model

			Mapper.CreateMap<WordInterpretationDto, WordInterpretation>()
				.ForMember(dto => dto.PartOfSpeech, mce => mce.ResolveUsing(e => (PartOfSpeech)e.PartOfSpeech));

			#endregion
		}
	}
}
