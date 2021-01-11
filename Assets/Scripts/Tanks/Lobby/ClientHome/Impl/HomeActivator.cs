using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientHome.API;

namespace Tanks.Lobby.ClientHome.Impl
{
	public class HomeActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			TemplateRegistry.Register<HomeScreenTemplate>();
			ECSBehaviour.EngineService.RegisterSystem(new HomeScreenSystem());
		}
	}
}
