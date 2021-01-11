using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class IdleKickSystem : ECSSystem
	{
		public class BattleUserNode : Node
		{
			public SelfComponent self;

			public BattleUserComponent battleUser;

			public IdleCounterComponent idleCounter;

			public IdleBeginTimeComponent idleBeginTime;

			public IdleKickConfigComponent idleKickConfig;

			public IdleKickCheckLastTimeComponent idleKickCheckLastTime;
		}

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		[OnEventFire]
		public void Sync(IdleBeginTimeSyncEvent e, BattleUserNode battleUser)
		{
			battleUser.idleBeginTime.IdleBeginTime = e.IdleBeginTime;
		}

		[OnEventFire]
		public void InputListner(UpdateEvent e, BattleUserNode user)
		{
			int checkPeriodicTimeSec = user.idleKickConfig.CheckPeriodicTimeSec;
			if (InputManager.IsAnyKey() || IsMouseMovement())
			{
				Date now = Date.Now;
				if (now - user.idleKickCheckLastTime.CheckLastTime > (float)checkPeriodicTimeSec)
				{
					ScheduleEvent<ResetIdleKickTimeEvent>(user);
					user.idleKickCheckLastTime.CheckLastTime = now;
				}
			}
		}

		private bool IsMouseMovement()
		{
			return InputManager.GetAxis(CameraRotationActions.MOUSEX_ROTATE) != 0f || InputManager.GetAxis(CameraRotationActions.MOUSEY_ROTATE) != 0f || InputManager.GetAxis(CameraRotationActions.MOUSEY_MOVE_SHAFT_AIM) != 0f;
		}
	}
}
