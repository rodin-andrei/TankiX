using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class MatchMakingMapPreloadingSystem : ECSSystem
	{
		public class MatchMakingLobbyNode : Node
		{
			public BattleLobbyComponent battleLobby;

			public MapGroupComponent mapGroup;
		}

		public class MatchMakingLobbyNodeWithMapPreload : Node
		{
			public MapPreloadOnLobbyComponent mapPreloadOnLobby;
		}

		public class MapNode : Node
		{
			public MapComponent map;

			public MapGroupComponent mapGroup;

			public AssetReferenceComponent assetReference;
		}

		public class MapPreloadOnLobbyComponent : Component
		{
			public Entity LoaderEntity;
		}

		[OnEventFire]
		public void MapPreloadOnLobbyCreated(NodeAddedEvent e, MatchMakingLobbyNode lobby, [JoinByMap] MapNode map)
		{
			lobby.Entity.RemoveComponentIfPresent<MapPreloadOnLobbyComponent>();
			AssetRequestEvent assetRequestEvent = new AssetRequestEvent();
			assetRequestEvent.AssetGuid = map.assetReference.Reference.AssetGuid;
			AssetRequestEvent assetRequestEvent2 = assetRequestEvent;
			ScheduleEvent(assetRequestEvent2, map);
			lobby.Entity.AddComponent(new MapPreloadOnLobbyComponent
			{
				LoaderEntity = assetRequestEvent2.LoaderEntity
			});
		}

		[OnEventFire]
		public void CancelMapPreloadOnLobbyDroped(NodeRemoveEvent e, MatchMakingLobbyNodeWithMapPreload lobby)
		{
			Entity loaderEntity = lobby.mapPreloadOnLobby.LoaderEntity;
			if (loaderEntity.Alive)
			{
				DeleteEntity(lobby.mapPreloadOnLobby.LoaderEntity);
			}
		}
	}
}
