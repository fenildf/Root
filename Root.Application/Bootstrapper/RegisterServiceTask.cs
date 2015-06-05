using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using Root.Application.Services;
using Root.Application.Services.Implementation;

namespace Root.Application.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//application services
			_container.RegisterTypeAsSingleton<ISearchService, SearchService>();
			_container.RegisterTypeAsSingleton<IInputService, InputService>();
		}
	}
}
