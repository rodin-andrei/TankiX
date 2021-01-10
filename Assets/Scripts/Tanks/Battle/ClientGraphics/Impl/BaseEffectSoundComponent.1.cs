using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class BaseEffectSoundComponent<T> : MonoBehaviour
	{
		[SerializeField]
		private GameObject startSoundAsset;
		[SerializeField]
		private GameObject stopSoundAsset;
	}
}
