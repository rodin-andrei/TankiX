using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class PersonalChatChannelUIComponent : BehaviourComponent, AttachToEntityListener
	{
		private Entity entity;

		public void OnChannelClose()
		{
			if (entity != null)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent(new CloseChannelEvent(), entity);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}
	}
}
