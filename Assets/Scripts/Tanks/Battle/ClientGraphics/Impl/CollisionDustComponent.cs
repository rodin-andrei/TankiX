using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CollisionDustComponent : Component
	{
		public CollisionDustBehaviour CollisionDustBehaviour
		{
			get;
			set;
		}

		public CollisionDustComponent()
		{
		}

		public CollisionDustComponent(CollisionDustBehaviour collisionDustBehaviour)
		{
			CollisionDustBehaviour = collisionDustBehaviour;
		}
	}
}
