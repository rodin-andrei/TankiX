using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientProfile.API;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class TanksClientProfileActivator : UnityAwareActivator<AutoCompleting>, ECSActivator, Activator
	{
		[Inject]
		public static TemplateRegistry TemplateRegistry
		{
			get;
			set;
		}

		public void RegisterSystemsAndTemplates()
		{
			ECSBehaviour.EngineService.RegisterSystem(new GameSettingsScreenSystem());
			ECSBehaviour.EngineService.RegisterSystem(new SoundSettingsScreenSystem());
			ECSBehaviour.EngineService.RegisterSystem(new SoundSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new SfxVolumeSliderBarSystem());
			ECSBehaviour.EngineService.RegisterSystem(new TanksSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new CameraShakerSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new TargetFocusSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new LaserSightSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new UserXCrystalsIndicatorSystem());
			ECSBehaviour.EngineService.RegisterSystem(new MouseSettingsSystem());
			ECSBehaviour.EngineService.RegisterSystem(new CBQAchievementSystem());
			TemplateRegistry.RegisterPart<TanksSettingsTemplatePart>();
			TemplateRegistry.RegisterPart<MouseSettingsTemplatePart>();
			TemplateRegistry.RegisterPart<GameCameraShakerSettingsTemplatePart>();
			TemplateRegistry.RegisterPart<TargetFocusSettingsTemplatePart>();
			ECSBehaviour.EngineService.RegisterSystem(new CrystalsBufferSystem());
		}

		protected override void Activate()
		{
		}
	}
}
