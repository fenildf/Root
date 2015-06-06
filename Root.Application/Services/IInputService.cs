using Hangerd;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface IInputService
	{
		#region Morpheme

		HangerdResult<bool> AddMorpheme(MorphemeDto morphemeDto);

		#endregion

		#region Word

		HangerdResult<WordDto> AddWord(string stem, WordInterpretationDto interpretationDto);

		HangerdResult<bool> AddWordInterpretation(string wordId, WordInterpretationDto interpretationDto);

		HangerdResult<bool> RemoveWordInterpretation(string wordId, string interpretationId);

		#endregion
	}
}
