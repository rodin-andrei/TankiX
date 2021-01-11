using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.API
{
	public class TankPartIntersectionWithCameraMapComponent : Component
	{
		public TankPartIntersectionWithCameraData[] TankPartIntersectionMap
		{
			get;
			set;
		}

		public TankPartIntersectionWithCameraMapComponent(TankPartIntersectionWithCameraData[] tankPartIntersectionMap)
		{
			TankPartIntersectionMap = tankPartIntersectionMap;
		}
	}
}
