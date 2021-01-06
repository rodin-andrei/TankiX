using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SetTransparencyTransitionDataEvent : Event
	{
		public SetTransparencyTransitionDataEvent(float originAlpha, float targetAlpha, float transparencyTransitionTime)
		{
		}

	}
}
