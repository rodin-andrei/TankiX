using Platform.Library.ClientUnityIntegration.API;
using System;
using Tanks.Lobby.ClientGarage.API;
using System.Collections.Generic;
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
		private List<SettingsSlotsUIComponent.SettingsSlotUIItem> slots;
	}
}
