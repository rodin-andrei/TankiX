using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientPaymentGUI.Impl;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GoldBoxesPackComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _cardNameText;
		[SerializeField]
		private TextMeshProUGUI _boxCountText;
		[SerializeField]
		private ImageSkin _imageSkin;
		[SerializeField]
		private TextMeshProUGUI _priceText;
		[SerializeField]
		private GameObject _hitMarkObject;
		[SerializeField]
		private GameObject _discountMarkObject;
		[SerializeField]
		private TextMeshProUGUI _discountMarkText;
		[SerializeField]
		private PurchaseButtonComponent _purchaseButton;
	}
}
