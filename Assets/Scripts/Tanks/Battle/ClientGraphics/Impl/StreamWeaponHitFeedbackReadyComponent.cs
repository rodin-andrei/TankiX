using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StreamWeaponHitFeedbackReadyComponent : Component
	{
		public SoundController SoundController
		{
			get;
			set;
		}

		public StreamWeaponHitFeedbackReadyComponent(SoundController soundController)
		{
			SoundController = soundController;
		}
	}
}
