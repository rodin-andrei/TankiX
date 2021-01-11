using System;
using System.Collections.Generic;
using System.Linq;
using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class CTFPointersSystem : ECSSystem
	{
		public class EnemyBasePointer : Node
		{
			public EnemyBasePointerComponent enemyBasePointer;
		}

		public class EnemyFlagPointerNode : Node
		{
			public EnemyFlagPointerComponent enemyFlagPointer;
		}

		public class SelfBattleUser : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public UserReadyToBattleComponent userReadyToBattle;

			public TeamGroupComponent teamGroup;
		}

		public class FlagPedestalNode : Node
		{
			public FlagPedestalComponent flagPedestal;

			public TeamGroupComponent teamGroup;
		}

		public class FlagNode : Node
		{
			public TeamGroupComponent teamGroup;

			public BattleGroupComponent battleGroup;

			public FlagInstanceComponent flagInstance;

			public FlagColliderComponent flagCollider;
		}

		[Not(typeof(FlagHomeStateComponent))]
		public class FlagNotHomeNode : FlagNode
		{
		}

		public class FlagHomeNode : FlagNode
		{
			public FlagHomeStateComponent flagHomeState;
		}

		public class FlagGroundedNode : FlagNode
		{
			public FlagGroundedStateComponent flagGroundedState;
		}

		public class BattleCameraNode : Node
		{
			public CameraComponent camera;

			public BattleCameraComponent battleCamera;
		}

		private const float UP_OFFSET = 0.125f;

		private const float DOWN_OFFSET = 0.14f;

		private const float SIDE_OFFSET = 0.03f;

		private const float FLAG_HEIGHT = 5.5f;

		private const float DISTANCE = 20f;

		[OnEventFire]
		public void UpdateEnemyBasePointer(UpdateEvent e, EnemyBasePointer pointer, [JoinAll] SelfBattleUser user, [JoinAll] ICollection<FlagPedestalNode> pedestals, [JoinAll] BattleCameraNode battleCamera, [JoinAll] SingleNode<CTFComponent> ctfGameNode)
		{
			if (pedestals.Count >= 2)
			{
				FlagPedestalNode oppositeTeamPedestal = GetOppositeTeamPedestal(pedestals, user);
				SetBasePosition(pointer.enemyBasePointer, oppositeTeamPedestal.flagPedestal.Position, battleCamera.camera.UnityCamera);
			}
		}

		[OnEventFire]
		public void UpdateAlliesBasePointer(UpdateEvent e, SingleNode<AlliesBasePointerComponent> pointer, [JoinAll] SelfBattleUser user, [JoinByTeam] FlagPedestalNode pedestal, [JoinAll] BattleCameraNode battleCamera, [JoinAll] SingleNode<CTFComponent> ctfGameNode)
		{
			SetBasePosition(pointer.component, pedestal.flagPedestal.Position, battleCamera.camera.UnityCamera);
		}

		[OnEventFire]
		public void UpdateEnemyFlagPointer(UpdateEvent e, EnemyFlagPointerNode pointer, [JoinAll] SelfBattleUser user, [JoinByUser] HUDNodes.SelfTankNode selfTank, [JoinByBattle] ICollection<FlagNotHomeNode> flags, [JoinAll] BattleCameraNode battleCamera, [JoinAll] SingleNode<CTFComponent> ctfGameNode)
		{
			if (flags.Count >= 2)
			{
				FlagNotHomeNode oppositeTeamFlag = GetOppositeTeamFlag(flags, user);
				if (oppositeTeamFlag != null && NotFlagCarrier(selfTank, oppositeTeamFlag))
				{
					SetFlagPointerPosition(oppositeTeamFlag, pointer.enemyFlagPointer, battleCamera.camera.UnityCamera);
				}
				else
				{
					pointer.enemyFlagPointer.Hide();
				}
			}
		}

		[OnEventFire]
		public void UpdateAlliasFlagPointer(UpdateEvent e, SingleNode<AlliesFlagPointerComponent> pointer, [JoinAll] HUDNodes.SelfTankNode selfTank, [JoinByTeam] FlagNotHomeNode flag, [JoinAll] BattleCameraNode battleCamera, [JoinAll] SingleNode<CTFComponent> ctfGameNode)
		{
			if (NotFlagCarrier(selfTank, flag))
			{
				SetFlagPointerPosition(flag, pointer.component, battleCamera.camera.UnityCamera);
			}
			else
			{
				pointer.component.Hide();
			}
		}

		[OnEventFire]
		public void HidePointerWhenFlagHome(NodeAddedEvent e, [Combine] FlagHomeNode flag, SelfBattleUser user, [Context] SingleNode<AlliesFlagPointerComponent> alliesPointer, [Context] EnemyFlagPointerNode enemyPointer, [Context] SingleNode<AlliesBasePointerComponent> alliesBasePointer, [Context] EnemyBasePointer enemyBasePointer)
		{
			if (flag.teamGroup.Key == user.teamGroup.Key)
			{
				alliesPointer.component.Hide();
				alliesBasePointer.component.SetFlagAtHomeState();
			}
			else
			{
				enemyPointer.enemyFlagPointer.Hide();
				enemyBasePointer.enemyBasePointer.SetFlagAtHomeState();
			}
		}

		[OnEventFire]
		public void ChangeBaseIconWhenFlagNotHome(NodeRemoveEvent e, [Combine] FlagHomeNode flag, [JoinByTeam] FlagPedestalNode flagPedestal, [JoinAll] SelfBattleUser user, [JoinAll] SingleNode<AlliesBasePointerComponent> alliesPointer, [JoinAll] EnemyBasePointer enemyPointer)
		{
			SetFlagNotHomeIcon(flag, user, alliesPointer, enemyPointer);
		}

		[OnEventFire]
		public void ChangeBaseIconWhenFlagNotHome(NodeAddedEvent e, [Combine] FlagNotHomeNode flag, [JoinByTeam] FlagPedestalNode flagPedestal, SelfBattleUser user, [Context] SingleNode<AlliesBasePointerComponent> alliesPointer, [Context] EnemyBasePointer enemyPointer)
		{
			SetFlagNotHomeIcon(flag, user, alliesPointer, enemyPointer);
		}

		private void SetFlagNotHomeIcon(FlagNode flag, SelfBattleUser user, SingleNode<AlliesBasePointerComponent> alliesPointer, EnemyBasePointer enemyPointer)
		{
			if (flag.teamGroup.Key == user.teamGroup.Key)
			{
				alliesPointer.component.SetFlagStolenState();
			}
			else
			{
				enemyPointer.enemyBasePointer.SetFlagStolenState();
			}
		}

		[OnEventFire]
		public void ShowPointersInCTF(NodeAddedEvent e, SingleNode<CTFComponent> ctfGameNode, [Context] SingleNode<AlliesBasePointerComponent> alliesPointer, [Context] EnemyBasePointer enemyPointer, [Context] SelfBattleUser user)
		{
			alliesPointer.component.Show();
			enemyPointer.enemyBasePointer.Show();
		}

		[OnEventFire]
		public void ChangeFlagTextWhenGrounded(NodeAddedEvent e, [Combine] FlagGroundedNode flag, [Context] SelfBattleUser user, [Context] SingleNode<AlliesFlagPointerComponent> alliesPointer, [Context] EnemyFlagPointerNode enemyPointer)
		{
			if (user.teamGroup.Key == flag.teamGroup.Key)
			{
				alliesPointer.component.SetFlagOnTheGroundState();
			}
			else
			{
				enemyPointer.enemyFlagPointer.SetFlagOnTheGroundState();
			}
		}

		[OnEventFire]
		public void ChangeFlagTextWhenCaptured(NodeRemoveEvent e, [Combine] FlagGroundedNode flag, [Context] SelfBattleUser user, [Context] SingleNode<AlliesFlagPointerComponent> alliesPointer, [Context] EnemyFlagPointerNode enemyPointer)
		{
			if (user.teamGroup.Key == flag.teamGroup.Key)
			{
				alliesPointer.component.SetFlagCapturedState();
			}
			else
			{
				enemyPointer.enemyFlagPointer.SetFlagCapturedState();
			}
		}

		private FlagNotHomeNode GetOppositeTeamFlag(ICollection<FlagNotHomeNode> flags, SelfBattleUser user)
		{
			for (int i = 0; i < flags.Count; i++)
			{
				if (flags.ElementAt(i).teamGroup.Key != user.teamGroup.Key)
				{
					return flags.ElementAt(i);
				}
			}
			return null;
		}

		private FlagPedestalNode GetOppositeTeamPedestal(ICollection<FlagPedestalNode> pedestals, SelfBattleUser user)
		{
			for (int i = 0; i < pedestals.Count; i++)
			{
				if (pedestals.ElementAt(i).teamGroup.Key != user.teamGroup.Key)
				{
					return pedestals.ElementAt(i);
				}
			}
			return pedestals.First();
		}

		private bool NotFlagCarrier(HUDNodes.SelfTankNode selfTank, FlagNotHomeNode flag)
		{
			return !flag.Entity.HasComponent<TankGroupComponent>() || selfTank.tankGroup.Key != flag.Entity.GetComponent<TankGroupComponent>().Key;
		}

		private void SetBasePosition(CTFPointerComponent basePointer, Vector3 flagPedestalPosition, Camera camera)
		{
			Vector2 size = basePointer.selfRect.rect.size;
			Vector3 localScale = basePointer.parentCanvasRect.localScale;
			Vector2 selfRect = new Vector2(size.x * localScale.x, size.y * localScale.y);
			bool onScreen;
			Vector2 vector = CalculateBaseScreenPosition(camera, flagPedestalPosition, selfRect, out onScreen);
			RectTransform parentCanvasRect = basePointer.parentCanvasRect;
			basePointer.transform.localPosition = GetCanvasPosition(vector, parentCanvasRect) + new Vector2(0f, (!onScreen) ? 0f : (size.y / 2f));
		}

		private void SetFlagPointerPosition(FlagNotHomeNode flag, FlagPointerComponent pointer, Camera battleCamera)
		{
			pointer.Show();
			BoxCollider boxCollider = flag.flagCollider.boxCollider;
			Vector2 size = pointer.selfRect.rect.size;
			Vector3 localScale = pointer.parentCanvasRect.localScale;
			Vector2 selfRect = new Vector2(size.x * localScale.x, size.y * localScale.y);
			Vector3 worldPos = boxCollider.transform.TransformPoint(boxCollider.center);
			bool onScreen;
			Vector2 vector = CalculateFlagScreenPosition(pointer, battleCamera, worldPos, selfRect, out onScreen);
			RectTransform parentCanvasRect = pointer.parentCanvasRect;
			pointer.transform.localPosition = GetCanvasPosition(vector, parentCanvasRect) + new Vector2(0f, (!onScreen) ? 0f : (size.y / 2f));
		}

		private Vector2 GetCanvasPosition(Vector3 screenPosition, RectTransform canvasRect)
		{
			Vector2 vector = new Vector2(screenPosition.x / (float)Screen.width * canvasRect.rect.size.x, screenPosition.y / (float)Screen.height * canvasRect.rect.size.y);
			return vector - canvasRect.rect.size / 2f;
		}

		private Vector2 CalculateBaseScreenPosition(Camera camera, Vector3 worldPos, Vector2 selfRect, out bool onScreen)
		{
			Vector3 position = new Vector3(worldPos.x, worldPos.y + 5.5f, worldPos.z);
			Vector3 downPoint = camera.WorldToScreenPoint(worldPos);
			Vector3 vector = camera.WorldToScreenPoint(position);
			float distance = Vector3.Distance(camera.transform.position, worldPos);
			onScreen = FlagOnScreen(vector, downPoint, distance);
			if (vector.z < 0f)
			{
				vector *= -1f;
			}
			vector = GetBehindPosition(vector);
			if (!onScreen)
			{
				vector = ClampScreenPosToScreenSize(vector, selfRect);
			}
			return vector;
		}

		private Vector2 GetBehindPosition(Vector3 currentPosition)
		{
			Vector2 q = new Vector2(Screen.width, Screen.height) / 2f;
			float num = 0.0284999982f;
			float num2 = 19f / 160f;
			Vector2 intersection;
			if (DepenetrationForce.LineSegementsIntersect(new Vector2(num, num2), new Vector2((float)Screen.width - num, num2), q, currentPosition, out intersection))
			{
				return intersection;
			}
			if (DepenetrationForce.LineSegementsIntersect(new Vector2(num, num2), new Vector2(num, (float)Screen.height - num2), q, currentPosition, out intersection))
			{
				return intersection;
			}
			if (DepenetrationForce.LineSegementsIntersect(new Vector2(num, (float)Screen.height - num2), new Vector2((float)Screen.width - num, (float)Screen.height - num2), q, currentPosition, out intersection))
			{
				return intersection;
			}
			if (DepenetrationForce.LineSegementsIntersect(new Vector2((float)Screen.width - num, num2), new Vector2((float)Screen.width - num, (float)Screen.height - num2), q, currentPosition, out intersection))
			{
				return intersection;
			}
			return currentPosition;
		}

		private Vector2 CalculateFlagScreenPosition(FlagPointerComponent enemyFlag, Camera camera, Vector3 worldPos, Vector2 selfRect, out bool onScreen)
		{
			Vector3 position = new Vector3(worldPos.x, worldPos.y + 5.5f - 2f, worldPos.z);
			Vector3 vector = camera.WorldToScreenPoint(position);
			Vector3 downPoint = camera.WorldToScreenPoint(worldPos);
			Vector2 vector2 = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
			Vector2 normalized = ((Vector2)vector - vector2).normalized;
			float num = Mathf.Atan2(normalized.y, normalized.x);
			num -= 16200f / (float)Math.PI;
			float num2 = num * 57.29578f;
			float distance = Vector3.Distance(camera.transform.position, worldPos);
			onScreen = FlagOnScreen(vector, downPoint, distance);
			if (vector.z < 0f)
			{
				vector *= -1f;
				num2 -= 32400f / (float)Math.PI;
			}
			vector = GetBehindPosition(vector);
			if (onScreen)
			{
				enemyFlag.pointer.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}
			else
			{
				enemyFlag.pointer.transform.localRotation = Quaternion.Euler(0f, 0f, num2);
				vector = ClampScreenPosToScreenSize(vector, selfRect);
			}
			return vector;
		}

		private Vector2 ClampScreenPosToScreenSize(Vector3 screenPos, Vector2 selfSize)
		{
			float min = selfSize.x / 2f + (float)Screen.width * 0.03f;
			float max = (float)Screen.width - selfSize.x / 2f - (float)Screen.width * 0.03f;
			float max2 = (float)Screen.height - selfSize.y / 2f - (float)Screen.height * 0.125f;
			float min2 = selfSize.y / 2f + (float)Screen.height * 0.14f;
			return new Vector2(Mathf.Clamp(screenPos.x, min, max), Mathf.Clamp(screenPos.y, min2, max2));
		}

		private bool FlagOnScreen(Vector3 topPoint, Vector3 downPoint, float distance)
		{
			return RangeWithinScreen(topPoint, downPoint);
		}

		private bool RangeWithinScreen(Vector3 topPoint, Vector3 downPoint)
		{
			return topPoint.z > 0f && downPoint.z > 0f && topPoint.x > 0f && topPoint.x < (float)Screen.width && downPoint.x > 0f && downPoint.x < (float)Screen.width && topPoint.y > 0f && downPoint.y < (float)Screen.height;
		}

		private bool PointWithinScreen(Vector3 point)
		{
			return point.z > 0f && point.x > 0f && point.x < (float)Screen.width && point.y > 0f && point.y < (float)Screen.height;
		}
	}
}
