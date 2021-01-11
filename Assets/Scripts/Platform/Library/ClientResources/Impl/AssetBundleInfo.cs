using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	[Serializable]
	public class AssetBundleInfo
	{
		[SerializeField]
		private string bundleName;

		[SerializeField]
		private string hash;

		[SerializeField]
		private uint crc;

		[SerializeField]
		private uint cacheCrc;

		[SerializeField]
		private int size;

		[SerializeField]
		private List<string> dependenciesNames = new List<string>();

		[SerializeField]
		private List<AssetInfo> assets = new List<AssetInfo>();

		[SerializeField]
		private int modificationHash;

		[NonSerialized]
		private List<AssetBundleInfo> dependencies = new List<AssetBundleInfo>();

		[NonSerialized]
		private bool isCached;

		public bool IsCached
		{
			get
			{
				return isCached;
			}
			set
			{
				isCached = value;
			}
		}

		public string BundleName
		{
			get
			{
				return bundleName;
			}
			set
			{
				bundleName = value;
			}
		}

		public Hash128 Hash
		{
			get
			{
				return Hash128.Parse(hash);
			}
			set
			{
				hash = value.ToString();
			}
		}

		public string HashString
		{
			get
			{
				return hash;
			}
		}

		public int ModificationHash
		{
			get
			{
				return modificationHash;
			}
			set
			{
				modificationHash = value;
			}
		}

		public int Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public List<AssetInfo> Assets
		{
			get
			{
				return assets;
			}
			set
			{
				assets = value;
			}
		}

		public List<string> DependenciesNames
		{
			get
			{
				return dependenciesNames;
			}
			set
			{
				dependenciesNames = value;
			}
		}

		public List<AssetBundleInfo> Dependencies
		{
			get
			{
				return dependencies;
			}
			set
			{
				dependencies = value;
			}
		}

		public ICollection<AssetBundleInfo> AllDependencies
		{
			get
			{
				List<AssetBundleInfo> list = new List<AssetBundleInfo>();
				CollectDependencies(list);
				return list;
			}
		}

		public string Filename
		{
			get
			{
				return AssetBundleNaming.AddCrcToBundleName(BundleName, CRC);
			}
		}

		public uint CRC
		{
			get
			{
				return crc;
			}
			set
			{
				crc = value;
			}
		}

		public uint CacheCRC
		{
			get
			{
				return cacheCrc;
			}
			set
			{
				cacheCrc = value;
			}
		}

		internal void AddAssetInfo(AssetInfo assetInfo)
		{
			Assets.Add(assetInfo);
		}

		private void CollectDependencies(ICollection<AssetBundleInfo> collector)
		{
			List<AssetBundleInfo> list = Dependencies;
			foreach (AssetBundleInfo item in list)
			{
				collector.Add(item);
			}
		}

		public override string ToString()
		{
			return string.Format("[AssetBundleInfo: bundleName={0}, hash={1}, size={2}, dependenciesNames={3}, assets={4}]", bundleName, hash, size, dependenciesNames, assets);
		}

		public override int GetHashCode()
		{
			return Filename.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			AssetBundleInfo assetBundleInfo = obj as AssetBundleInfo;
			if (assetBundleInfo == null)
			{
				return false;
			}
			return Filename == assetBundleInfo.Filename;
		}
	}
}
