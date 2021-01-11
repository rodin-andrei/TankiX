using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class ClientControlsActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			ECSBehaviour.EngineService.RegisterSystem(new CommonControlsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new InputFieldSystem());
			ECSBehaviour.EngineService.RegisterSystem(new CaptchaSystem());
			ECSBehaviour.EngineService.RegisterSystem(new LoadGearSystem());
			ECSBehaviour.EngineService.RegisterSystem(new ScreenForegroundSystem());
			ECSBehaviour.EngineService.RegisterSystem(new CarouselSystem());
			TemplateRegistry.Register(typeof(LocalizedTextTemplate));
			TemplateRegistry.Register(typeof(CarouselItemTemplate));
		}
	}
}
