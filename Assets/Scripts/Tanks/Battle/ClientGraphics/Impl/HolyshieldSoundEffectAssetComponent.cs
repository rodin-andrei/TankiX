using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HolyshieldSoundEffectAssetComponent : BehaviourComponent
	{
		[SerializeField]
		private SoundController asset;

		public SoundController Asset
		{
			get
			{
				return asset;
			}
		}
	}
}
