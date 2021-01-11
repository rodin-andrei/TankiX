using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientResources.API;

namespace Platform.Library.ClientResources.Impl
{
	public class AssetBundleStorageSystem : ECSSystem
	{
		public class LoaderNode : Node
		{
			public AssetBundleLoadingComponent assetBundleLoading;
		}

		public class AssetBundleLoadingNode : Node
		{
			public AssetBundlesLoadDataComponent assetBundlesLoadData;
		}

		[OnEventFire]
		public void Store(LoadCompleteEvent e, LoaderNode node)
		{
			if (!AssetBundlesStorage.IsStored(node.assetBundleLoading.Info))
			{
				AssetBundlesStorage.Store(node.assetBundleLoading.Info, node.assetBundleLoading.AssetBundleDiskCacheRequest.AssetBundle);
			}
		}

		[OnEventFire]
		[Mandatory]
		public void RefreshDependencies(AssetBundlesLoadedEvent e, SingleNode<AssetBundlesLoadDataComponent> loadDataNode)
		{
			foreach (AssetBundleInfo allBundle in loadDataNode.component.AllBundles)
			{
				AssetBundlesStorage.Refresh(allBundle);
			}
		}

		private bool IsBundleInLoadingDependencies(AssetBundleInfo info, ICollection<AssetBundleLoadingNode> loadingBundleNodes)
		{
			return loadingBundleNodes.Any((AssetBundleLoadingNode node) => node.assetBundlesLoadData.AllBundles.Contains(info));
		}
	}
}
