using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CollectionSlotView : SlotView
	{
		public ImageSkin moduleIcon;
		public TextMeshProUGUI improveAvailableText;
		public TextMeshProUGUI researchAvailableText;
		public TextMeshProUGUI cardCountText;
		public Color yelloColor;
		public SlotInteractive interactive;
	}
}
