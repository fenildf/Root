using Hangerd.Dto;

namespace Root.Application.DataObjects
{
	public class MorphemeDto : DtoBase
	{
		/// <summary>
		/// 词素正体
		/// </summary>
		public string Standard { get; set; }

		/// <summary>
		/// 词素变体
		/// </summary>
		public string Variant { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public MorphemeTypeDto Type { get; set; }

		public override string ToString()
		{
			return string.Format("[ {0}{1} {2} ]",
				Standard,
				string.IsNullOrWhiteSpace(Variant) ? string.Empty : string.Format(" ({0})", Variant),
				Description);
		}
	}
}
