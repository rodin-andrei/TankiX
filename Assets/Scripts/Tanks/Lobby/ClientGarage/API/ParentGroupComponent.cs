using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ParentGroupComponent : GroupComponent
	{
		public ParentGroupComponent(Entity keyEntity) : base(default(Entity))
		{
		}

	}
}
