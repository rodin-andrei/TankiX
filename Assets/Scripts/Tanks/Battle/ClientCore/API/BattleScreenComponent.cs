using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BattleScreenComponent : ECSBehaviour
	{
		public GameObject hud;
		public GameObject topPanel;
		public GameObject tankInfo;
		public GameObject battleChat;
		public GameObject combatEventLog;
		public bool showTankInfo;
		public bool showBattleChat;
		public bool showCombatEventLog;
	}
}
