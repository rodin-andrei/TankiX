using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class CTFBuilderSystem : ECSSystem
	{
		public class CTFNode : Node
		{
			public CTFComponent ctf;
		}

		[OnEventFire]
		public void LoadResources(NodeAddedEvent e, CTFNode ctf)
		{
			ctf.Entity.AddComponent<AssetReferenceComponent>();
			ctf.Entity.AddComponent<AssetRequestComponent>();
		}
	}
}
