using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RPMVolumeUpdaterFinishBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource source;
		[SerializeField]
		private float soundPauseTimer;
	}
}
