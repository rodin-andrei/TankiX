using System;
using UnityEngine;

namespace Platform.Library.ClientResources.API
{
	[Serializable]
	public class AssetReference
	{
		[SerializeField]
		private string assetGuid;
		[SerializeField]
		private Object embededReference;
	}
}
