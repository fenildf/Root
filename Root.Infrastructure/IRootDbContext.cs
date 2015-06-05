using Hangerd.Repository;

namespace Root.Infrastructure
{
	public interface IRootDbContext : IRepositoryContext
	{
		TRepository GetRepository<TRepository>();
	}
}
