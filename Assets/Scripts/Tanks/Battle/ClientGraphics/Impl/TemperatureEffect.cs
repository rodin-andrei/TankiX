using System;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TemperatureEffect : MonoBehaviour
	{
		[SerializeField]
		private Gradient particlesStartColor;

		[SerializeField]
		private AnimationCurve lightIntensity;

		private ParticleSystem particleSystem;

		private void Awake()
		{
			particleSystem = GetComponent<ParticleSystem>();
		}

		public void SetTemperature(float temperature)
		{
			temperature = Math.Abs(temperature);
			particleSystem.startColor = particlesStartColor.Evaluate(temperature);
		}
	}
}
