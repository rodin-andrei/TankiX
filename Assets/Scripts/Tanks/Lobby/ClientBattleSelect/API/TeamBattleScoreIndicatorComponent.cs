using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class TeamBattleScoreIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text blueTeamScoreText;

		[SerializeField]
		private Text redTeamScoreText;

		[SerializeField]
		private ProgressBar blueScoreProgress;

		[SerializeField]
		private ProgressBar redScoreProgress;

		public void UpdateScore(int blueScore, int redScore, int scoreLimit)
		{
			blueTeamScoreText.text = blueScore.ToString();
			redTeamScoreText.text = redScore.ToString();
			blueScoreProgress.ProgressValue = ((scoreLimit <= 0) ? 0f : ((float)blueScore / (float)scoreLimit));
			redScoreProgress.ProgressValue = ((scoreLimit <= 0) ? 0f : ((float)redScore / (float)scoreLimit));
		}
	}
}
