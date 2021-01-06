using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AbstractVulcanSoundEffectComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject effectPrefab;
		[SerializeField]
		private float startTimePerSec;
		[SerializeField]
		private float delayPerSec;
	}
}
