using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BaseTimeEvent : Event
	{
		private int clientTime = (int)(PreciseTime.Time * 1000.0);

		public int ClientTime
		{
			get
			{
				return clientTime;
			}
			set
			{
				clientTime = value;
			}
		}
	}
}
