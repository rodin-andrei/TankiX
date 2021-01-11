using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientEntrance.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MapPhysicsSystem : ECSSystem
	{
		public class SelfBattleUserNode : Node
		{
			public SelfComponent self;

			public BattleUserComponent battleUser;

			public BattleGroupComponent battleGroup;
		}

		public class BattleNode : Node
		{
			public BattleComponent battle;

			public GravityComponent gravity;

			public MapGroupComponent mapGroup;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void InitGravity(NodeAddedEvent e, SelfBattleUserNode selfBattleUser, [JoinByBattle][Mandatory] BattleNode battle)
		{
			Physics.gravity = Vector3.down * battle.gravity.Gravity;
		}
	}
}
