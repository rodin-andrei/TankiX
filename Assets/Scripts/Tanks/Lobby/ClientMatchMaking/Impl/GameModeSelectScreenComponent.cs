using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class GameModeSelectScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject gameModeItemPrefab;

		[SerializeField]
		private GameObject gameModesContainer;

		[SerializeField]
		private GameObject mainGameModeContainer;

		[SerializeField]
		private TextMeshProUGUI mmLevel;

		public GameObject GameModeItemPrefab
		{
			get
			{
				return gameModeItemPrefab;
			}
		}

		public GameObject GameModesContainer
		{
			get
			{
				return gameModesContainer;
			}
		}

		public GameObject MainGameModeContainer
		{
			get
			{
				return mainGameModeContainer;
			}
		}

		public int MMLevel
		{
			set
			{
				mmLevel.text = value.ToString();
			}
		}
	}
}
