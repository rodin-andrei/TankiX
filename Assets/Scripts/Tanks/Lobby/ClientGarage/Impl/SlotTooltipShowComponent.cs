using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotTooltipShowComponent : TooltipShowBehaviour
	{
		[SerializeField]
		private GameObject slotLockedTooltip;
		[SerializeField]
		private GameObject moduleTooltip;
		[SerializeField]
		private LocalizedField slotLockedTitle;
		[SerializeField]
		private LocalizedField weaponSlotLocked;
		[SerializeField]
		private LocalizedField hullSlotLocked;
		[SerializeField]
		private LocalizedField emptySlot;
		[SerializeField]
		private PaletteColorField lockedHeaderColor;
	}
}
