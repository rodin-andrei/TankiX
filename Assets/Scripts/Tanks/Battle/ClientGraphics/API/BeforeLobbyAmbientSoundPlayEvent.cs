using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.API
{
	public class BeforeLobbyAmbientSoundPlayEvent : Event
	{
		public bool HymnMode
		{
			get;
			set;
		}

		public BeforeLobbyAmbientSoundPlayEvent(bool hymnMode)
		{
			HymnMode = hymnMode;
		}
	}
}
