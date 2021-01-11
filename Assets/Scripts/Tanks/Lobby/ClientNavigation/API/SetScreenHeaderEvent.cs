using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class SetScreenHeaderEvent : Event
	{
		private string header;

		private bool animate = true;

		public string Header
		{
			get
			{
				return header ?? string.Empty;
			}
			set
			{
				header = value;
			}
		}

		public bool Animate
		{
			get
			{
				return animate;
			}
			set
			{
				animate = value;
			}
		}

		public void Animated(string header)
		{
			Animate = true;
			Header = header;
		}

		public void Immediate(string header)
		{
			Animate = false;
			Header = header;
		}
	}
}
