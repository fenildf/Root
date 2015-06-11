using System;
using System.Linq.Expressions;
using Hangerd.Repository;
using Root.Domain.Models;

namespace Root.Domain.Repositories
{
	public interface IWordRepository : IRepository<Word>
	{
		int GetTotalNumberOfWords();

		Word GetWordByStem(string stem, bool tracking, params Expression<Func<Word, object>>[] eagerLoadingProperties);
	}
}
