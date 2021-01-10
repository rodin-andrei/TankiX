using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class SynthUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TMP_InputField crystals;
		[SerializeField]
		private TMP_InputField xCrystals;
		[SerializeField]
		private long defaultXCrystalsAmount;
		[SerializeField]
		private Animator synthButtonAnimator;
		[SerializeField]
		private ExchangeConfirmationWindow exchangeConfirmation;
	}
}
