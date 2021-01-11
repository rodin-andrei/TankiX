using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class PlayingMelodyRoundRestartListenerComponent : Component
	{
		public AmbientSoundFilter Melody
		{
			get;
			set;
		}

		public PlayingMelodyRoundRestartListenerComponent(AmbientSoundFilter melody)
		{
			Melody = melody;
		}
	}
}
