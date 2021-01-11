using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AnimationTriggerComponent : ECSBehaviour, Component
	{
		private Entity entity;

		public Entity Entity
		{
			get
			{
				return entity;
			}
			set
			{
				entity = value;
				base.enabled = true;
			}
		}

		private void Awake()
		{
			base.enabled = false;
		}

		private void SendEvent<T>() where T : Event, new()
		{
			NewEvent<T>().Attach(Entity).Schedule();
		}

		private void AddComponentIfNeeded<T>() where T : Component, new()
		{
			if (!Entity.HasComponent<T>())
			{
				Entity.AddComponent<T>();
			}
		}

		private void RemoveComponentIfNeeded<T>() where T : Component, new()
		{
			if (Entity.HasComponent<T>())
			{
				Entity.RemoveComponent<T>();
			}
		}

		protected void AddComponent<T>() where T : Component, new()
		{
			if (base.enabled)
			{
				AddComponentIfNeeded<T>();
			}
		}

		protected void RemoveComponent<T>() where T : Component, new()
		{
			if (base.enabled)
			{
				RemoveComponentIfNeeded<T>();
			}
		}

		protected void ProvideEvent<T>() where T : Event, new()
		{
			if (base.enabled)
			{
				SendEvent<T>();
			}
		}
	}
}
