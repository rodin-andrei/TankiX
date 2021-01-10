using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TankInvisibilityEffectUnityComponent : BehaviourComponent
	{
		[SerializeField]
		private Texture2D[] dissolveMaps;
		[SerializeField]
		private Shader invisibilityEffectTransitionShader;
		[SerializeField]
		private Shader invisibilityEffectShader;
		[SerializeField]
		private float phaseTime;
		[SerializeField]
		private float offsetPhaseTime;
		[SerializeField]
		private float maxDistortion;
		[SerializeField]
		private Vector2 dissolveMapScale;
		[SerializeField]
		private AnimationCurve dissolvingFrontCurve;
		[SerializeField]
		private AnimationCurve dissolvingBackCurve;
		[SerializeField]
		private SoundController activationSoundInstance;
		[SerializeField]
		private SoundController deactivationSoundInstance;
	}
}
