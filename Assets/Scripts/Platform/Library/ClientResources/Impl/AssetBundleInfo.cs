using System;
using UnityEngine;
using System.Collections.Generic;

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
		private List<string> dependenciesNames;
		[SerializeField]
		private List<AssetInfo> assets;
		[SerializeField]
		private int modificationHash;
	}
}
