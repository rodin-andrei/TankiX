using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class BonusRegionAssetComponent : Component
	{
		public string AssetGuid
		{
			get;
			set;
		}

		public BonusRegionAssetComponent()
		{
		}

		public BonusRegionAssetComponent(string assetGuid)
		{
			AssetGuid = assetGuid;
		}
	}
}
