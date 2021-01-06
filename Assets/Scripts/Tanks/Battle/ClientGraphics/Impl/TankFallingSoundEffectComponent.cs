using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankFallingSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource fallingSourceAsset;
		[SerializeField]
		private AudioClip[] fallingClips;
		[SerializeField]
		private AudioSource collisionSourceAsset;
		[SerializeField]
		private float minPower;
		[SerializeField]
		private float maxPower;
	}
}
