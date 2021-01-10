using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class RankedBattleGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin leagueIcon;
		[SerializeField]
		private TextMeshProUGUI leagueName;
		[SerializeField]
		private LocalizedField costTextLocalization;
	}
}
