using Hangerd;
using Root.Application.DataObjects;

namespace Root.Application.Services
{
	public interface IMaintainService
	{
		#region Morpheme

		HangerdResult<bool> AddMorpheme(MorphemeDto morphemeDto);

		HangerdResult<bool> ModifyMorpheme(string morphemeId, MorphemeDto morphemeDto);

		#endregion

		#region Word

		HangerdResult<WordDto> AddWord(string stem);

		HangerdResult<bool> ModifyWord(string wordId, WordDto wordDto);

		HangerdResult<bool> AddWordInterpretation(string wordId, WordInterpretationDto interpretationDto);

		HangerdResult<bool> RemoveWordInterpretation(string wordId, string interpretationId);

		HangerdResult<bool> AddMorphemeForWord(string wordId, string morphemeId);

		HangerdResult<bool> RemoveMorphemeForWord(string wordId, string morphemeId);

		#endregion
	}
}
