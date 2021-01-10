using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using System.Collections.Generic;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DissolvingEffectUnityComponent : BehaviourComponent
	{
		[SerializeField]
		private Texture2D[] dissolveMaps;
		[SerializeField]
		private Shader invisibilityEffectTransitionShader;
		[SerializeField]
		private float phaseTime;
		[SerializeField]
		private float offsetPhaseTime;
		[SerializeField]
		private float maxDistortion;
		[SerializeField]
		private Vector2 dissolveMapScale;
		[SerializeField]
		private List<Renderer> renderers;
		[SerializeField]
		private AnimationCurve dissolvingCurve;
		[SerializeField]
		private SoundController soundInstance;
	}
}
