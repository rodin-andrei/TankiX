using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Library.ClientUnityIntegration.API
{
	public abstract class EventMappingComponent : BehaviourComponent, AttachToEntityListener, DetachFromEntityListener
	{
		protected Entity entity;

		protected abstract void Subscribe();

		protected virtual void Awake()
		{
			Subscribe();
		}

		protected virtual void SendEvent<T>() where T : Event, new()
		{
			if (entity != null)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent<T>(entity);
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}
	}
}
