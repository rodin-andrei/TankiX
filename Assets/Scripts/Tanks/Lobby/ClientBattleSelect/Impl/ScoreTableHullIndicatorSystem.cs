using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ScoreTableHullIndicatorSystem : ECSSystem
	{
		public class HullIndicatorNode : Node
		{
			public ScoreTableHullIndicatorComponent scoreTableHullIndicator;

			public UserGroupComponent userGroup;
		}

		public class HullNode : Node
		{
			public UserGroupComponent userGroup;

			public TankComponent tank;

			public MarketItemGroupComponent marketItemGroup;
		}

		[OnEventFire]
		public void SetHulls(NodeAddedEvent e, [Combine] HullIndicatorNode hullIndicator, [Context][JoinByUser] HullNode hull)
		{
			SetHull(hullIndicator, hull);
		}

		private void SetHull(HullIndicatorNode hullIndicator, HullNode hull)
		{
			hullIndicator.scoreTableHullIndicator.SetHullIcon(hull.marketItemGroup.Key);
		}
	}
}
