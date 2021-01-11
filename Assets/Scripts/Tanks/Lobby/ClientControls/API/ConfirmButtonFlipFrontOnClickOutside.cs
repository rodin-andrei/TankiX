using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class ConfirmButtonFlipFrontOnClickOutside : ECSBehaviour, IPointerEnterHandler, IPointerExitHandler, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener, DetachFromEntityListener, IEventSystemHandler
	{
		[SerializeField]
		private ConfirmButtonComponent confirmButton;

		private bool inside;

		private Entity entity;

		private void OnGUI()
		{
			if (!confirmButton.EnableOutsideClicking)
			{
				return;
			}
			if (UnityEngine.Event.current.type == EventType.MouseUp && !inside)
			{
				FlipFront();
			}
			if (UnityEngine.Event.current.type == EventType.KeyDown)
			{
				float axis = Input.GetAxis("Vertical");
				if (!Mathf.Approximately(axis, 0f))
				{
					FlipFront();
				}
			}
		}

		private void FlipFront()
		{
			confirmButton.FlipFront();
			if (entity != null)
			{
				ScheduleEvent<ConfirmButtonClickOutsideEvent>(entity);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			inside = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			inside = false;
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
