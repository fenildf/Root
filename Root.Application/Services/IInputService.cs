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

		HangerdResult<bool> AddWord(string stem, WordInterpretationDto interpretationDto);

		#endregion
	}
}
