using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyConfirmationDialog : ECSBehaviour
	{
		[SerializeField]
		private GameObject buyButton;
		[SerializeField]
		private GameObject xBuyButton;
		[SerializeField]
		private TextMeshProUGUI confirmationText;
		[SerializeField]
		private TextMeshProUGUI price;
		[SerializeField]
		private TextMeshProUGUI xPrice;
		[SerializeField]
		private LocalizedField confirmation;
		[SerializeField]
		private GameObject confirmationDialog;
		[SerializeField]
		private GameObject addXCryDialog;
		[SerializeField]
		private GameObject addCryDialog;
		[SerializeField]
		private LocalizedField addXCryText;
		[SerializeField]
		private LocalizedField addCryText;
		[SerializeField]
		private TextMeshProUGUI addXCry;
		[SerializeField]
		private TextMeshProUGUI addCry;
	}
}
