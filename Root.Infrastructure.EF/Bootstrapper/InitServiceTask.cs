using System.Data.Entity;
using Hangerd.Bootstrapper;
using Microsoft.Practices.Unity;
using Root.Infrastructure.EF.Migrations;

namespace Root.Infrastructure.EF.Bootstrapper
{
	public class InitServiceTask : InitServiceBootstrapperTask
	{
		public InitServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<RootDbContext, Configuration>());
		}
	}
}
