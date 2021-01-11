using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class DoubleClickHandler : ECSBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, IPointerDownHandler, AttachToEntityListener, IEventSystemHandler
	{
		[Serializable]
		public class FirstClickEvent : UnityEvent
		{
		}

		private Entity entity;

		private float delta = 0.2f;

		private float time;

		public FirstClickEvent FirstClick = new FirstClickEvent();

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				if (Time.realtimeSinceStartup - time < delta)
				{
					ScheduleEvent<DoubleClickEvent>(entity);
					time = 0f;
				}
				else
				{
					time = Time.realtimeSinceStartup;
				}
			}
		}

		private void Update()
		{
			if (time != 0f && Time.realtimeSinceStartup - time > delta)
			{
				time = 0f;
				FirstClick.Invoke();
			}
		}
	}
}
