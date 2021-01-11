using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientEntrance.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class FlagBuilderSystem : ECSSystem
	{
		public class FlagNode : Node
		{
			public FlagPositionComponent flagPosition;

			public TeamGroupComponent teamGroup;

			public BattleGroupComponent battleGroup;
		}

		public class FlagPedestalNode : Node
		{
			public FlagPedestalComponent flagPedestal;

			public TeamGroupComponent teamGroup;

			public BattleGroupComponent battleGroup;
		}

		public class TeamNode : Node
		{
			public ColorInBattleComponent colorInBattle;

			public TeamColorComponent teamColor;
		}

		public class BattleNode : Node
		{
			public CTFComponent ctf;

			public SelfComponent self;

			public ResourceDataComponent resourceData;

			public BattleGroupComponent battleGroup;
		}

		[OnEventFire]
		public void BuildFlag(NodeAddedEvent e, BattleNode ctf, SingleNode<MapInstanceComponent> map, [Combine] FlagNode flag, [JoinByTeam] TeamNode teamNode)
		{
			CTFAssetProxyBehaviour assetProxyBehaviour = GetAssetProxyBehaviour(ctf);
			TeamColor teamColor = teamNode.colorInBattle.TeamColor;
			GameObject original = ((teamColor != TeamColor.RED) ? assetProxyBehaviour.blueFlag : assetProxyBehaviour.redFlag);
			GameObject original2 = ((teamColor != TeamColor.RED) ? assetProxyBehaviour.blueFlagBeam : assetProxyBehaviour.redFlagBeam);
			FlagInstanceComponent flagInstanceComponent = new FlagInstanceComponent();
			Vector3 position = flag.flagPosition.Position;
			GameObject gameObject2 = (flagInstanceComponent.FlagInstance = Object.Instantiate(original, position, Quaternion.identity));
			GameObject gameObject4 = (flagInstanceComponent.FlagBeam = Object.Instantiate(original2, gameObject2.transform, false));
			flag.Entity.AddComponent(flagInstanceComponent);
			FlagPhysicsBehaviour flagPhysicsBehaviour = gameObject2.AddComponent<FlagPhysicsBehaviour>();
			flagPhysicsBehaviour.TriggerEntity = flag.Entity;
			flag.Entity.AddComponent(new FlagColliderComponent(gameObject2.GetComponent<BoxCollider>()));
		}

		private static CTFAssetProxyBehaviour GetAssetProxyBehaviour(BattleNode ctf)
		{
			return ((GameObject)ctf.resourceData.Data).GetComponent<CTFAssetProxyBehaviour>();
		}

		[OnEventFire]
		public void BuildPedestal(NodeAddedEvent e, BattleNode ctf, SingleNode<MapInstanceComponent> map, [Combine] FlagPedestalNode flagPedestal, [JoinByTeam] TeamNode teamNode)
		{
			CTFAssetProxyBehaviour assetProxyBehaviour = GetAssetProxyBehaviour(ctf);
			TeamColor teamColor = teamNode.colorInBattle.TeamColor;
			GameObject original = ((teamColor != TeamColor.RED) ? assetProxyBehaviour.bluePedestal : assetProxyBehaviour.redPedestal);
			FlagPedestalInstanceComponent flagPedestalInstanceComponent = new FlagPedestalInstanceComponent();
			Vector3 position = flagPedestal.flagPedestal.Position;
			flagPedestalInstanceComponent.FlagPedestalInstance = Object.Instantiate(original, position, Quaternion.identity);
			flagPedestal.Entity.AddComponent(flagPedestalInstanceComponent);
		}

		[OnEventFire]
		public void DestroyFlag(NodeRemoveEvent e, SingleNode<FlagInstanceComponent> flag)
		{
			Object.Destroy(flag.component.FlagInstance);
		}

		[OnEventFire]
		public void DestroyFlag(NodeRemoveEvent e, SingleNode<FlagPedestalInstanceComponent> pedestal)
		{
			Object.Destroy(pedestal.component.FlagPedestalInstance);
		}

		[OnEventFire]
		public void DestroyFlag(NodeRemoveEvent e, TeamNode team, [JoinByTeam] SingleNode<FlagInstanceComponent> flag)
		{
			Object.Destroy(flag.component.FlagInstance);
		}

		[OnEventFire]
		public void DestroyPedestal(NodeRemoveEvent e, TeamNode team, [JoinByTeam] SingleNode<FlagPedestalInstanceComponent> pedestal)
		{
			Object.Destroy(pedestal.component.FlagPedestalInstance);
		}
	}
}
