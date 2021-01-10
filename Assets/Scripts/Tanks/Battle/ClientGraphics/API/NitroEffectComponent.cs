using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class NitroEffectComponent : MonoBehaviour
	{
		public Animator animator;
		public Renderer renderer;
		public LightContainer lightContainer;
		public GameObject effectPrefab;
		public Transform effectPoints;
		public SpeedSoundEffectComponent soundEffect;
		public int burningTimeInMs;
	}
}
