using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;

namespace Platform.Library.ClientResources.Impl
{
	public class AsyncLoadingAssetListComponent : Component
	{
		public List<LoadAssetFromBundleRequest> AssetListRequest
		{
			get;
			set;
		}

		public AsyncLoadingAssetListComponent(List<LoadAssetFromBundleRequest> assetListRequest)
		{
			AssetListRequest = assetListRequest;
		}
	}
}
