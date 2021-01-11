using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableKillsIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI killsText;

		public int Kills
		{
			get
			{
				return int.Parse(killsText.text);
			}
			set
			{
				killsText.text = value.ToString();
			}
		}
	}
}
