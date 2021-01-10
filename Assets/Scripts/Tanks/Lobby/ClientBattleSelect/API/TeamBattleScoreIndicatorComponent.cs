using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class TeamBattleScoreIndicatorComponent : MonoBehaviour
	{
		[SerializeField]
		private Text blueTeamScoreText;
		[SerializeField]
		private Text redTeamScoreText;
		[SerializeField]
		private ProgressBar blueScoreProgress;
		[SerializeField]
		private ProgressBar redScoreProgress;
	}
}
