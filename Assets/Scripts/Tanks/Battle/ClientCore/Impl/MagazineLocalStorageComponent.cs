using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MagazineLocalStorageComponent : Component
	{
		public int CurrentCartridgeCount
		{
			get;
			set;
		}

		public MagazineLocalStorageComponent()
		{
		}

		public MagazineLocalStorageComponent(int currentCartridgeCount)
		{
			CurrentCartridgeCount = currentCartridgeCount;
		}
	}
}
