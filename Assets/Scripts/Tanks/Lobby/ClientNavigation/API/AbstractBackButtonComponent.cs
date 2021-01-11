using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public abstract class AbstractBackButtonComponent<T> : ECSBehaviour, Component, AttachToEntityListener, DetachFromEntityListener where T : Event, new()
	{
		private Entity entity;

		private bool disabled;

		public bool Disabled
		{
			get
			{
				return disabled;
			}
			set
			{
				disabled = value;
			}
		}

		private void OnEnable()
		{
			disabled = false;
		}

		private void Update()
		{
			if (entity != null && !disabled && !InputFieldComponent.IsAnyInputFieldInFocus() && InputMapping.Cancel)
			{
				ScheduleEvent<T>(entity);
			}
		}

		void AttachToEntityListener.AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		void DetachFromEntityListener.DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}
	}
}
