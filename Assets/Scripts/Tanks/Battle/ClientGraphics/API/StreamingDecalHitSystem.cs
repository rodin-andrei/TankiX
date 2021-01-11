using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class StreamingDecalHitSystem : AbstractDecalHitSystem
	{
		public class StreaminWeaponNode : Node
		{
			public StreamHitComponent streamHit;

			public MuzzlePointComponent muzzlePoint;

			public StreamingDecalProjectorComponent streamingDecalProjector;
		}

		[OnEventComplete]
		public void DrawDecals(UpdateEvent evt, StreaminWeaponNode weaponNode, [JoinAll] SingleNode<DecalManagerComponent> decalManagerNode)
		{
			if (!decalManagerNode.component.EnableDecals)
			{
				return;
			}
			StreamingDecalProjectorComponent streamingDecalProjector = weaponNode.streamingDecalProjector;
			DecalManagerComponent component = decalManagerNode.component;
			if (weaponNode.streamHit.StaticHit != null && !(streamingDecalProjector.LastDecalCreationTime + streamingDecalProjector.DecalCreationPeriod > Time.time))
			{
				streamingDecalProjector.LastDecalCreationTime = Time.time;
				Vector3 barrelOriginWorld = new MuzzleVisualAccessor(weaponNode.muzzlePoint).GetBarrelOriginWorld();
				Vector3 normalized = (weaponNode.streamHit.StaticHit.Position - barrelOriginWorld).normalized;
				DecalProjection decalProjection = new DecalProjection();
				decalProjection.AtlasHTilesCount = streamingDecalProjector.AtlasHTilesCount;
				decalProjection.AtlasVTilesCount = streamingDecalProjector.AtlasVTilesCount;
				decalProjection.SurfaceAtlasPositions = streamingDecalProjector.SurfaceAtlasPositions;
				decalProjection.HalfSize = streamingDecalProjector.HalfSize;
				decalProjection.Up = streamingDecalProjector.Up;
				decalProjection.Distantion = streamingDecalProjector.Distance;
				decalProjection.Ray = new Ray(barrelOriginWorld - normalized, normalized);
				DecalProjection decalProjection2 = decalProjection;
				Mesh mesh = null;
				if (component.DecalMeshBuilder.Build(decalProjection2, ref mesh))
				{
					component.BulletHoleDecalManager.AddDecal(mesh, streamingDecalProjector.Material, streamingDecalProjector.Color, streamingDecalProjector.LifeTime);
				}
			}
		}
	}
}
