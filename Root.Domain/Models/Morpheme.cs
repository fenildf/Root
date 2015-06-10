using System;
using Hangerd;
using Hangerd.Entity;

namespace Root.Domain.Models
{
	public class Morpheme : EntityBase, IValidatable
	{
		#region Public Properties

		/// <summary>
		/// 词素正体
		/// </summary>
		public string Standard { get; private set; }

		/// <summary>
		/// 词素变体
		/// </summary>
		public string Variant { get; private set; }

		/// <summary>
		/// 描述
		/// </summary>
		public string Description { get; private set; }

		/// <summary>
		/// 类型
		/// </summary>
		public MorphemeType Type { get; private set; }

		#endregion

		#region Constructors

		protected Morpheme()
		{
		}

		public Morpheme(string standard, string variant, string description, MorphemeType type)
		{
			if (string.IsNullOrWhiteSpace(standard))
				throw new HangerdException("词素内容不可为空");

			if (!Enum.IsDefined(typeof (MorphemeType), type))
				throw new HangerdException("未知词素类型");

			Standard = standard.ToLower();
			Variant = variant;
			Description = description;
			Type = type;
		}

		#endregion

		#region Public Methods

		public void Validate()
		{
			
		}

		public void ModifyVariant(string variant)
		{
			Variant = variant;
		}

		public void ModifyDescription(string description)
		{
			if (string.IsNullOrWhiteSpace(description))
				throw new HangerdException("词素描述不可为空");

			Description = description;
		}

		#endregion
	}
}
