﻿using System;
using Hangerd;
using Hangerd.Entity;
using Root.Domain.Utilities;

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

		public override void GenerateNewId()
		{
			Id = IdGenerator.Create<Morpheme>(string.Format("{0}_{1}", Standard, Type));
		}

		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(Description))
				throw new HangerdException("词素描述不可为空");
		}

		public void Modify(string variant, string description)
		{
			Variant = variant;
			Description = description;
		}

		#endregion
	}
}