using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;

namespace Root.Domain.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//domain services

			//domain events
		}
	}
}
