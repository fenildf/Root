using Hangerd.Dto;

namespace Root.Application.DataObjects
{
	public class WordInterpretationDto : DtoBase
	{
		/// <summary>
		/// 词性
		/// </summary>
		public PartOfSpeechDto PartOfSpeech { get; set; }

		/// <summary>
		/// 释义
		/// </summary>
		public string Interpretation { get; set; }

		/// <summary>
		/// 次序
		/// </summary>
		public int Order { get; set; }
	}
}
