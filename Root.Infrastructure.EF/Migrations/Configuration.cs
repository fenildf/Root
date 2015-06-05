using System.Data.Entity.Migrations;

namespace Root.Infrastructure.EF.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<RootDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}
