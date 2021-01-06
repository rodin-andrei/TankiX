using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class TeamBattleResultsScreenComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI blueScore;
		[SerializeField]
		private TextMeshProUGUI redScore;
		[SerializeField]
		private TextMeshProUGUI blueTeamTitle;
		[SerializeField]
		private TextMeshProUGUI redTeamTitle;
		[SerializeField]
		private TextMeshProUGUI blueTeamTitleForSpectator;
		[SerializeField]
		private TextMeshProUGUI redTeamTitleForSpectator;
	}
}
