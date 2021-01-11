using System.Collections.Generic;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class DependAssetsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private List<Object> dependAssets;

		public List<Object> DependAssets
		{
			get
			{
				return dependAssets;
			}
			set
			{
				dependAssets = value;
			}
		}
	}
}
