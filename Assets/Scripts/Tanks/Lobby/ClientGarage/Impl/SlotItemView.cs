using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotItemView : MonoBehaviour
	{
		public GameObject moduleCard3DPrefab;
		public GameObject itemContent;
		public TooltipShowBehaviour tooltip;
		public Animator outline;
		public Color pressedColor;
		public Color highlidhtedColor;
		public Color upgradeColor;
		public float selectionSaturation;
		public float highlightedSaturation;
	}
}
