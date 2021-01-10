using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPScreenUIComponent : BehaviourComponent
	{
		[SerializeField]
		private MVPUserMainInfoComponent userInfo;
		[SerializeField]
		private MVPMainStatComponent mainStat;
		[SerializeField]
		private MVPOtherStatComponent otherStat;
		[SerializeField]
		private MVPTankInfoComponent tankInfo;
		[SerializeField]
		private MVPModulesInfoComponent modulesInfo;
		[SerializeField]
		private TimerWithAction continueTimer;
		[SerializeField]
		private float timeIfMvpIsNotPlayer;
		[SerializeField]
		private float timeIfMvpIsPlayer;
	}
}
