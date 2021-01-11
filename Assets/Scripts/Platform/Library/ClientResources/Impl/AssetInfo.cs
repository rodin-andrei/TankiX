using System;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	[Serializable]
	public class AssetInfo
	{
		[SerializeField]
		private string guid;

		[SerializeField]
		private string objectName;

		[SerializeField]
		private int typeHash;

		[NonSerialized]
		private AssetBundleInfo assetBundleInfo;

		public Type AssetType
		{
			get
			{
				return AssetTypeRegistry.GetType(typeHash);
			}
		}

		public string Guid
		{
			get
			{
				return guid;
			}
			set
			{
				guid = value;
			}
		}

		public string ObjectName
		{
			get
			{
				return objectName;
			}
			set
			{
				objectName = value;
			}
		}

		public AssetBundleInfo AssetBundleInfo
		{
			get
			{
				return assetBundleInfo;
			}
			set
			{
				assetBundleInfo = value;
			}
		}

		internal int TypeHash
		{
			get
			{
				return typeHash;
			}
			set
			{
				typeHash = value;
			}
		}

		public override string ToString()
		{
			return string.Format("[AssetInfo: guid={0}, objectName={1}, Type={2}, assetBundleName={3}]", guid, objectName, AssetType, assetBundleInfo.BundleName);
		}
	}
}
