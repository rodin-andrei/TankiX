namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftShotAnimationTriggerComponent : AnimationTriggerComponent
	{
		private void OnCooldownStart()
		{
			ProvideEvent<ShaftShotAnimationCooldownStartEvent>();
		}

		private void OnCooldownClosing()
		{
			ProvideEvent<ShaftShotAnimationCooldownClosingEvent>();
		}

		private void OnCooldownEnd()
		{
			ProvideEvent<ShaftShotAnimationCooldownEndEvent>();
		}
	}
}
