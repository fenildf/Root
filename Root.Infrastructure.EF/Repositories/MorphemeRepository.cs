using Hangerd.EntityFramework;
using Hangerd.Repository;
using Root.Domain.Models;
using Root.Domain.Repositories;

namespace Root.Infrastructure.EF.Repositories
{
	public class MorphemeRepository : EfRepository<Morpheme>, IMorphemeRepository
	{
		public MorphemeRepository(IRepositoryContext context)
			: base(context)
		{
		}
	}
}
