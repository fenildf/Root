using System.ComponentModel;

namespace Root.Domain.Models
{
	public enum PartOfSpeech
	{
		/// <summary>
		/// 名词
		/// </summary>
		[Description("n.")] Noun = 1,

		/// <summary>
		/// 动词
		/// </summary>
		[Description("v.")] Verb = 2,

		/// <summary>
		/// 及物动词
		/// </summary>
		[Description("vt.")] TransitiveVerb = 3,

		/// <summary>
		/// 不及物动词
		/// </summary>
		[Description("vi.")] IntransitiveVerb = 4,

		/// <summary>
		/// 形容词
		/// </summary>
		[Description("adj.")] Adjective = 5,

		/// <summary>
		/// 副词
		/// </summary>
		[Description("adv.")] Adverb = 6,

		/// <summary>
		/// 介词
		/// </summary>
		[Description("prep.")] Preposition = 7,

		/// <summary>
		/// 代词
		/// </summary>
		[Description("pron.")] Pronoun = 8
	}
}
