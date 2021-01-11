using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class TeamBattleScoreIndicatorContainerComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject TDMScoreIndicator;

		[SerializeField]
		private GameObject CTFScoreIndicator;

		public GameObject TdmScoreIndicator
		{
			get
			{
				return TDMScoreIndicator;
			}
			set
			{
				TDMScoreIndicator = value;
			}
		}

		public GameObject CtfScoreIndicator
		{
			get
			{
				return CTFScoreIndicator;
			}
			set
			{
				CTFScoreIndicator = value;
			}
		}
	}
}
