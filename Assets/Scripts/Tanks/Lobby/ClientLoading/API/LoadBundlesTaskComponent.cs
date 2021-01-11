using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientResources.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientLoading.API
{
	[SerialVersionUID(635824350124275226L)]
	public class LoadBundlesTaskComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private const int MB_MULTIPLIER = 1048576;

		private Dictionary<AssetBundleInfo, float> bundleToProgress;

		private Dictionary<AssetBundleInfo, float> notCachedBundleToProgress;

		public HashSet<AssetBundleInfo> TrackedBundles
		{
			get;
			set;
		}

		public int BytesToLoad
		{
			get;
			private set;
		}

		public int BytesLoaded
		{
			get
			{
				float num = bundleToProgress.Values.Sum();
				return (int)num;
			}
		}

		public int MBytesToLoadFromNetwork
		{
			get;
			private set;
		}

		public int MBytesLoadedFromNetwork
		{
			get
			{
				float num = notCachedBundleToProgress.Values.Sum() / 1048576f;
				return (int)num;
			}
		}

		public float LoadingStartTime
		{
			get;
			private set;
		}

		public LoadBundlesTaskComponent(HashSet<AssetBundleInfo> trackedBundles)
		{
			TrackedBundles = trackedBundles;
			bundleToProgress = new Dictionary<AssetBundleInfo, float>();
			notCachedBundleToProgress = new Dictionary<AssetBundleInfo, float>();
			float num = 0f;
			foreach (AssetBundleInfo trackedBundle in trackedBundles)
			{
				bundleToProgress.Add(trackedBundle, 0f);
				BytesToLoad += trackedBundle.Size;
				if (!trackedBundle.IsCached)
				{
					notCachedBundleToProgress.Add(trackedBundle, 0f);
					num += (float)trackedBundle.Size;
				}
			}
			MBytesToLoadFromNetwork = (int)(num / 1048576f);
			LoadingStartTime = Time.realtimeSinceStartup;
		}

		public void MarkBundleAsLoaded(AssetBundleInfo bundleInfo)
		{
			bundleToProgress[bundleInfo] = bundleInfo.Size;
			if (notCachedBundleToProgress.ContainsKey(bundleInfo))
			{
				notCachedBundleToProgress[bundleInfo] = bundleInfo.Size;
			}
			TrackedBundles.Remove(bundleInfo);
		}

		public void CancelBundle(AssetBundleInfo bundleInfo)
		{
			TrackedBundles.Remove(bundleInfo);
		}

		public void SetBundleProgressLoading(AssetBundleInfo bundleInfo, float bundleProgress)
		{
			bundleToProgress[bundleInfo] = bundleProgress * (float)bundleInfo.Size;
			if (notCachedBundleToProgress.ContainsKey(bundleInfo))
			{
				notCachedBundleToProgress[bundleInfo] = bundleProgress * (float)bundleInfo.Size;
			}
		}

		public bool AllBundlesLoaded()
		{
			return TrackedBundles.Count == 0;
		}
	}
}
