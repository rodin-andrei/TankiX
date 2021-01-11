using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientLoading.API;

namespace Tanks.Lobby.ClientLoading.Impl
{
	public class ClientLoadingActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			ECSBehaviour.EngineService.RegisterSystem(new AssetBundleLoadingProgressBarSystem());
			ECSBehaviour.EngineService.RegisterSystem(new AssetBundleLoadingSystem());
			ECSBehaviour.EngineService.RegisterSystem(new PreloadAllResourcesScreenSystem());
			ECSBehaviour.EngineService.RegisterSystem(new BattleLoadScreenSystem());
			ECSBehaviour.EngineService.RegisterSystem(new OutputLogSystem());
			ECSBehaviour.EngineService.RegisterSystem(new IntroCinematicSystem());
			TemplateRegistry.Register<PreloadAllResourcesScreenTemplate>();
			TemplateRegistry.Register<LobbyLoadScreenTemplate>();
			TemplateRegistry.Register<WarmupResourcesTemplate>();
		}
	}
}
