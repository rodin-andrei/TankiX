using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleDetailsIndicatorsComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject scoreIndicator;
		[SerializeField]
		private GameObject timeIndicator;
		[SerializeField]
		private BattleLevelsIndicatorComponent battleLevelsIndicator;
		[SerializeField]
		private LevelWarningComponent levelWarning;
		[SerializeField]
		private GameObject archivedBattleIndicator;
	}
}
