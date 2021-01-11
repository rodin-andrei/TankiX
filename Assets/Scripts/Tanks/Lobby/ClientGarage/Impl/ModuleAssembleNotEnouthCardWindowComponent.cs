using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleAssembleNotEnouthCardWindowComponent : Component
	{
		public int Tier
		{
			get;
			private set;
		}

		public ModuleAssembleNotEnouthCardWindowComponent(int tier)
		{
			Tier = tier;
		}
	}
}
