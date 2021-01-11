using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapNativeSoundsComponent : Component
	{
		public MapNativeSoundsBehaviour MapNativeSounds
		{
			get;
			set;
		}

		public MapNativeSoundsComponent(MapNativeSoundsBehaviour mapNativeSounds)
		{
			MapNativeSounds = mapNativeSounds;
		}
	}
}
