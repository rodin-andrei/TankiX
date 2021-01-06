using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class MainHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private HPBar hpBar;
		[SerializeField]
		private HPBarGlow hpBar2;
		[SerializeField]
		private EnergyBar energyBar;
		[SerializeField]
		private EnergyBarGlow energyBar2;
		public BattleHudRootComponent battleHudRoot;
		[SerializeField]
		private TextAnimation message;
		[SerializeField]
		private GameObject battleLog;
		[SerializeField]
		private GameObject inventory;
	}
}
