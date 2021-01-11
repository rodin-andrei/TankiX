using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapNativeSoundsAssetComponent : BehaviourComponent
	{
		[SerializeField]
		private MapNativeSoundsBehaviour asset;

		public MapNativeSoundsBehaviour Asset
		{
			get
			{
				return asset;
			}
		}
	}
}
