﻿using System;
using Hangerd;
using Hangerd.Entity;

namespace Root.Domain.Models
{
	public class WordInterpretation : EntityBase
	{
		#region Public Properties

		/// <summary>
		/// 词性
		/// </summary>
		public PartOfSpeech PartOfSpeech { get; private set; }

		/// <summary>
		/// 释义
		/// </summary>
		public string Interpretation { get; private set; }

		/// <summary>
		/// 次序
		/// </summary>
		public int Order { get; private set; }

		#endregion

		#region Constructors

		protected WordInterpretation()
		{
		}

		public WordInterpretation(PartOfSpeech partOfSpeech, string interpretation, int order = 0)
		{
			if (!Enum.IsDefined(typeof(PartOfSpeech), partOfSpeech))
				throw new HangerdException("未知词性");

			if (string.IsNullOrWhiteSpace(interpretation))
				throw new HangerdException("释义内容不可为空");

			PartOfSpeech = partOfSpeech;
			Interpretation = interpretation;
			Order = order;
		}

		#endregion

		#region Public Methods

		public void ModifyOrder(int newOrder)
		{
			Order = newOrder;
		}

		#endregion
	}
}
