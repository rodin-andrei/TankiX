using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BattleLabelSystem : ECSSystem
	{
		public class BattleLabelNode : Node
		{
			public BattleLabelComponent battleLabel;

			public BattleInfoForLabelComponent battleInfoForLabel;

			public MapGroupComponent mapGroup;
		}

		public class Battle : Node
		{
			public BattleComponent battle;

			public BattleModeComponent battleMode;

			public BattleGroupComponent battleGroup;

			public MapGroupComponent mapGroup;
		}

		public class MapNode : Node
		{
			public MapComponent map;

			public MapGroupComponent mapGroup;

			public DescriptionItemComponent descriptionItem;
		}

		[OnEventFire]
		public void AddUserBattle(NodeAddedEvent e, BattleLabelNode battleLabel, [JoinByMap][Context] MapNode mapNode)
		{
			battleLabel.battleLabel.Map = mapNode.descriptionItem.Name;
			battleLabel.battleLabel.Mode = battleLabel.battleInfoForLabel.BattleMode;
			battleLabel.battleLabel.BattleIconActivity = true;
		}
	}
}
