using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AmbientZoneSoundEffectComponent : Component
	{
		public AmbientZoneSoundEffect AmbientZoneSoundEffect
		{
			get;
			set;
		}

		public AmbientZoneSoundEffectComponent(AmbientZoneSoundEffect ambientZoneSoundEffect)
		{
			AmbientZoneSoundEffect = ambientZoneSoundEffect;
		}
	}
}
