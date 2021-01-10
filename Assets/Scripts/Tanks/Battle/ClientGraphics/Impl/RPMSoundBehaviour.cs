using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RPMSoundBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float rpm;
		[SerializeField]
		private ActiveRPMSoundModifier activeRPMSound;
		[SerializeField]
		private NormalRPMSoundModifier normalRPMSound;
		[SerializeField]
		private float rangeBeginRPM;
		[SerializeField]
		private float rangeEndRPM;
		[SerializeField]
		private HullSoundEngineController hullSoundEngine;
	}
}
