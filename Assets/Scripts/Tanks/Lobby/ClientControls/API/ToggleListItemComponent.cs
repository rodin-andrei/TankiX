using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Toggle))]
	public class ToggleListItemComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener
	{
		private Entity entity;

		public Entity Entity
		{
			get
			{
				return entity;
			}
		}

		public Toggle Toggle
		{
			get
			{
				return GetComponent<Toggle>();
			}
		}

		public event Action<bool> onValueChanged = delegate
		{
		};

		private void Start()
		{
			AttachToParentToggleGroup();
		}

		public void AttachToParentToggleGroup()
		{
			Toggle.group = GetComponentInParent<ToggleGroup>();
		}

		public void OnValueChangedListener()
		{
			if (Toggle.isOn)
			{
				if (entity.HasComponent<ToggleListSelectedItemComponent>())
				{
					entity.RemoveComponent<ToggleListSelectedItemComponent>();
				}
				entity.AddComponent<ToggleListSelectedItemComponent>();
			}
			else if (entity.HasComponent<ToggleListSelectedItemComponent>())
			{
				entity.RemoveComponent<ToggleListSelectedItemComponent>();
			}
			this.onValueChanged(Toggle.isOn);
		}

		public void AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		private void OnDisable()
		{
			if (Toggle.isOn)
			{
				Toggle.isOn = false;
			}
		}
	}
}
