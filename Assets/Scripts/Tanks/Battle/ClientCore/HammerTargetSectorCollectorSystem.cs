using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore
{
	public class HammerTargetSectorCollectorSystem : ECSSystem
	{
		public class HammerNode : Node
		{
			public HammerComponent hammer;

			public HammerPelletConeComponent hammerPelletCone;
		}

		[OnEventFire]
		public void CollectTargetSectors(CollectTargetSectorsEvent evt, HammerNode weaponNode)
		{
			HammerPelletConeComponent hammerPelletCone = weaponNode.hammerPelletCone;
			evt.HAllowableAngleAcatter = hammerPelletCone.HorizontalConeHalfAngle;
			evt.VAllowableAngleAcatter = hammerPelletCone.VerticalConeHalfAngle;
		}
	}
}
