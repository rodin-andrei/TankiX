using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SettingsSlotsUIComponent : BehaviourComponent
	{
		[Serializable]
		public class SettingsSlotUIItem
		{
			public Slot slot;

			public SettingsSlotUIComponent settingsSlotUI;
		}

		[SerializeField]
		private List<SettingsSlotUIItem> slots;

		public SettingsSlotUIComponent GetSlot(Slot slot)
		{
			return (!slots.Any((SettingsSlotUIItem s) => s.slot.Equals(slot))) ? null : slots.First((SettingsSlotUIItem s) => s.slot.Equals(slot)).settingsSlotUI;
		}
	}
}
