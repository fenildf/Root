namespace Root.Infrastructure.EF.Factories
{
	public class RootDbContextFactory : IRootDbContextFactory
	{
		public IRootDbContext CreateContext()
		{
			return new RootDbContext();
		}
	}
}