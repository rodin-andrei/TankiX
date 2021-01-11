using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BattlePingSystem : ECSSystem
	{
		public class SelfBattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public UserReadyToBattleComponent userReadyToBattle;
		}

		public class BattleUserWithPingNode : Node
		{
			public BattlePingComponent battlePing;
		}

		[Inject]
		public static UnityTime UnityTime
		{
			get;
			set;
		}

		[OnEventFire]
		public void Init(NodeAddedEvent e, SelfBattleUserNode battleUser)
		{
			ScheduleManager periodicEventManager = NewEvent<PeriodicPingStartEvent>().Attach(battleUser).SchedulePeriodic(10f).Manager();
			BattlePingComponent battlePingComponent = new BattlePingComponent();
			battlePingComponent.PeriodicEventManager = periodicEventManager;
			battleUser.Entity.AddComponent(battlePingComponent);
		}

		[OnEventComplete]
		public void Deinit(NodeRemoveEvent e, SelfBattleUserNode battleUser)
		{
			battleUser.Entity.RemoveComponentIfPresent<BattlePingComponent>();
		}

		[OnEventFire]
		public void CancelEvent(NodeRemoveEvent e, SingleNode<BattlePingComponent> battleUser)
		{
			battleUser.component.PeriodicEventManager.Cancel();
		}

		[OnEventFire]
		public void PeriodicPing(PeriodicPingStartEvent e, BattleUserWithPingNode battleUser)
		{
			float realtimeSinceStartup = UnityTime.realtimeSinceStartup;
			if (!(realtimeSinceStartup < battleUser.battlePing.LastPingTime + 5f))
			{
				battleUser.battlePing.LastPingTime = realtimeSinceStartup;
				BattlePingEvent battlePingEvent = new BattlePingEvent();
				battlePingEvent.ClientSendRealTime = UnityTime.realtimeSinceStartup;
				ScheduleEvent(battlePingEvent, battleUser);
			}
		}

		[OnEventFire]
		public void OnPong(BattlePongEvent e, BattleUserWithPingNode battleUser)
		{
			BattlePingResultEvent battlePingResultEvent = new BattlePingResultEvent();
			battlePingResultEvent.ClientSendRealTime = e.ClientSendRealTime;
			battlePingResultEvent.ClientReceiveRealTime = UnityTime.realtimeSinceStartup;
			int ping = (int)(1000f * Mathf.Clamp(UnityTime.realtimeSinceStartup - e.ClientSendRealTime, 0f, 10f));
			battleUser.battlePing.add(ping);
			ScheduleEvent(battlePingResultEvent, battleUser);
		}
	}
}
