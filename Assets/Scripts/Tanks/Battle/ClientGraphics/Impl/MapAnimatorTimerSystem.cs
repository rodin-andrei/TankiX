using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapAnimatorTimerSystem : ECSSystem
	{
		public class RoundNode : Node
		{
			public RoundComponent round;

			public BattleGroupComponent battleGroup;
		}

		public class ActiveRoundStopTimeNode : RoundNode
		{
			public RoundActiveStateComponent roundActiveState;

			public RoundStopTimeComponent roundStopTime;
		}

		public class MapAnimatorTimerNode : Node
		{
			public MapAnimatorTimerComponent mapAnimatorTimer;
		}

		public class SelfBattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void CheckRoundTimer(UpdateEvent e, MapAnimatorTimerNode mapAnimatorTimer, [JoinAll] SelfBattleUserNode battleUser, [JoinByBattle] ActiveRoundStopTimeNode round, [JoinAll] SingleNode<AnimatorTimerComponent> animatorTimer)
		{
			float num = round.roundStopTime.StopTime.UnityTime - Date.Now.UnityTime;
			if (!(num > animatorTimer.component.timer))
			{
				animatorTimer.component.animator.SetTrigger(animatorTimer.component.triggerName);
			}
		}
	}
}
