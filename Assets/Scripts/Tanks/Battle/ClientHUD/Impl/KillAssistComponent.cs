using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.Impl;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class KillAssistComponent : BehaviourComponent
	{
		public CombatEventLog combatEventLog;
		public AnimatedLong scoreTotalNumber;
		public Animator totalNumberAnimator;
		public LocalizedField flagDeliveryMessage;
		public LocalizedField flagReturnMessage;
		public LocalizedField killMessage;
		public LocalizedField assistMessage;
		public LocalizedField healMessage;
		public LocalizedField streakMessage;
	}
}
