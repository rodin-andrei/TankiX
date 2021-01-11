using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class TeamBattleResultsScreenComponent : LocalizedScreenComponent, NoScaleScreen
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

		public void Init(string mode, int blueScore, int redScore, string mapName, bool spectator)
		{
			this.blueScore.text = blueScore.ToString();
			this.redScore.text = redScore.ToString();
			blueTeamTitleForSpectator.gameObject.SetActive(spectator);
			redTeamTitleForSpectator.gameObject.SetActive(spectator);
			blueTeamTitle.gameObject.SetActive(!spectator);
			redTeamTitle.gameObject.SetActive(!spectator);
		}
	}
}
