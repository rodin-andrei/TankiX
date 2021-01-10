using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PlayScreenSeasonGUIComponent : TextTimerComponent
	{
		[SerializeField]
		private LocalizedField seasonNumberTextLocalization;
		[SerializeField]
		private TextMeshProUGUI seasonNumberText;
	}
}
