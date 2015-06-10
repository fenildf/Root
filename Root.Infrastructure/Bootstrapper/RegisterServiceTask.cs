using Hangerd.Bootstrapper;
using Hangerd.Extensions;
using Microsoft.Practices.Unity;
using Root.Infrastructure.TranlateProxy;

namespace Root.Infrastructure.Bootstrapper
{
	public class RegisterServiceTask : RegisterServiceBootstrapperTask
	{
		public RegisterServiceTask(IUnityContainer container) : base(container)
		{
		}

		public override void Execute()
		{
			//infrastructure services
			_container.RegisterTypeAsSingleton<ITranslateService, TranslateService>();
		}
	}
}
