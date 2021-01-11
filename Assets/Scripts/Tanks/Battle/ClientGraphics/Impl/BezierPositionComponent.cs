using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BezierPositionComponent : Component
	{
		public BezierPosition BezierPosition
		{
			get;
			set;
		}

		public BezierPositionComponent()
		{
			BezierPosition = new BezierPosition();
		}
	}
}
