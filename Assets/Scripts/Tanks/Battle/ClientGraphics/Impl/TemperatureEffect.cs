using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TemperatureEffect : MonoBehaviour
	{
		[SerializeField]
		private Gradient particlesStartColor;
		[SerializeField]
		private AnimationCurve lightIntensity;
	}
}
