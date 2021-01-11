using System.Collections.Generic;
using Platform.Library.ClientResources.Impl;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	public static class AssetBundlesStorage
	{
		public static int STORAGE_PREFARE_SIZE = 104857600;

		public static int EXPIRATION_TIME_SEC = 60;

		private static LinkedList<AssetBundleStorageEntry> entryQueue = new LinkedList<AssetBundleStorageEntry>();

		private static Dictionary<AssetBundleInfo, AssetBundleStorageEntry> bundle2entry = new Dictionary<AssetBundleInfo, AssetBundleStorageEntry>();

		private static HashSet<AssetBundleInfo> loadingBundles = new HashSet<AssetBundleInfo>();

		private static int size;

		public static LinkedList<AssetBundleStorageEntry> EntryQueue
		{
			get
			{
				return entryQueue;
			}
		}

		public static int Size
		{
			get
			{
				return size;
			}
		}

		public static void Clean()
		{
			foreach (AssetBundleStorageEntry item in entryQueue)
			{
				if (item.Bundle != null)
				{
					item.Bundle.Unload(true);
				}
			}
			InternalClean();
		}

		public static void InternalClean()
		{
			entryQueue.Clear();
			bundle2entry.Clear();
			loadingBundles.Clear();
			size = 0;
		}

		public static void Refresh(AssetBundleInfo info)
		{
			IsStored(info);
		}

		public static void MarkLoading(AssetBundleInfo info)
		{
			loadingBundles.Add(info);
		}

		public static bool IsLoading(AssetBundleInfo info)
		{
			return loadingBundles.Contains(info);
		}

		public static bool IsStored(AssetBundleInfo info)
		{
			if (bundle2entry.ContainsKey(info))
			{
				Access(info);
				return true;
			}
			return false;
		}

		public static AssetBundle Get(AssetBundleInfo info)
		{
			return Access(info).Bundle;
		}

		private static AssetBundleStorageEntry Access(AssetBundleInfo info)
		{
			AssetBundleStorageEntry assetBundleStorageEntry = bundle2entry[info];
			assetBundleStorageEntry.LastAccessTime = Time.time;
			return assetBundleStorageEntry;
		}

		public static void Store(AssetBundleInfo info, AssetBundle bundle)
		{
			loadingBundles.Remove(info);
			AssetBundleStorageEntry assetBundleStorageEntry = new AssetBundleStorageEntry();
			assetBundleStorageEntry.Info = info;
			assetBundleStorageEntry.Bundle = bundle;
			assetBundleStorageEntry.LastAccessTime = Time.time;
			AssetBundleStorageEntry value = assetBundleStorageEntry;
			entryQueue.AddLast(value);
			bundle2entry.Add(info, value);
			size += info.Size;
		}

		public static void StoreAsStatic(AssetBundleInfo info, AssetBundle bundle)
		{
			AssetBundleStorageEntry assetBundleStorageEntry = new AssetBundleStorageEntry();
			assetBundleStorageEntry.Info = info;
			assetBundleStorageEntry.Bundle = bundle;
			assetBundleStorageEntry.LastAccessTime = Time.time;
			AssetBundleStorageEntry value = assetBundleStorageEntry;
			bundle2entry.Add(info, value);
		}

		public static bool Unload(AssetBundleStorageEntry entry)
		{
			entry.Bundle.Unload(false);
			entryQueue.Remove(entry);
			bundle2entry.Remove(entry.Info);
			size -= entry.Info.Size;
			return true;
		}

		public static bool IsExpired(AssetBundleStorageEntry entry)
		{
			return Time.time - entry.LastAccessTime > (float)EXPIRATION_TIME_SEC;
		}

		public static bool IsNeedFreeSpace()
		{
			return size > STORAGE_PREFARE_SIZE;
		}
	}
}
