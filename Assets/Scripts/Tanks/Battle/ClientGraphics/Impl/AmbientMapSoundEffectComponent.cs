using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AmbientMapSoundEffectComponent : Component
	{
		public AmbientSoundFilter AmbientMapSound
		{
			get;
			set;
		}

		public AmbientMapSoundEffectComponent()
		{
		}

		public AmbientMapSoundEffectComponent(AmbientSoundFilter ambientMapSound)
		{
			AmbientMapSound = ambientMapSound;
		}
	}
}
