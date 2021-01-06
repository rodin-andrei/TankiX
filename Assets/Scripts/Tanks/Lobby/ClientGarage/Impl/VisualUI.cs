using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class VisualUI : ECSBehaviour
	{
		[SerializeField]
		private RectTransform buttonsRoot;
		[SerializeField]
		private GameObject ammoButton;
		[SerializeField]
		private GameObject paintButton;
		[SerializeField]
		private GameObject coverButton;
		[SerializeField]
		private GameObject graffitiRoot;
		[SerializeField]
		private VisualUIListSwitch visualUIListSwitch;
		[SerializeField]
		private DefaultListDataProvider dataProvider;
		[SerializeField]
		private GameObject buyButton;
		[SerializeField]
		private GameObject xBuyButton;
		[SerializeField]
		private GameObject containersButton;
		[SerializeField]
		private GameObject equipButton;
		[SerializeField]
		private GaragePrice price;
		[SerializeField]
		private GaragePrice xPrice;
		[SerializeField]
		private TextMeshProUGUI itemName;
		[SerializeField]
		private float cameraOffset;
	}
}
