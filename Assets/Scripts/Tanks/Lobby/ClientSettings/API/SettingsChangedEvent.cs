using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SettingsChangedEvent<T> : Event where T : Component
	{
		public T Data
		{
			get;
			set;
		}

		public SettingsChangedEvent()
		{
		}

		public SettingsChangedEvent(T data)
		{
			Data = data;
		}
	}
}
