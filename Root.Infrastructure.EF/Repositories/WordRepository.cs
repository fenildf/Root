using Hangerd.EntityFramework;
using Hangerd.Repository;
using Root.Domain.Models;
using Root.Domain.Repositories;

namespace Root.Infrastructure.EF.Repositories
{
	public class WordRepository : EfRepository<Word>, IWordRepository
	{
		public WordRepository(IRepositoryContext context)
			: base(context)
		{
		}
	}
}
