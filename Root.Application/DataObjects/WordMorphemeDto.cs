using Hangerd.Dto;

namespace Root.Application.DataObjects
{
	public class WordMorphemeDto : DtoBase
	{
		/// <summary>
		/// 词素
		/// </summary>
		public MorphemeDto Morpheme { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Order { get; set; }
	}
}
