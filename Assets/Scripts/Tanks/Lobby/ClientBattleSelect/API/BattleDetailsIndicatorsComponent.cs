using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class BattleDetailsIndicatorsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
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

		public GameObject ScoreIndicator
		{
			get
			{
				return scoreIndicator;
			}
		}

		public GameObject TimeIndicator
		{
			get
			{
				return timeIndicator;
			}
		}

		public BattleLevelsIndicatorComponent BattleLevelsIndicator
		{
			get
			{
				return battleLevelsIndicator;
			}
		}

		public LevelWarningComponent LevelWarning
		{
			get
			{
				return levelWarning;
			}
		}

		public GameObject ArchivedBattleIndicator
		{
			get
			{
				return archivedBattleIndicator;
			}
		}
	}
}
