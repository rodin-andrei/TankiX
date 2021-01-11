using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.API
{
	public static class SoundListenerStates
	{
		public class SoundListenerSpawnState : Node
		{
			public SoundListenerSpawnStateComponent soundListenerSpawnState;
		}

		public class SoundListenerBattleState : Node
		{
			public SoundListenerReadyForHitFeedbackComponent soundListenerReadyForHitFeedback;

			public SoundListenerBattleStateComponent soundListenerBattleState;
		}

		public class SoundListenerBattleFinishState : Node
		{
			public SoundListenerBattleStateComponent soundListenerBattleState;

			public SoundListenerBattleFinishStateComponent soundListenerBattleFinishState;
		}

		public class SoundListenerSelfRankRewardState : Node
		{
			public SoundListenerBattleStateComponent soundListenerBattleState;

			public SoundListenerSelfRankRewardStateComponent soundListenerSelfRankRewardState;
		}

		public class SoundListenerLobbyState : Node
		{
			public SoundListenerLobbyStateComponent soundListenerLobbyState;
		}
	}
}
