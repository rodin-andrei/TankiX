using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientPaymentGUI.Impl;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PremiumPackComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _daysText;
		[SerializeField]
		private TextMeshProUGUI _daysDescriptionText;
		[SerializeField]
		private TextMeshProUGUI _priceText;
		[SerializeField]
		private GameObject _xCrystals;
		[SerializeField]
		private GameObject _saleContainer;
		[SerializeField]
		private TextMeshProUGUI _salePercentText;
		[SerializeField]
		private PremiumLearnMoreButtonComponent _learnMoreButton;
		[SerializeField]
		private PurchaseButtonComponent _premiumPurchaseButton;
	}
}
