using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;

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
	}
}
