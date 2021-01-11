using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingForceFieldReadyComponent : Component
	{
		public int PropertyID
		{
			get;
			set;
		}

		public ShaftAimingForceFieldReadyComponent(int propertyId)
		{
			PropertyID = propertyId;
		}
	}
}
