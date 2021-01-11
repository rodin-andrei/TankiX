using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StartHealingGraphicsEffectEvent : Event
	{
		public float Duration
		{
			get;
			set;
		}

		public StartHealingGraphicsEffectEvent(float duration)
		{
			Duration = duration;
		}
	}
}
