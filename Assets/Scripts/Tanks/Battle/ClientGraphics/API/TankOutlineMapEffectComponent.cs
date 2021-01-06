using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TankOutlineMapEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private float maxEffectRadius;
		[SerializeField]
		private float globalRadiusTime;
		[SerializeField]
		private float globalAlphaFadeInTime;
		[SerializeField]
		private float globalAlphaFadeOutTime;
		[SerializeField]
		private float minAlphaWhileBlinking;
		[SerializeField]
		private float enterSorkingStateSoundDelay;
		[SerializeField]
		private float workingFadeTimeOffset;
		[SerializeField]
		private float generalBlinkTime;
		[SerializeField]
		private float maxBlinkIterationTime;
		[SerializeField]
		private float pauseWhenBlinkOnMaxAlpha;
		[SerializeField]
		private float pauseWhenBlinkOnMinAlpha;
		[SerializeField]
		private float radarSoundInterval;
		[SerializeField]
		private float radarFadeSoundDelay;
		[SerializeField]
		private float workingStateFadeTime;
		[SerializeField]
		private float blinkRadius;
		[SerializeField]
		private SoundController radarSplashSound;
		[SerializeField]
		private SoundController radarFadeSound;
		[SerializeField]
		private SoundController deactivationRadarSound;
		[SerializeField]
		private SoundController activationRadarSound;
	}
}
