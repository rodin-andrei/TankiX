using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StreamEffectBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float range;
		[SerializeField]
		private AnimationCurve nearIntensityEasing;
		[SerializeField]
		private AnimationCurve farIntensityEasing;
		[SerializeField]
		private Light nearLight;
		[SerializeField]
		private Light farLight;
		[SerializeField]
		private float farLightDefaultSpeed;
		[SerializeField]
		private float farLightMaxSpeed;
	}
}
