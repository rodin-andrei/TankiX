using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingRendererReducingAlphaComponent : Component
	{
		public float InitialAlpha
		{
			get;
			set;
		}

		public ShaftAimingRendererReducingAlphaComponent()
		{
		}

		public ShaftAimingRendererReducingAlphaComponent(float initialAlpha)
		{
			InitialAlpha = initialAlpha;
		}
	}
}
