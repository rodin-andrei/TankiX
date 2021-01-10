using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleInfoPanelComponent : LocalizedControl
	{
		[SerializeField]
		private Text slotText;
		[SerializeField]
		private Text moduleNameText;
		[SerializeField]
		private Text mountLabelText;
		[SerializeField]
		private RectTransform slotInfoPanel;
		[SerializeField]
		private ImageSkin slotInfoSlotIcon;
		[SerializeField]
		private ImageSkin slotInfoModuleIcon;
		[SerializeField]
		private ImageSkin slotInfoLockIcon;
		[SerializeField]
		private Text moduleDescriptionText;
		[SerializeField]
		private CardPriceLabelComponent priceLabel;
		[SerializeField]
		private Text moduleExceptionalText;
		[SerializeField]
		private Text moduleEpicText;
		[SerializeField]
		private GameObject defenceIcon;
		[SerializeField]
		private GameObject scoutingIcon;
		[SerializeField]
		private GameObject specialIcon;
		[SerializeField]
		private GameObject supportIcon;
		[SerializeField]
		private Text specialText;
		[SerializeField]
		private Text scoutingText;
		[SerializeField]
		private Text defenceText;
		[SerializeField]
		private Text supportText;
	}
}
