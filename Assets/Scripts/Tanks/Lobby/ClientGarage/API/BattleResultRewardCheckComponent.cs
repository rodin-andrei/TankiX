using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class BattleResultRewardCheckComponent : BehaviourComponent
	{
		[SerializeField]
		private long quickBattleEndTutorialId;

		public long QuickBattleEndTutorialId
		{
			get
			{
				return quickBattleEndTutorialId;
			}
		}
	}
}
