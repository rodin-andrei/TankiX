using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HolyshieldSoundEffectInstanceComponent : Component
	{
		public SoundController Instance
		{
			get;
			set;
		}

		public HolyshieldSoundEffectInstanceComponent(SoundController instance)
		{
			Instance = instance;
		}
	}
}
