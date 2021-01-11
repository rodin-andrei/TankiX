using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableEmptyRowIndicatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text text;

		public string Text
		{
			get
			{
				return text.text;
			}
			set
			{
				text.text = value;
			}
		}
	}
}
