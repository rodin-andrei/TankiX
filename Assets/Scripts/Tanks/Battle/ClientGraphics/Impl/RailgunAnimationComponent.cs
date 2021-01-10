using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RailgunAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private string railgunChargingTriggerName;
		[SerializeField]
		private string railgunStartReloadingName;
		[SerializeField]
		private string railgunStopReloadingName;
		[SerializeField]
		private string railgunStopAnimationName;
		[SerializeField]
		private string railgunReloadingSpeedCoeffName;
		[SerializeField]
		private string railgunChargeSpeedCoeffName;
		[SerializeField]
		private int railgunReloadingCyclesCount;
		[SerializeField]
		private AnimationClip reloadClip;
		[SerializeField]
		private AnimationClip chargeClip;
	}
}
