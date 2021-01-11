using System;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class PauseSystem : ECSSystem
	{
		[Not(typeof(PauseComponent))]
		public class UnpausedUserNode : Node
		{
			public BattleUserComponent battleUser;

			public SelfBattleUserComponent selfBattleUser;

			public UserGroupComponent userGroup;
		}

		public class PausedUserNode : Node
		{
			public BattleUserComponent battleUser;

			public SelfBattleUserComponent selfBattleUser;

			public UserGroupComponent userGroup;

			public PauseComponent pause;
		}

		[Not(typeof(SelfDestructionComponent))]
		public class ActiveTankNode : Node
		{
			public TankComponent tank;

			public SelfTankComponent selfTank;

			public UserGroupComponent userGroup;

			public TankActiveStateComponent tankActiveState;

			public TankGroupComponent tankGroup;

			public ChassisComponent chassis;
		}

		public class WeaponNode : Node
		{
			public TankGroupComponent tankGroup;

			public WeaponRotationControlComponent weaponRotationControl;
		}

		[Not(typeof(PauseComponent))]
		public class UnpausedUnfocusedUserNode : Node
		{
			public BattleUserComponent battleUser;

			public UnfocusedUserComponent unfocusedUser;
		}

		[Not(typeof(UnfocusedUserComponent))]
		public class FocusedUserNode : Node
		{
			public BattleUserComponent battleUser;
		}

		public class SemiActiveSelfTankNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankSemiActiveStateComponent tankSemiActiveState;

			public SelfTankComponent selfTank;
		}

		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		[OnEventFire]
		public void OnUpdate(UpdateEvent e, UnpausedUserNode user, [JoinByUser] ActiveTankNode tank, [JoinByTank] WeaponNode weaponNode)
		{
			if (InputManager.GetActionKeyDown(BattleActions.PAUSE) && IsNearZero(weaponNode.weaponRotationControl.Control) && IsNearZero(tank.chassis.MoveAxis) && IsNearZero(tank.chassis.TurnAxis))
			{
				EnterPause(user.Entity);
			}
		}

		[OnEventFire]
		public void OnUpdate(UpdateEvent e, PausedUserNode user)
		{
			if (IsAnyKeyPressed() || IsMouseMovement())
			{
				LeavePause(user.Entity);
			}
		}

		[OnEventFire]
		public void OnApplicationFocusLost(ApplicationFocusEvent e, UnpausedUserNode user, [JoinByUser] ActiveTankNode tank)
		{
			if (!e.IsFocused && ShouldPauseOnFocusLoss())
			{
				EnterPause(user.Entity);
			}
		}

		[OnEventFire]
		public void MarkUserOnApplicationFocusLost(ApplicationFocusEvent e, FocusedUserNode user)
		{
			if (!e.IsFocused)
			{
				user.Entity.AddComponent<UnfocusedUserComponent>();
			}
		}

		[OnEventFire]
		public void UnmarkUserOnApplicationFocusReturns(ApplicationFocusEvent e, SingleNode<UnfocusedUserComponent> user)
		{
			if (e.IsFocused)
			{
				user.Entity.RemoveComponent<UnfocusedUserComponent>();
			}
		}

		[OnEventFire]
		public void ForcePauseSemiActiveTankUser(NodeAddedEvent e, SemiActiveSelfTankNode tank, [JoinByUser] UnpausedUnfocusedUserNode user)
		{
			if (ShouldPauseOnFocusLoss())
			{
				EnterPause(user.Entity);
			}
		}

		[OnEventFire]
		public void ForcePauseActiveTankUserUser(NodeAddedEvent e, ActiveTankNode tank, [JoinByUser] UnpausedUnfocusedUserNode user)
		{
			if (ShouldPauseOnFocusLoss())
			{
				EnterPause(user.Entity);
			}
		}

		[OnEventFire]
		public void OnApplicationFocusEvent(ApplicationFocusEvent e, PausedUserNode user)
		{
			if (e.IsFocused)
			{
				LeavePause(user.Entity);
			}
		}

		private void LeavePause(Entity user)
		{
			base.Log.Info("LeavePause");
			ScheduleEvent<UnpauseEvent>(user);
		}

		private void EnterPause(Entity user)
		{
			base.Log.Info("EnterPause");
			ScheduleEvent<PauseEvent>(user);
		}

		private bool IsMouseMovement()
		{
			return InputManager.GetAxis(CameraRotationActions.MOUSEX_ROTATE) != 0f || InputManager.GetAxis(CameraRotationActions.MOUSEY_ROTATE) != 0f || InputManager.GetAxis(CameraRotationActions.MOUSEY_MOVE_SHAFT_AIM) != 0f;
		}

		private bool IsAnyKeyPressed()
		{
			return InputManager.IsAnyKey();
		}

		private bool IsNearZero(float value)
		{
			return (double)Math.Abs(value) < 0.001;
		}

		private bool ShouldPauseOnFocusLoss()
		{
			return !Application.isEditor;
		}
	}
}
