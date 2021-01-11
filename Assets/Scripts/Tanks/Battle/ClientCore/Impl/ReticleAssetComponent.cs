using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ReticleAssetComponent : Component
	{
		public AssetReference Reference
		{
			get;
			set;
		}

		public ReticleAssetComponent()
		{
		}

		public ReticleAssetComponent(AssetReference reference)
		{
			Reference = reference;
		}
	}
}
