using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GoToModulesScreenEvent : Event
	{
		private TankPartModuleType tankPartModuleType;

		public TankPartModuleType TankPartModuleType
		{
			get
			{
				return tankPartModuleType;
			}
		}

		public GoToModulesScreenEvent(TankPartModuleType tankPartModuleType)
		{
			this.tankPartModuleType = tankPartModuleType;
		}
	}
}
