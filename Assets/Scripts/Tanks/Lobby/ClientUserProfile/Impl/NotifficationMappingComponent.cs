using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NotifficationMappingComponent : BehaviourComponent, IPointerClickHandler, AttachToEntityListener, DetachFromEntityListener, IEventSystemHandler
	{
		[SerializeField]
		private bool clickAnywhere;

		private Entity entity;

		void AttachToEntityListener.AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			MouseClicked();
		}

		private void MouseClicked()
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent<NotificationClickEvent>(entity);
			base.enabled = false;
		}

		void DetachFromEntityListener.DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}

		private void Update()
		{
			if (clickAnywhere && Input.GetMouseButton(0))
			{
				MouseClicked();
			}
		}
	}
}
