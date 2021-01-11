using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GetEnergyCountTutorialValidationDataEvent : Event
	{
		private long _quantums;

		public long Quantums
		{
			get
			{
				return _quantums;
			}
			set
			{
				_quantums = value;
			}
		}
	}
}
