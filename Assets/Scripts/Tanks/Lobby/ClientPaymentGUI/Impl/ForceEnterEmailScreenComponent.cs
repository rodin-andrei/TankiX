using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ForceEnterEmailScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI confirmButton;
		[SerializeField]
		private TextMeshProUGUI rightPanelHint;
		[SerializeField]
		private TextMeshProUGUI placeholder;
	}
}
