using System.Collections.Generic;
using System.Linq;
using Hangerd;
using Hangerd.Entity;
using Hangerd.Event;
using Root.Domain.Events;
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
		/// 音标
		/// </summary>
		public string Phonetic { get; private set; }

		/// <summary>
		/// 词素列表
		/// </summary>
		public ICollection<WordMorpheme> Morphemes { get; private set; }

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

		public Word(string stem)
		{
			if (string.IsNullOrWhiteSpace(stem))
				throw new HangerdException("词干不可为空");

			Stem = stem.Trim().ToLower();
			Interpretations = new List<WordInterpretation>();

			DomainEvent.Publish(new WordCreatedEvent(this));
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

		public void AddMorpheme(Morpheme morpheme)
		{
			if (Morphemes == null)
				throw new HangerdException("Morphemes has not been loaded.");

			if (Morphemes.Any(m => m.Morpheme.Id == morpheme.Id))
				throw new HangerdException("该词素已添加");

			Morphemes.Add(new WordMorpheme(morpheme, Morphemes.Count));
		}

		public void RemoveMorpheme(string morphemeId)
		{
			if (Morphemes == null)
				throw new HangerdException("Morphemes has not been loaded.");

			var removedMorpheme = Morphemes.FirstOrDefault(m => m.Morpheme.Id == morphemeId);

			if (removedMorpheme == null)
				throw new HangerdException("词素信息不存在");

			Morphemes.Remove(removedMorpheme);

			foreach (var morpheme in Morphemes.Where(m => m.Order > removedMorpheme.Order))
				morpheme.ModifyOrder(morpheme.Order - 1);
		}

		public void ModifyPhonetic(string phonetic)
		{
			Phonetic = phonetic;
		}

		public void ModifyExampleSentence(string exampleSentence)
		{
			ExampleSentence = exampleSentence;
		}

		#endregion
	}
}
