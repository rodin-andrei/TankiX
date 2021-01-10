using Tanks.Battle.ClientHUD.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class AnimatedMoneyIndicator : AnimatedIndicatorWithFinishComponent<PersonalBattleResultMoneyIndicatorFinishedComponent>
	{
		[SerializeField]
		private UserMoneyIndicatorComponent indicator;
		[SerializeField]
		private Text deltaValue;
	}
}
