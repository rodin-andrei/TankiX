using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class WarningWindowComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI info;
		[SerializeField]
		private TextMeshProUGUI warning;
		[SerializeField]
		private LocalizedField warningText;
		[SerializeField]
		private PaletteColorField xCrystalColor;
	}
}
