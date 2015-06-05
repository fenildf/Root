using System.Collections.Generic;
using Hangerd.Dto;

namespace Root.Application.DataObjects
{
	public class WordDto : DtoBase
	{
		/// <summary>
		/// 词干
		/// </summary>
		public string Stem { get; set; }

		/// <summary>
		/// 词素列表
		/// </summary>
		public ICollection<MorphemeDto> Morphemes { get; set; }

		/// <summary>
		/// 释义列表
		/// </summary>
		public ICollection<WordInterpretationDto> Interpretations { get; set; }

		/// <summary>
		/// 例句
		/// </summary>
		public string ExampleSentence { get; set; }
	}
}
