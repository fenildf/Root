using System;
using System.Linq;
using System.Linq.Expressions;
using Hangerd.EntityFramework;
using Hangerd.Repository;
using Root.Domain.Models;
using Root.Domain.Repositories;
using Root.Domain.Specifications;

namespace Root.Infrastructure.EF.Repositories
{
	public class WordRepository : EfRepository<Word>, IWordRepository
	{
		public WordRepository(IRepositoryContext context)
			: base(context)
		{
		}

		public int GetTotalNumberOfWords()
		{
			return GetAll(false).Count();
		}

		public Word GetWordByStem(string stem, bool tracking, params Expression<Func<Word, object>>[] eagerLoadingProperties)
		{
			var spec = WordSpecifications.StemEquals(stem);

			return Get(spec, tracking, eagerLoadingProperties);
		}
	}
}
