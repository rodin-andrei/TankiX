using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EmergencyProtectionTankShaderEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private Color emergencyProtectionColor;
		[SerializeField]
		private float duration;
		[SerializeField]
		private float waveAnimationTime;
		[SerializeField]
		private AnimationCurve straightStepCurve;
		[SerializeField]
		private AnimationCurve reverseStepCurve;
		[SerializeField]
		private Vector2 noiseTextureTiling;
		[SerializeField]
		private Texture2D noiseTexture;
		[SerializeField]
		private ParticleSystem waveEffect;
		[SerializeField]
		private bool useWaveEffect;
		[SerializeField]
		private float delayWithWaveEffect;
	}
}
