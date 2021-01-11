using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleSelectableComponent : ECSBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener
	{
		private Entity entity;

		[SerializeField]
		private GameObject selection;

		private bool hasSelected;

		private event Action<SimpleSelectableComponent, bool> selectEvent = delegate
		{
		};

		private event Action<SimpleSelectableComponent> destroyEvent = delegate
		{
		};

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		public void Awake()
		{
			selection.SetActive(false);
		}

		public void ChangeState()
		{
			Select(true);
		}

		public void Select(bool selected)
		{
			if (hasSelected != selected)
			{
				this.selectEvent(this, selected);
				if (selected)
				{
					ScheduleEvent<ListItemSelectedEvent>(entity);
				}
				else
				{
					ScheduleEvent<ListItemDeselectedEvent>(entity);
				}
				hasSelected = selected;
				selection.SetActive(selected);
			}
		}

		public void AddHandler(Action<SimpleSelectableComponent, bool> handler)
		{
			selectEvent += handler;
		}

		public void AddDestroyHandler(Action<SimpleSelectableComponent> handler)
		{
			destroyEvent += handler;
		}

		private void OnDestroy()
		{
			this.destroyEvent(this);
		}
	}
}
