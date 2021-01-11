using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class AssetBundlesLoadDataComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public bool Loaded
		{
			get;
			set;
		}

		public HashSet<AssetBundleInfo> AllBundles
		{
			get;
			set;
		}

		public List<AssetBundleInfo> BundlesToLoad
		{
			get;
			set;
		}

		public HashSet<AssetBundleInfo> LoadingBundles
		{
			get;
			set;
		}

		public Dictionary<AssetBundleInfo, AssetBundle> LoadedBundles
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("AssetBundlesLoadDataComponent Loaded: {0},\n\nLoadingBundles: {1},\n\nLoadedBundles: {2}", Loaded, EcsToStringUtil.EnumerableToString(LoadingBundles, "\n"), EcsToStringUtil.EnumerableToString(LoadedBundles, "\n"));
		}
	}
}
