using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class InventoryHUDComponent : BehaviourComponent, AttachToEntityListener
	{
		[Serializable]
		public class SlotUIItem
		{
			public Slot slot;

			public RectTransform slotRectTransform;
		}

		[SerializeField]
		private List<SlotUIItem> slots;

		[SerializeField]
		private EntityBehaviour modulePrefab;

		[SerializeField]
		private GameObject goldBonusCounterPrefab;

		private List<GameObject> modules = new List<GameObject>();

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		public EntityBehaviour CreateModule(Slot slot)
		{
			base.gameObject.SetActive(true);
			RectTransform slotRectTransform = GetSlotRectTransform(slot);
			EntityBehaviour result = Instantiate(modulePrefab, slotRectTransform);
			SendMessage("RefreshCurve", SendMessageOptions.DontRequireReceiver);
			return result;
		}

		private T Instantiate<T>(T prefab, RectTransform parent) where T : UnityEngine.Component
		{
			parent.GetChild(0).gameObject.SetActive(false);
			T result = UnityEngine.Object.Instantiate(prefab, parent, false);
			modules.Add(result.gameObject);
			RectTransform rectTransform = (RectTransform)result.transform;
			rectTransform.anchorMin = default(Vector2);
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchoredPosition = default(Vector2);
			rectTransform.sizeDelta = default(Vector2);
			return result;
		}

		public void AttachedToEntity(Entity entity)
		{
			base.gameObject.SetActive(false);
			foreach (GameObject module in modules)
			{
				UnityEngine.Object.DestroyImmediate(module);
			}
			modules.Clear();
			foreach (SlotUIItem slot in slots)
			{
				slot.slotRectTransform.GetChild(0).gameObject.SetActive(true);
			}
		}

		public void CreateGoldBonusesCounter(EntityBehaviour module)
		{
			UnityEngine.Object.Instantiate(goldBonusCounterPrefab, module.transform, false);
		}

		private RectTransform GetSlotRectTransform(Slot slot)
		{
			return slots.First((SlotUIItem s) => s.slot.Equals(slot)).slotRectTransform;
		}

		public string GetKeyBindForItem(ItemButtonComponent item)
		{
			string[] array = new string[5]
			{
				InventoryAction.INVENTORY_SLOT1,
				InventoryAction.INVENTORY_SLOT2,
				InventoryAction.INVENTORY_SLOT3,
				InventoryAction.INVENTORY_SLOT4,
				InventoryAction.INVENTORY_GOLDBOX
			};
			Transform parent = item.transform.parent.parent;
			for (int i = 0; i < array.Length; i++)
			{
				Transform child = parent.GetChild(i);
				if (item.transform.parent == child)
				{
					InputAction action = InputManager.GetAction(new InputActionId("Tanks.Battle.ClientCore.Impl.InventoryAction", array[i]), new InputActionContextId("Tanks.Battle.ClientCore.Impl.BasicContexts"));
					if (action == null || action.keys.Length == 0)
					{
						return string.Empty;
					}
					return KeyboardSettingsUtil.KeyCodeToString(action.keys[0]);
				}
			}
			return string.Empty;
		}
	}
}
