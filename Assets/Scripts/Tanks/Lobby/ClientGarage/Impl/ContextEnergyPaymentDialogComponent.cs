using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContextEnergyPaymentDialogComponent : BehaviourComponent
	{
		[SerializeField]
		private LocalizedField highlightmMessageLocalization;
		[SerializeField]
		private LocalizedField messageLocalization;
		[SerializeField]
		private LocalizedField priceLocalization;
		[SerializeField]
		private TextMeshProUGUI messageText;
		[SerializeField]
		private TextMeshProUGUI priceText;
	}
}
