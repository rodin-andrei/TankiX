using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SoundListenerResourcesComponent : Component
	{
		public SoundListenerResourcesBehaviour Resources
		{
			get;
			set;
		}

		public SoundListenerResourcesComponent(SoundListenerResourcesBehaviour resources)
		{
			Resources = resources;
		}
	}
}
