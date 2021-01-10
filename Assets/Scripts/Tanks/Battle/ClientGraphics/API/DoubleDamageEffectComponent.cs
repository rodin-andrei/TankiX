using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DoubleDamageEffectComponent : MonoBehaviour
	{
		public Animator animator;
		public LightContainer light;
		public Renderer renderer;
		public DoubleDamageSoundEffectComponent soundEffect;
		public Color emissionColor;
		public int burningTimeInMs;
		public Color usualEmissionColor;
	}
}
