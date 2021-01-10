using System.Collections.Generic;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class AssetBundleDatabase
	{
		[SerializeField]
		private List<AssetBundleInfo> bundles;
		[SerializeField]
		private List<string> rootGuids;
	}
}
