using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapReverbZoneAssetComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject mapReverbZonesRoot;

		public GameObject MapReverbZonesRoot
		{
			get
			{
				return mapReverbZonesRoot;
			}
		}
	}
}
