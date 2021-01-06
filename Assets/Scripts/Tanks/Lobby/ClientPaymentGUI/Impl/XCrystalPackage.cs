using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class XCrystalPackage : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin[] preview;
		[SerializeField]
		private TextMeshProUGUI amount;
		[SerializeField]
		private TextMeshProUGUI price;
		[SerializeField]
		private TextMeshProUGUI totalAmount;
		[SerializeField]
		private LocalizedField forFree;
		[SerializeField]
		private PaletteColorField greyColor;
		[SerializeField]
		private GameObject giftLabel;
		[SerializeField]
		private ImageSkin giftPreview;
		[SerializeField]
		private int xCrySpriteIndex;
		[SerializeField]
		private LocalizedField _commonString;
		[SerializeField]
		private LocalizedField _rareString;
		[SerializeField]
		private LocalizedField _epicString;
		[SerializeField]
		private LocalizedField _legendaryString;
	}
}
