using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BaseRicochetSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource assetSource;
		[SerializeField]
		private float lifetime;
	}
}
