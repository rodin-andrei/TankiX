using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRayEffectUpdateEvent : Event
	{
		public float[] speedMultipliers;
		public float[] bezierPointsRandomness;
	}
}
