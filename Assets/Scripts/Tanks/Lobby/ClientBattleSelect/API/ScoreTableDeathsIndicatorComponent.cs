using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableDeathsIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI deathsText;

		public int Deaths
		{
			get
			{
				return int.Parse(deathsText.text);
			}
			set
			{
				deathsText.text = value.ToString();
			}
		}
	}
}
