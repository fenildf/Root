using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using Root.Infrastructure.EF.Factories;

namespace Root.Infrastructure.EF.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			_container.RegisterTypeAsSingleton<IRootDbContextFactory, RootDbContextFactory>();
		}
	}
}
