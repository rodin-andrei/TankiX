using Platform.Library.ClientUnityIntegration.API;
using System;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class InventoryHUDComponent : BehaviourComponent
	{
		[Serializable]
		public class SlotUIItem
		{
			public Slot slot;
			public RectTransform slotRectTransform;
		}

		[SerializeField]
		private List<InventoryHUDComponent.SlotUIItem> slots;
		[SerializeField]
		private EntityBehaviour modulePrefab;
		[SerializeField]
		private GameObject goldBonusCounterPrefab;
	}
}
