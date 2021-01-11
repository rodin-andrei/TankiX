using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientLoading.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class UserReadyToBattleSystem : ECSSystem
	{
		[Not(typeof(UserReadyToBattleComponent))]
		public class BattleUserNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public BattleGroupComponent battleGroup;

			public UserInBattleAsTankComponent userInBattleAsTank;
		}

		[Not(typeof(UserReadyToBattleComponent))]
		public class SpectatorNode : Node
		{
			public SelfBattleUserComponent selfBattleUser;

			public BattleGroupComponent battleGroup;

			public UserInBattleAsSpectatorComponent userInBattleAsSpectator;
		}

		public class LoadCompletedNode : Node
		{
			public LoadProgressTaskCompleteComponent loadProgressTaskComplete;

			public BattleLoadScreenComponent battleLoadScreen;
		}

		public class MapNode : Node
		{
			public MapInstanceComponent mapInstance;

			public MapGroupComponent mapGroup;
		}

		public class MapEffectNode : Node
		{
			public MapEffectAssembledComponent mapEffectAssembled;

			public MapGroupComponent mapGroup;
		}

		[OnEventComplete]
		public void SetUserReady(NodeAddedEvent e, BattleUserNode user, LoadCompletedNode loadCompleted, MapNode map, [Context][JoinByMap] MapEffectNode mapEffect)
		{
			user.Entity.AddComponent<UserReadyToBattleComponent>();
			GC.Collect();
		}

		[OnEventComplete]
		public void SetSpectatorReady(NodeAddedEvent e, SpectatorNode user, LoadCompletedNode loadCompleted, MapNode map, [Context][JoinByMap] MapEffectNode mapEffect)
		{
			user.Entity.AddComponent<UserReadyToBattleComponent>();
			GC.Collect();
		}

		[OnEventFire]
		public void IsUserSpectator(CheckUserForSpectatorEvent e, Node any, [JoinAll] SpectatorNode spectator)
		{
			e.UserIsSpectator = true;
		}
	}
}
