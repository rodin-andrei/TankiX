using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class CancelNotificationComponent : BehaviourComponent
	{
		private Entity entity;

		private void Awake()
		{
			base.enabled = false;
		}

		public void Init(Entity entity)
		{
			this.entity = entity;
			base.enabled = true;
		}

		private void Update()
		{
			if (InputMapping.Cancel)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent<CloseNotificationEvent>(entity);
			}
		}
	}
}
