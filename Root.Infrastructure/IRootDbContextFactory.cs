namespace Root.Infrastructure
{
	public interface IRootDbContextFactory
	{
		IRootDbContext CreateContext();
	}
}
