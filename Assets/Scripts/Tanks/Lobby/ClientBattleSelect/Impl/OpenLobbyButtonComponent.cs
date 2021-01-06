using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class OpenLobbyButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI _buttonText;
		[SerializeField]
		private LocalizedField _openText;
		[SerializeField]
		private LocalizedField _openTooltipText;
		[SerializeField]
		private LocalizedField _shareTooltipText;
		[SerializeField]
		private TooltipShowBehaviour _tooltip;
		[SerializeField]
		private GaragePrice _price;
	}
}
