using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DoubleArmorEffectComponent : MonoBehaviour
	{
		public GameObject effectPrefab;
		public Transform effectPoints;
		public float effectTime;
		public ArmorSoundEffectComponent soundEffect;
		[SerializeField]
		public bool changeEmission;
		public Color emissionColor;
		public Renderer renderer;
		public Color usualEmissionColor;
	}
}
