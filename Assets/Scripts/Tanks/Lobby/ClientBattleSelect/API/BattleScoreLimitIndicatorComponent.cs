using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleScoreLimitIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text scoreLimitText;

		public int ScoreLimit
		{
			get
			{
				return int.Parse(scoreLimitText.text);
			}
			set
			{
				scoreLimitText.text = value.ToString();
			}
		}
	}
}
