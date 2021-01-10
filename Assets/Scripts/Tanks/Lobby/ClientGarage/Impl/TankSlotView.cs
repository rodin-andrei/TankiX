using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class TankSlotView : SlotView
	{
		public Image lockIcon;
		public LocalizedField emptySlotTooltipText;
		[SerializeField]
		private LocalizedField lockedSlotTooltipText;
		[SerializeField]
		private LocalizedField turretLockedSlotText;
		[SerializeField]
		private LocalizedField hullLockedSlotText;
		[SerializeField]
		private GameObject border;
	}
}
