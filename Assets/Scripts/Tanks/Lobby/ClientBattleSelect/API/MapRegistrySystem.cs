using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientLoading.Impl;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class MapRegistrySystem : ECSSystem, MapRegistry
	{
		[Not(typeof(MapLoadPreviewDataComponent))]
		public class MapNode : Node
		{
			public MapComponent map;

			public MapLoadPreviewComponent mapLoadPreview;
		}

		private Dictionary<Entity, Map> maps = new Dictionary<Entity, Map>();

		public Map GetMap(Entity mapEntity)
		{
			if (!maps.ContainsKey(mapEntity))
			{
				maps.Add(mapEntity, new Map(mapEntity));
			}
			return maps[mapEntity];
		}

		[OnEventFire]
		public void RequestMapLoadPreview(NodeAddedEvent e, MapNode mapNode)
		{
			Map map = GetMap(mapNode.Entity);
			if (map.LoadPreview == null)
			{
				AssetRequestEvent assetRequestEvent = new AssetRequestEvent();
				assetRequestEvent.Init<MapLoadPreviewDataComponent>(mapNode.mapLoadPreview.AssetGuid);
				ScheduleEvent(assetRequestEvent, mapNode);
			}
		}
	}
}
