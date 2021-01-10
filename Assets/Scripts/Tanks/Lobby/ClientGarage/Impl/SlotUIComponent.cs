using UnityEngine.EventSystems;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotUIComponent : UIBehaviour
	{
		[SerializeField]
		private ImageSkin moduleIconImageSkin;
		[SerializeField]
		private PaletteColorField exceptionalColor;
		[SerializeField]
		private PaletteColorField epicColor;
		[SerializeField]
		private Image moduleIcon;
		[SerializeField]
		private Image selectionImage;
		[SerializeField]
		private Image lockIcon;
		[SerializeField]
		private Image upgradeIcon;
		[SerializeField]
		private TextMeshProUGUI slotName;
		[SerializeField]
		private LocalizedField slotNameLocalization;
	}
}
