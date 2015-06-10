using System.ComponentModel;

namespace Root.Application.DataObjects
{
	public enum PartOfSpeechDto
	{
		/// <summary>
		/// 名词
		/// </summary>
		[Description("n.")] n = 1,

		/// <summary>
		/// 动词
		/// </summary>
		[Description("v.")] v = 2,

		/// <summary>
		/// 及物动词
		/// </summary>
		[Description("vt.")] vt = 3,

		/// <summary>
		/// 不及物动词
		/// </summary>
		[Description("vi.")] vi = 4,

		/// <summary>
		/// 形容词
		/// </summary>
		[Description("adj.")] adj = 5,

		/// <summary>
		/// 副词
		/// </summary>
		[Description("adv.")] adv = 6,

		/// <summary>
		/// 介词
		/// </summary>
		[Description("prep.")] prep = 7,

		/// <summary>
		/// 代词
		/// </summary>
		[Description("pron.")] pron = 8
	}
}
