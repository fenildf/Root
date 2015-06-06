using System.Collections.Generic;
using System.Linq;
using Hangerd;
using Hangerd.Entity;
using Root.Domain.Utilities;

namespace Root.Domain.Models
{
	public class Word : EntityBase
	{
		#region Public Properties

		/// <summary>
		/// 词干
		/// </summary>
		public string Stem { get; private set; }

		/// <summary>
		/// 词素列表
		/// </summary>
		public ICollection<Morpheme> Morphemes { get; private set; }

		/// <summary>
		/// 释义列表
		/// </summary>
		public ICollection<WordInterpretation> Interpretations { get; private set; }

		/// <summary>
		/// 例句
		/// </summary>
		public string ExampleSentence { get; private set; }

		#endregion

		#region Constructors

		protected Word()
		{
		}

		public Word(string stem, IList<Morpheme> morphemes, WordInterpretation defaultInterpretation)
		{
			if (string.IsNullOrWhiteSpace(stem))
				throw new HangerdException("词干不可为空");

			if (defaultInterpretation == null)
				throw new HangerdException("默认释义不可为空");

			Stem = stem;
			Morphemes = morphemes;
			Interpretations = new List<WordInterpretation> { defaultInterpretation };
		}

		#endregion

		#region Public Methods

		public override void GenerateNewId()
		{
			Id = IdGenerator.Create<Word>(Stem);
		}

		public void AddInterpretation(PartOfSpeech partOfSpeech, string interpretation)
		{
			if (Interpretations == null)
				throw new HangerdException("Interpretations has not been loaded.");

			Interpretations.Add(new WordInterpretation(partOfSpeech, interpretation, Interpretations.Count));
		}

		public void RemoveInterpretation(string interpretationId)
		{
			if (Interpretations == null)
				throw new HangerdException("Interpretations has not been loaded.");

			if (Interpretations.Count == 1)
				throw new HangerdException("至少保留一条释义");

			var removedInterpretation = Interpretations.FirstOrDefault(e => e.Id == interpretationId);

			if (removedInterpretation == null)
				throw new HangerdException("释义信息不存在");

			Interpretations.Remove(removedInterpretation);

			foreach (var interpretation in Interpretations.Where(e => e.Order > removedInterpretation.Order))
				interpretation.ModifyOrder(interpretation.Order - 1);
		}

		#endregion
	}
}
