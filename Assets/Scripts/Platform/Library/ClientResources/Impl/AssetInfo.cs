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
	}
}
