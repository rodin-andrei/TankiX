using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AmbientZoneSoundEffect : MonoBehaviour
	{
		[SerializeField]
		private AmbientInnerSoundZone[] innerZones;
		[SerializeField]
		private AmbientOuterSoundZone outerZone;
	}
}
