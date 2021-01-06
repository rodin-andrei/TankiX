using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SpecialOfferPriceButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private string priceRegularFormatting;
		[SerializeField]
		private string priceDiscountedFormatting;
		[SerializeField]
		private TextMeshProUGUI priceText;
	}
}
