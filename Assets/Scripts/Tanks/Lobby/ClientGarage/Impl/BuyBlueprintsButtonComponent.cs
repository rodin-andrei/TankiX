using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class BuyBlueprintsButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI titleText;
		[SerializeField]
		private LocalizedField buyBlueprintButtonLocalizedField;
	}
}
