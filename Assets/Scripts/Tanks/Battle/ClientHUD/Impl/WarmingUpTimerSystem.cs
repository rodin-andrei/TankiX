using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class WarmingUpTimerSystem : ECSSystem
	{
		public class RoundWarmingUpStateNode : Node
		{
			public RoundStopTimeComponent roundStopTime;

			public RoundActiveStateComponent roundActiveState;

			public RoundWarmingUpStateComponent roundWarmingUpState;
		}

		public class MainHUDNode : Node
		{
			public MainHUDComponent mainHUD;

			public MainHUDTimersComponent mainHUDTimers;
		}

		[OnEventFire]
		public void ShowWarmingUpTimer(NodeAddedEvent e, RoundWarmingUpStateNode round, MainHUDNode hud)
		{
			hud.mainHUDTimers.ShowWarmingUpTimer();
		}

		[OnEventFire]
		public void HideWarmingUpTimer(NodeRemoveEvent e, RoundWarmingUpStateNode round, MainHUDNode hud)
		{
			hud.mainHUDTimers.HideWarmingUpTimer();
		}
	}
}
