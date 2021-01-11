using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public abstract class LocalizedScreenComponent : FromConfigBehaviour, Component, AttachToEntityListener
	{
		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public string Header
		{
			private get;
			set;
		}

		protected override string GetRelativeConfigPath()
		{
			return "/ui/screen";
		}

		public void AttachedToEntity(Entity entity)
		{
			SetScreenHeaderEvent setScreenHeaderEvent = new SetScreenHeaderEvent();
			setScreenHeaderEvent.Animated(Header);
			EngineService.Engine.ScheduleEvent(setScreenHeaderEvent, entity);
		}

		public void DetachFromEntity(Entity entity)
		{
		}
	}
}
