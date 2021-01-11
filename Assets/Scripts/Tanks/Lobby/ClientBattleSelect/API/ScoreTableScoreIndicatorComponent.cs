using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableScoreIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI scoreText;

		public int Score
		{
			get
			{
				return int.Parse(scoreText.text);
			}
			set
			{
				scoreText.text = value.ToString();
			}
		}
	}
}
